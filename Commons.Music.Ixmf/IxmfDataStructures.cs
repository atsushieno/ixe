using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using FadeCurveShapeID = System.String; // 4-byte character code

namespace Commons.Music.Ixmf
{
	public struct Expression
	{
		byte OpCode { get; set; }
		uint Operand { get; set; }
	}

	public enum FadeDirectionID
	{
		FadeIn,
		FadeOut
	}

	public enum MediaHandlingTypeID
	{
		InMemoryFileLoad,
		InMemoryNetworkLoad,
		StreamedFile,
		StreamedNetwork,
	}
	
	public enum MuteOrUnmuteID
	{
		Unmute,
		Mute,
	}
	
	public enum NarrowingInclusionRuleID
	{
		Always,
		FollowNarrowingRule,
		Never
	}
	
	public enum NarrowingRuleID
	{
		SelectAll,
		NLRU,
		HasMetadataTag,
		NoMetadataTag,
		OrderTagGreater,
		OrderTagLess,
		SelectChunkGroup,
		ExcludeNMRU,
	}
	
	public enum PickTypeID
	{
		Random,
		Index,
		IndexFromLocal,
		IndexFromLocalAutoDec,
		IndexFromLocalAutoInc,
		IndexFromCue,
		IndexFromCueAutoDec,
		IndexFromCueAutoInc,
		IndexFromGlobal,
		IndexFromGlobalAutoDec,
		IndexFromGlobalAutoInc,
	}
	
	public enum SortTypeID
	{
		AsIs,
		ByLRU,
		ByOrderTag,
		ByChunkID,
		ByName,
		ReverseList,
		Randomize,
		ByFirstUse,
		ByDuration,
		ByMediaSize,
		ByChunkGroupID,
	}
	
	public enum TransportStateID
	{
		Play,
		Pause,
		Stop,
		WaitForSync,
	}

	public enum VariableTypeID
	{
		Local,
		Cue,
		Global,
	}

	public enum WeightingCurveID
	{
		Equal,
		Decreasing,
		Increasing,
		Gaussian,
		EitherEnd,
	}
	
	public class IXmfFile
	{
		public List<CueDefinition> Cues {
			get; private set;
		}
		public List<ScriptDefinition> SharedScripts {
			get; private set;
		}
		public List<ChunkDefinition> Chunks {
			get; private set;
		}
		public List<TransitionDefinition> Transitions {
			get; private set;
		}
		public List<CallbackDefinition> Callbacks {
			get; private set;
		}
		public List<PositionRuleDefinition> PositionRules {
			get; private set;
		}
		public List<MemorySpaceDefinition> MemorySpaces {
			get; private set;
		}
		public List<MediaTypeDefinition> MediaTypes {
			get; private set;
		}
		public List<MetadataTagDefinition> MetadataTags {
			get; private set;
		}
		public List<ExtensionData> ExtensionArea {
			get; private set;
		}
		public List<MediaFile> MediaFiles {
			get; private set;
		}
	}
	
	public partial class CueDefinition
	{
		List<object> data_fields = new List<object> ();
		
		public byte ID { get; set; }
		public string Name { get; set; }
		public int DefaultMaximumInstanceCount { get; set; }
		public List<KeyValuePair<byte,byte>> NeededPlayers { get; private set; }
		public short Priority { get; set; }
		public int DefaultSyncGroup { get; set; }
		public int DefaultTransition { get; set; }
		public int DefaultMixGroup { get; set; }
		public ushort DefaultEntrySyncPoint { get; set; }
		public ushort DefaultEntrySyncRule { get; set; }
		public FadeCurveShapeID DefaultFadeIn { get; set; }
		public ushort DefaultExitSyncPoint { get; set; }
		public ushort DefaultExitSyncRule { get; set; }
		public FadeCurveShapeID DefaultFadeOut { get; set; }
		public int GainTriminDB { get; set; }
		public List<KeyValuePair<byte,byte>> DefaultDspParameters { get; private set; }
		public List<KeyValuePair<byte,int>> MemoryUsage { get; private set; }
		public List<KeyValuePair<byte,int>> BufferDurations { get; private set; }
		public List<KeyValuePair<int,ScriptDefinition>> Scripts { get; private set; }
		public List<ChunkPoolItem> ChunkPool { get; private set; }
		// FIXME: should we expose it?
		public byte [] ExtensionData { get; set; }
	}
	
	public class ChunkPoolItem
	{
		public int ChunkIndex { get; set; }
		public int ChunkID { get; set; }
		public int DefaultNextChunk { get; set; }
	}
	
	public class ChunkDefinition
	{
		public int MediaFileID { get; set; }
		public List<int> MetadataTags { get; private set; }
		public ushort MediaType { get; set; }
		public ushort DefaultMediaHandlingID { get; set; }
		public ushort DefaultPriority { get; set; }
		public int DefaultSyncGroup { get; set; }
		public int DefaultTempoMapID { get; set; }
		public int StartOffset { get; set; }
		public int EndOffset { get; set; }
		public List<KeyValuePair<byte,byte>> ExitPoints { get; private set; }
		public List<KeyValuePair<byte,byte>> EntryPoints { get; private set; }
		public int GainTrim { get; set; }
		public int DefaultNextChunk { get; set; }
		public int DefaultChunkGroup { get; set; }
		public int DefaultTransition { get; set; }
		public byte DefaultIncludeInNarrowing { get; set; }
		public int DefaultOrderTag { get; set; }
		public int DefaultLRUOrder { get; set; }
		public int DefaultPickWeight { get; set; }
		public int DefaultCancelScript { get; set; }
		public List<KeyValuePair<byte,byte>> DefaultDspParameters { get; private set; }
		// FIXME: should we expose array?
		public byte [] ExtensionData { get; set; }
	}
	
	public class ScriptDefinition
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public ScriptInstructionBuffer ScriptInstruction { get; set; }
		// FIXME: should we expose it?
		public byte [] ExtensionData { get; set; }
	}
	
	public class ScriptInstructionBuffer : IEnumerable<ScriptInstruction>
	{
		public ScriptInstructionBuffer (byte [] raw)
		{
			this.raw = raw;
		}
		
		byte [] raw;

		public byte [] GetBuffer (bool copy)
		{
			return copy ? (byte []) raw.Clone () : raw;
		}

		public IEnumerator<ScriptInstruction> GetEnumerator ()
		{
			int i = 0;
			while (i < raw.Length) {
				var inst = new ScriptInstruction (raw, i);
				yield return inst;
				i += inst.OperandLength + 3;
			}
		}
		
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
	}
	
	public struct ScriptInstruction
	{
		internal ScriptInstruction (byte [] buffer, int index)
		{
			this.buffer = buffer;
			this.index = index;
		}
		
		byte [] buffer;
		int index;

		public byte OpCodeSpace {
			get { return buffer [index]; }
		}
		public byte OpCodeID {
			get { return buffer [index + 1]; }
		}

		public byte OperandLength {
			get { return buffer [index + 2]; }
		}

		public byte GetOperandAsByte (int position)
		{
			return buffer [index + 3 + position];
		}

		public ushort GetOperandAsUShort (int position)
		{
			return (ushort) ((buffer [index + 3 + position] << 8) + buffer [index + 4 + position]);
		}
	}
	
	public class PositionRuleDefinition : List<PositionRuleItem>
	{
	}
	
	public enum PositionRuleItemType
	{
		Marker,
		PeriodicTicks,
		Extension
	}
	
	public abstract class PositionRuleItem
	{
		public abstract PositionRuleItemType ItemType { get; }
		// FIXME: use raw array?
		public byte [] ExtensionArea { get; set; }
	}
	
	public class MarkerPositionRuleItem : PositionRuleItem
	{
		public override PositionRuleItemType ItemType {
			get { return PositionRuleItemType.Marker; } 
		}
		public string MarkerName { get; set; }
	}
	
	public class PeriodicTicksPositionRuleItem : PositionRuleItem
	{
		public override PositionRuleItemType ItemType { 
			get { return PositionRuleItemType.PeriodicTicks; }
		}
		public int PeriodicTicks { get; set; }
		public int PeriodLengthInTicks { get; set; }
	}
	
	public class ExtensionPositionRuleItem : PositionRuleItem
	{
		public override PositionRuleItemType ItemType {
			get { return PositionRuleItemType.Extension; } 
		}
	}
	
	public enum TimePositionType
	{
		Marker,
		TickOffset,
		Rule,
		Any
	}

	public class TimePositionDefinition
	{
		public TimePositionType PositionType { get; set; }
		public string MarkerName { get; set; }
		// FIXME: use raw array?
		public int TickOffset { get; set; }
		public byte [] ExtensionArea { get; set; }
	}
	
	public enum SyncTypeID
	{
		End,
		NoSync,
		TickOfChunk,
		TickOfBeat,
		TickOfBar,
		TickOfPhrase,
		TickOfPhraseEnd,
		TickAny,
		BarOfChunk, // FIXME: BeatOfChunk?
		BeatOfBar,
		BeatOfPhrase,
		BeatsToPhraseEnd,
		BeatAny,
		BarLineOfChunk,
		BarLineOfPhrase,
		BarLineOfPhraseEnd,
		BarLineAny,
		TimeOffsetWithinChunk,
		TimeOffsetToChunkEnd,
		MarkerName,
		MarkerAny,
		TailHeadMarker,
		Exclude,
	}

	public class TransitionDefinition
	{
		public int SyncGroup { get; set; }
		public SyncTypeID SyncType { get; set; }
		public FadeCurveShapeID FadeInCurveShape { get; set; }
		public int FadeInDuration { get; set; }
		public FadeCurveShapeID FadeOutCurveShape { get; set; }
		public int FadeOutDuration { get; set; }
		// FIXME: use raw buffer?
		public byte [] ExtensionArea { get; set; }
	}
	
	public class MediaTypeDefinition
	{
		public int BufferDuration { get; set; }
		public string MimeType { get; set; }
		// FIXME: use raw buffer?
		public byte [] ExtensionArea { get; set; }
	}
	
	public class MetadataTagDefinition
	{
		public string MetadataType { get; set; }
		// FIXME: use raw buffer?
		public byte [] FieldID { get; set; }
		// FIXME: use raw buffer?
		public byte [] Contents { get; set; }
		// FIXME: use raw buffer?
		public byte [] ExtensionArea { get; set; }
	}
	
	public enum MemorySpaceID
	{
		Any,
		MainMemory,
		MediaProcessor,
		Disk,
	}
	
	public class MemorySpaceDefinition
	{
		public string Description { get; set; }
		// FIXME: use raw buffer?
		public byte [] ExtensionArea { get; set; }
	}
	
	public class CallbackDefinition
	{
		public string Name { get; set; }
		// FIXME: use raw buffer?
		public byte [] ExtensionArea { get; set; }
	}
	
	public class ExtensionData
	{
		// FIXME: use raw buffer?
		public byte [] ExtensionArea { get; set; }
	}
	
	public class MediaFile
	{
		public string Name { get; set; }
		
		public Stream Open ()
		{
			throw new NotImplementedException ();
		}
	}
}

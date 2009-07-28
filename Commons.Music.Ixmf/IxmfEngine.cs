using System;
using System.Collections.Generic;

using FadeCurveShapeID = System.String; // 4-byte character code
using DspParameterID = System.String; // 4-byte character code

namespace Commons.Music.Ixmf
{
	public class IxmfEngine
	{
		public IxmfEngine ()
		{
		}

		// Built-in Statements (OpCodeSpace 0x00)
		
		// global
		public void SetGlobalDefaultFade (FadeDirectionID fadeDirection, FadeCurveShapeID fadeCurveShape, uint duration)
		{
			throw new NotImplementedException ();
		}

		public void SetMasterDspParameter (DspParameterID dspParameterID, int value)
		{
			throw new NotImplementedException ();
		}

		// cue
		public void CallCue (int cueID)
		{
			throw new NotImplementedException ();
		}

		public ushort GetCueID ()
		{
			throw new NotImplementedException ();
		}

		public uint GetCueParameter ()
		{
			throw new NotImplementedException ();
		}
		
		public void SetCueMaxInstanceCount (ushort cueID, ushort countMax) 
		{
			throw new NotImplementedException ();
		}
		
		public int GetCueMaxInstanceCount (ushort cueID) 
		{
			throw new NotImplementedException ();
		}

		public int GetCueInstanceCount (ushort cueID) 
		{
			throw new NotImplementedException ();
		}

		public void SetPreBufferDuration (uint durationInSeconds)
		{
			throw new NotImplementedException ();
		}

		public void SetCueCancelScript (ushort scriptID)
		{
			throw new NotImplementedException ();
		}

		public void ReleaseCue ()
		{
			throw new NotImplementedException ();
		}

		public void Prebuffer ()
		{
			throw new NotImplementedException ();
		}

		public void InvokeCallbackFunction (ushort callbackID)
		{
			throw new NotImplementedException ();
		}

		public void SetCueInstancePriority (ushort Priority)
		{
			throw new NotImplementedException ();
		}

		public int GetCueInstancePriority ()
		{
			throw new NotImplementedException ();
		}

		public void SetCuePriority (ushort cueID, ushort Priority)
		{
			throw new NotImplementedException ();
		}

		public int GetCuePriority (ushort cueID)
		{
			throw new NotImplementedException ();
		}

		public void SetCueDefaultFade (ushort cueID, FadeDirectionID fadeDirectionID, FadeCurveShapeID fadeCurveShapeID, uint duration)
		{
			throw new NotImplementedException ();
		}

		public void SetCueDspParameter (ushort cueID, DspParameterID dspParamID, int value)
		{
			throw new NotImplementedException ();
		}

		public void SetCueSyncGroup (ushort cueID, ushort syncGroupID)
		{
			throw new NotImplementedException ();
		}

		public void SetCueMixGroup (ushort cueID, ushort mixGroupID)
		{
			throw new NotImplementedException ();
		}

		public void SetCueMediaHandling (ushort cueID, MediaHandlingTypeID mediaHandlingTypeID)
		{
			throw new NotImplementedException ();
		}

		public void PreloadCueMedia (ushort cueID)
		{
			throw new NotImplementedException ();
		}

		public void UnloadCueMedia (ushort cueID)
		{
			throw new NotImplementedException ();
		}

		// variables and functions
		public void SetVariable (VariableTypeID variableTypeID, byte variableID, int value)
		{
			throw new NotImplementedException ();
		}

		public int GetVariable (VariableTypeID variableTypeID, byte variableID) 
		{
			throw new NotImplementedException ();
		}

		public int EvaluateExpression (Expression expression)
		{
			throw new NotImplementedException ();
		}

		public int GetTime ()
		{
			throw new NotImplementedException ();
		}

		public int GetRandom (ushort MinValue, ushort MaxValue)
		{
			throw new NotImplementedException ();
		}
		
		// script control flow
		public void Label (ushort labelID)
		{
			throw new NotImplementedException ();
		}

		public void ConditionalBranch (Expression expression, ushort labelID)
		{
			throw new NotImplementedException ();
		}

		public void TimeDelay (uint duration)
		{
			throw new NotImplementedException ();
		}

		public void CallScript (ushort scriptID)
		{
			throw new NotImplementedException ();
		}
		
		public void LaunchScript (ushort scriptID)
		{
			throw new NotImplementedException ();
		}
		
		// chunk pool and chunk sequencing
		public int GetTotalPoolSize ()
		{
			throw new NotImplementedException ();
		}
		
		public void IncludeInNarrowing (ushort chunkID, NarrowingInclusionRuleID narrowingInclusionRuleID)
		{
			throw new NotImplementedException ();
		}

		public void NarrowPool (NarrowingRuleID narrowingRuleID, ushort narrowingParameter)
		{
			throw new NotImplementedException ();
		}

		public int GetNarrowedPoolSize ()
		{
			throw new NotImplementedException ();
		}

		public void AddChunkToNarrowedPool (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkOrderTag (ushort chunkID, ushort OrderTag)	
		{
			throw new NotImplementedException ();
		}

		public int GetChunkOrderTag (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkLRUOrder (ushort chunkID, ushort LruOrder)
		{
			throw new NotImplementedException ();
		}

		public int GetChunkLRUOrder (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void Sort (SortTypeID sortTypeID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkPickWeight (ushort chunkID, short PickWeight)
		{
			throw new NotImplementedException ();
		}

		public int GetChunkPickWeight (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkPickWeights (short MaxPickWeight, short MinPickWeight, byte weightingCurveID)
		{
			throw new NotImplementedException ();
		}

		public int Pick (PickTypeID pickTypeID, ushort PickParameter)
		{
			throw new NotImplementedException ();
		}

		public void SetNextChunk (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetNextTransition (ushort transitionID)
		{
			throw new NotImplementedException ();
		}
		
		// playback control
		public void PlayChunk (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetPlayerTransportState (TransportStateID transportStateID)
		{
			throw new NotImplementedException ();
		}

		public int GetPlayerTransportState ()
		{
			throw new NotImplementedException ();
		}

		public void Fade ()
		{
			throw new NotImplementedException ();
		}

		public void ReleasePlayer ()
		{
			throw new NotImplementedException ();
		}

		public void FadeAndReleasePlayer ()
		{
			throw new NotImplementedException ();
		}
		
		// chunk
		public void SetChunkFade (FadeDirectionID fadeDirectionID, FadeCurveShapeID fadeCurveShapeID, uint duration)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkPriority (ushort chunkID, ushort Priority)
		{
			throw new NotImplementedException ();
		}

		public int GetChunkPriority (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkDspParameter (ushort chunkID, DspParameterID dspParamID, int value)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkSyncGroup (ushort chunkID, ushort syncGroupID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkMixGroup (ushort chunkID, ushort mixGroupID) 
		{
			throw new NotImplementedException ();
		}

		public void SetTrackMute (ushort chunkID, byte TrackID, MuteOrUnmuteID muteOrUnmuteID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkChunkGroup (ushort chunkID, ushort chunkGroupID)
		{
			throw new NotImplementedException ();
		}

		public int GetChunkChunkGroup (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkMediaHandling (ushort chunkID, MediaHandlingTypeID mediaHandlingTypeID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkCancelScript (ushort scriptID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkTempoMap (ushort chunkID, ushort smfChunkID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkEntryPointsRule (ushort chunkID, ushort positionRuleID)
		{
			throw new NotImplementedException ();
		}

		public void SetChunkExitPointsRule (ushort chunkID, ushort positionRuleID)
		{
			throw new NotImplementedException ();
		}

		public void PreloadChunkMedia (ushort chunkID)
		{
			throw new NotImplementedException ();
		}

		public void ReleaseChunkMedia (ushort chunkID)
		{
			throw new NotImplementedException ();
		}
		
		// chunkgroup
		public void LoadMediaForChunkGroup (ushort ChunkGroupID)
		{
			throw new NotImplementedException ();
		}

		public void UnloadMediaForChunkGroup (ushort ChunkGroupID)
		{
			throw new NotImplementedException ();
		}
		
		// mixgroup
		public void SetMixGroupDspParameter (ushort mixGroupID, DspParameterID dspParameterID, int value)
		{
			throw new NotImplementedException ();
		}
		
		// syncgroup
		public void SetSyncGroupDspParameter (ushort syncGroupID, DspParameterID dspParameterID, int value)
		{
			throw new NotImplementedException ();
		}
		
		public int GetSyncGroupBars (ushort syncGroupID)
		{
			throw new NotImplementedException ();
		}
		
		public int GetSyncGroupBeats (ushort syncGroupID)
		{
			throw new NotImplementedException ();
		}
		
		public int GetSyncGroupTicks (ushort syncGroupID)
		{
			throw new NotImplementedException ();
		}

		int [] variables = new int [32];

		public int GetVariable (int index)
		{
			return variables [index];
		}
	}
	
	public partial class CueDefinition
	{
		int [] variables = new int [32];

		public int GetVariable (int index)
		{
			return variables [index];
		}
	}

	public class IxmfCue // cue instance
	{
		public IxmfCue (IxmfEngine engine, CueDefinition definition)
		{
			this.engine = engine;
			this.definition = definition;
		}

		IxmfEngine engine;
		CueDefinition definition;
		int [] variables = new int [32];

		public int GetLocalVariable (int index)
		{
			return variables [index];
		}
		
		public int GetCueVariable (int index)
		{
			return definition.GetVariable (index);
		}
		
		public int GetGlobalVariable (int index)
		{
			return engine.GetVariable (index);
		}
	}
}

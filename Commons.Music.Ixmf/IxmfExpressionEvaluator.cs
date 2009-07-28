using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.Music.Ixmf
{
	public class IxmfExpressionEvaluator
	{
		public IxmfExpressionEvaluator (IxmfEngine engine)
		{
			this.cue = cue;
		}

		IxmfCue cue;
		Stack<int> stack = new Stack<int> ();
		
		int GetValue (byte [] buffer, int index)
		{
			return (buffer [index] << 24)
				+ (buffer [index + 1] << 16)
				+ (buffer [index + 2] << 8)
				+ buffer [index + 3];
		}

		public void Evaluate (byte [] raw)
		{
			int i = 0;
			while (i < raw.Length) {
				switch (raw [i++]) {
				case 1: // PushLiteral
					stack.Push (GetValue (raw, i));
					i += 4;
					break;
				case 2:
					stack.Push (cue.GetLocalVariable (stack.Pop ()));
					break;
				case 3:
					stack.Push (cue.GetCueVariable (stack.Pop ()));
					break;
				case 4:
					stack.Push (cue.GetGlobalVariable (stack.Pop ()));
					break;
				case 5:
					stack.Push (stack.Pop () + stack.Pop ());
					break;
				case 6:
					stack.Push (stack.Pop () - stack.Pop ());
					break;
				case 7:
					stack.Push (stack.Pop () * stack.Pop ());
					break;
				case 8:
					stack.Push (stack.Pop () / stack.Pop ());
					break;
				case 9:
					stack.Push (stack.Pop () % stack.Pop ());
					break;
				case 10:
					stack.Push (stack.Pop () - stack.Pop () > 0 ? 1 : 0);
					break;
				case 11:
					stack.Push (stack.Pop () - stack.Pop () >= 0 ? 1 : 0);
					break;
				case 12:
					stack.Push (stack.Pop () - stack.Pop () < 0 ? 1 : 0);
					break;
				case 13:
					stack.Push (stack.Pop () - stack.Pop () <= 0 ? 1 : 0);
					break;
				case 14:
					stack.Push (stack.Pop () - stack.Pop () == 0 ? 1 : 0);
					break;
				case 15:
					stack.Push (stack.Pop () - stack.Pop () != 0 ? 1 : 0);
					break;
				case 16:
					stack.Push (stack.Pop () != 0 && stack.Pop () != 0 ? 1 : 0);
					break;
				case 17:
					stack.Push (stack.Pop () != 0 || stack.Pop () != 0 ? 1 : 0);
					break;
				case 18:
					stack.Push (stack.Pop () & stack.Pop ());
					break;
				case 19:
					stack.Push (stack.Pop () | stack.Pop ());
					break;
				case 20:
					stack.Push (stack.Pop () ^ stack.Pop ());
					break;
				case 21:
					stack.Push (stack.Pop () << stack.Pop ());
					break;
				case 22:
					stack.Push (stack.Pop () >> stack.Pop ());
					break;
				case 23:
					stack.Push (stack.Pop () != 0 ? 0 : 1);
					break;
				case 24:
					stack.Push (stack.Pop () + 1);
					break;
				case 25:
					stack.Push (stack.Pop () - 1);
					break;
				case 26:
					stack.Push (~stack.Pop ());
					break;
				}
			}
		}
	}
}
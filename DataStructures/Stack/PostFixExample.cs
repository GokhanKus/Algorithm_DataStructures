using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Stack
{
	public class PostFixExample
	{
		private string expression;
		CustomStack<string> stack = new CustomStack<string>();
		private string Expression()
		{
			//"231*+9-"
			int val1, val2, ans;
			for (int i = 0; i < expression.Length; i++)
			{
				string c = expression[i].ToString();
				if (c == "*")
				{
					//val1 = int.Parse(stack.Pop()); // '*' sembolunden onceki son iki sayiyi alalim ve stackten cikaralim
					//val2 = int.Parse(stack.Pop());
					GetTwoNumbersAndPop(out val1, out val2);
					ans = val2 * val1;              //operand "*" oldugu icin carpip sonucu stack'e pushlayalım
					stack.Push(ans.ToString());
				}
				else if (c == "/")
				{
					GetTwoNumbersAndPop(out val1, out val2);
					ans = val2 / val1;
					stack.Push(ans.ToString());
				}
				else if (c == "+")
				{
					GetTwoNumbersAndPop(out val1, out val2);
					ans = val2 + val1;
					stack.Push(ans.ToString());
				}
				else if (c == "-")
				{
					GetTwoNumbersAndPop(out val1, out val2);
					ans = val2 - val1;
					stack.Push(ans.ToString());
				}
				else
				{
					stack.Push(c);
				}
			}
			return stack.Pop();
		}
		public static string Run(string expression)
		{
			PostFixExample postFix = new PostFixExample();
			postFix.expression = expression;
			return postFix.Expression();
		}

		private void GetTwoNumbersAndPop(out int val1, out int val2)
		{
			val1 = int.Parse(stack.Pop());
			val2 = int.Parse(stack.Pop());
		}
	}
}

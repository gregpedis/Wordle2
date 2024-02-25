namespace Wordle.Logic
{
	public static class LetterColorHelper
	{
		public static void Update(
			string current,
			string target,
			Dictionary<char, LetterColor> values)
		{
			for (int i = 0; i < current.Length; i++)
			{
				if (target.Contains(current[i]))
				{

				}
			}

		}
	}
}

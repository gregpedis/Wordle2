namespace Wordle.Logic
{
	public static class LetterColorService
	{
		public static Dictionary<char, LetterColor> Default =>
			 Enumerable.Range('A', 26).Append(' ').ToDictionary(x => (char)x, x => LetterColor.Default);

		public static void Update(
			string current,
			string target,
			Dictionary<char, LetterColor> values)
		{

			var chars = "ABCDEFGHIJKLMNOPQRSTUVW";
			foreach (var item in chars)
			{
				values[item] = (LetterColor)Random.Shared.Next(0, 4);
			}

			Console.WriteLine(values);

			return;

			// TODO
			for (int i = 0; i < current.Length; i++)
			{
				if (target.Contains(current[i]))
				{

				}
			}

		}
	}
}

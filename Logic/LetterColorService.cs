namespace Wordle.Logic
{
	public static class LetterColorService
	{
		public static Dictionary<char, LetterColor> Default =>
			 Enumerable.Range('A', 26).Append(' ').ToDictionary(x => (char)x, x => LetterColor.Default);

		public static LetterColor[] Update(
			string guess,
			string target,
			Dictionary<char, LetterColor> values)
		{
			var res = new LetterColor[5];
			for (int i = 0; i < guess.Length; i++)
			{
				if (guess[i] == target[i])				// Exact match
				{
					res[i] = LetterColor.Green;
				}
				else if (!target.Contains(guess[i]))	// Complete miss
				{
					res[i] = LetterColor.Gray;
				}
				else									// Inexact match, lots of edgecases
				{
					res[i] = CalculateInexactMatch(guess, target, i);
				}
				UpdateInPlace(values, guess[i], res[i]);
			}
			return res;
		}

		/// <summary>
		/// Calculates if a character at index should be yellow or not.
		/// A character should be yellow if it is out-of-position AND there is neither exact matches for all occurences of it or it has been found before as many times as it exists in the target word.
		/// </summary>
		private static LetterColor CalculateInexactMatch(string guess, string target, int index)
		{
			var currentLetter = guess[index];
			var targetIndexes = GetIndexes(target, currentLetter);
			var guessIndexes  = GetIndexes(guess, currentLetter);

			// Since we are in this method, we know the letter is misplaced.
			// If the target word has equal or more occurences of the current character, they are all yellow
			if (targetIndexes.Count >= guessIndexes.Count)
			{
				return LetterColor.Yellow;
			}
			else
			{
				// the letter positions that are misplaced
				var extra = guessIndexes.Except(targetIndexes).ToList();
				// the letter positions that are missing
				var missing = targetIndexes.Except(guessIndexes).ToList();
				// if the current index is less than the count of the missing letters,
				// it should be painted yellow.
				// If it is after, it should be ignored as it will be already painted in a previous position.
				return extra.IndexOf(index) < missing.Count
					? LetterColor.Yellow
					: LetterColor.Gray;
			}
		}

		private static List<int> GetIndexes(string word, char letter) =>
			word.Select((value, index) => (value, index))
			.Where(x => x.value == letter)
			.Select(x => x.index)
			.ToList();

		private static void UpdateInPlace(Dictionary<char, LetterColor> dict, char ch, LetterColor newValue)
		{
			if (dict[ch] < newValue)
			{
				dict[ch] = newValue;
			}
		}
	}
}

namespace Wordle.Logic;

public static partial class WordDatabase
{
	public static string Pick() =>
	Choices[Random.Shared.Next(0, Choices.Length)];

	public static bool Exists(string word) =>
		Vocabulary.Contains(word);
}

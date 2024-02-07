namespace Wordle;

public class Attempt
{
	public Letter[] Letters { get; set; }

    public Attempt() =>
		Letters = Enumerable.Range(0, 5).Select(_ => new Letter()).ToArray();

	public void SetWord(string word)
	{
		for (int i = 0; i < 5; i++)
		{
			Letters[i].Value = word[i];
		}
	}

	public override string ToString() =>
		string.Join("",Letters.Select(x => x.Value));
}

public class Letter
{
	public char Value { get; set; } = ' ';
	public string Styling { get; set; } = $"l{Random.Shared.Next(0, 4)}"; // TODO: make all 4 styles, not-validated, not-found, wrong-position, correct-position
}

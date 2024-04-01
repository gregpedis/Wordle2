namespace Wordle.Logic;

public class Attempt
{
	private char[] Letters;
	private LetterColor[] Colors;

	public Attempt()
	{
		Letters = Enumerable.Range(0, 5).Select(_ => ' ').ToArray();
		Colors = new LetterColor[5];
	}

	public override string ToString() =>
		string.Join("", Letters).TrimEnd();

	public (char Letter, LetterColor Color) this[int index] =>
		(Letters[index], Colors[index]);

	public void SetWord(string word) =>
		Letters = word.ToArray();

	public void SetColors(LetterColor[] colors) =>
		Colors = colors;
}

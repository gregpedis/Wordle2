namespace Wordle.Logic;

public class Attempt
{
    public char[] Letters { get; set; }

    public Attempt() =>
        Letters = Enumerable.Range(0, 5).Select(_ => ' ').ToArray();

    public void SetWord(string word) =>
        Letters = word.ToArray();

    public override string ToString() =>
        string.Join("", Letters);
}

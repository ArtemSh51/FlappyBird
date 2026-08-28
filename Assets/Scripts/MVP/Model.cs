using System;

public class Model : IDisposable
{
    private Score _score;

    public event Action<int> ScoreChanged;

    public Model(Score score)
    {
        _score = score;

        _score.Changed += NotifyScoreChanged;
    }

    public void Dispose()
    {
        _score.Changed -= NotifyScoreChanged;
    }

    private void NotifyScoreChanged(int score)
    {
        ScoreChanged?.Invoke(score);
    }
}

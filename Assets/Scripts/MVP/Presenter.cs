public class Presenter
{
    private Score _score;
    private IViewer _viewer;

    public Presenter(Score score, Viewer viewer)
    {
        _score = score;
        _viewer = viewer;
    }

    public void Enable()
    {
        _score.Changed += ChangeTextScore;
    }

    public void Disable()
    {
        _score.Changed -= ChangeTextScore;
    }

    private void ChangeTextScore(int score)
    {
        _viewer.ChangeTextController(score);
    }
}

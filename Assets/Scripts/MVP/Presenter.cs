using System;

public class Presenter : IDisposable
{
    private Model _model;
    private IViewer _viewer;

    public Presenter(Model model, Viewer viewer)
    {
        _model = model;
        _viewer = viewer;

        _model.ScoreChanged += ChangeTextScore;
    }

    public void Dispose()
    {
        _model.ScoreChanged -= ChangeTextScore;
    }

    private void ChangeTextScore(int score)
    {
        _viewer.ChangeTextController(score);
    }
}

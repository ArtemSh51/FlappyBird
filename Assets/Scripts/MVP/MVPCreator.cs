using UnityEngine;

public class MVPCreator : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Model _model;
    [SerializeField] private Presenter _presenter;
    [SerializeField] private Viewer _viewer;

    private void OnEnable()
    {
        _model = new Model(_score);
        _presenter = new Presenter(_model, _viewer);
    }

    private void OnDisable()
    {
        _model.Dispose();
        _presenter.Dispose();
    }
}

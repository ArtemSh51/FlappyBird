using UnityEngine;

public class MVPCreator : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Presenter _presenter;
    [SerializeField] private Viewer _viewer;

    private void Awake()
    {
        _presenter = new Presenter(_score, _viewer);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}

using UnityEngine;

public class Viewer : MonoBehaviour, IViewer
{
    [SerializeField] private TextController _text;

    public void ChangeTextController(int value)
    {
       _text.ChangeTextScore(value);
    }
}

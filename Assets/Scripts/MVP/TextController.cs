using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextController : MonoBehaviour
{
    private TextMeshProUGUI _textScore;

    private void Awake()
    {
        _textScore = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeTextScore(int value)
    {
        _textScore.text = value.ToString();
    }
}

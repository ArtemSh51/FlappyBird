using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    private Button _playButton;

    public event Action ButtonPressed;

    private void Awake()
    {
        _playButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(StartGame);
    }

    private void StartGame()
    {
        ButtonPressed?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private Toucher _toucher;
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private InputReader _reader;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _playerSpawner.PlayerKilled += StopGame;

        _toucher.PlayerTouched += StopGame;

        _playButton.ButtonPressed += StartGame;
    }

    private void OnDisable()
    {
        _playerSpawner.PlayerKilled -= StopGame;

        _toucher.PlayerTouched -= StopGame;

        _playButton.ButtonPressed -= StartGame;
    }

    private void StartGame()
    {
        _playButton.gameObject.SetActive(false);

        _reader.enabled = true;

        Time.timeScale = 1;
    }

    private void StopGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

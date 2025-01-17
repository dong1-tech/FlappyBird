using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _gameStartCanvas;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 0;
    }
    public void GameStart()
    {
        _gameStartCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        AudioManager.Instance.PauseAudio();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

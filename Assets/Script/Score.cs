using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        _scoreText.text = _score.ToString();
        _bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        if(_score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", _score);
            _bestScoreText.text = _score.ToString();
        }
    }
    public void UpdateScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
        UpdateBestScore();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _gameAudio;
    [SerializeField] private AudioClip _audio;
    public static AudioManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _gameAudio.clip = _audio;
        _gameAudio.Play();
    }

    public void PauseAudio()
    {
        _gameAudio.Pause();
    }
}

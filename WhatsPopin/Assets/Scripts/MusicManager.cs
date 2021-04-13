using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : Singleton<MusicManager>
{
    public new AudioSource audio;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    public void Play(AudioClip musicToPlay)
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }

        audio.clip = musicToPlay;
        audio.Play();
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenuScene")
        {
            Play(menuMusic);
        }
        else
        {
            Play(gameMusic);
        }
    }
}

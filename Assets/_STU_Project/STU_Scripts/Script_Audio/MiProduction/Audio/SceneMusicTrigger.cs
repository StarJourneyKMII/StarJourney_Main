using MiProduction.BroAudio;
using MiProduction.Scene;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicTrigger : MonoBehaviour
{
    [SerializeField] SceneConfig_Music sceneMusic;
    private Music currentMusic;
    private void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        if (sceneMusic.TryGetSceneData(out Music music))
        {
            if (music == Music.None)
            {
                SoundSystem.StopMusicImmediately();
            }
            else if (currentMusic != music)
            {
                SoundSystem.PlayMusic(music, Transition.FadeOutThenFadeIn);
            }
            currentMusic = music;
        }
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
}

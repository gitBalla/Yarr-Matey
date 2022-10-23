using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Member Variables
    private static AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusicArray;

    void Awake()
    {

        if (audioSource == null) 
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.volume = 0.5f;
            audioSource.loop = true;
        }

        // delegate OnSceneLoaded to the scene manager
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // decides which audio clip based on game state
        switch (GameManager.currentGameState)
        {
            case GameManager.GameState.Start:
                audioSource.clip = backgroundMusicArray[0];
                break;
            case GameManager.GameState.FirstLevel:
                audioSource.clip = backgroundMusicArray[1];
                break;
            case GameManager.GameState.SecondLevel:
                break;
            default:
                break;
        }
        audioSource.Play();
    }
}

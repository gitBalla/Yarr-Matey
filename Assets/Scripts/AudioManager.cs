using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Member Variables
    private static AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusicArray;
    private AudioSource footstepSource;
    [SerializeField] private AudioClip[] footstepClips;

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
                footstepSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
                break;
            case GameManager.GameState.SecondLevel:
                break;
            default:
                break;
        }
        audioSource.Play();
    }

    //On call, plays footstep clips alternating between two clips
    public void PlayFootstepsAudio()
    {
        footstepSource.clip = footstepClips[footstepSource.clip == footstepClips[0] ? 1 : 0]; //alternate between two clips
        footstepSource.Play();
    }

    public void StopFootstepsAudio()
    {
        footstepSource.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Member Variables
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusicArray;

    // Start is called before the first frame update
    void Start()
    {
        // loop unless specified not to
        audioSource.loop = true;
        audioSource.clip = backgroundMusicArray[0];
        audioSource.Play();
        DontDestroyOnLoad(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.currentGameState == GameManager.GameState.FirstLevel && audioSource.clip != backgroundMusicArray[1])
        {
            audioSource.clip = backgroundMusicArray[1];
            audioSource.Play();
        }
    }
}

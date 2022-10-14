using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusicArray;

    private IEnumerator myCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // loop unless specified not to
        audioSource.loop = true;

        // run coroutine to play music
        myCoroutine = PlayBackground();
        StartCoroutine(myCoroutine);
    }

    // Play normal state background music after game intro background music finishes
    private IEnumerator PlayBackground()
    {
        audioSource.PlayOneShot(backgroundMusicArray[0]);
        yield return new WaitForSeconds(backgroundMusicArray[0].length);
        audioSource.clip = backgroundMusicArray[1];
        audioSource.Play();
    }
}

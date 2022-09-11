using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusicArray;
    [SerializeField] private AudioClip[] soundEffectArray; //assume will need this later

    private Coroutine myCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        // loop unless specified not to
        audioSource.loop = true;

        // run coroutine to play music
        if (myCoroutine == null) myCoroutine = StartCoroutine("playBackground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play normal state background music after game intro background music finishes
    IEnumerator playBackground()
    {
        audioSource.PlayOneShot(backgroundMusicArray[0]);
        yield return new WaitForSeconds(backgroundMusicArray[0].length);
        audioSource.clip = backgroundMusicArray[1];
        audioSource.Play();
    }
}

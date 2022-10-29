using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Assessment 3 movement script
 */
public class MovementManager : MonoBehaviour
{
    // Member Variables
      //movement
    [SerializeField] private GameObject pirate;
    private WalkTweener tweener;
    private Animator animator;
    private Vector3 lastPos;
    private float distance;
      //audio
    [SerializeField] private AudioSource footstepSource;
    [SerializeField] private AudioClip[] footstepClips;

    //vector list: pirate's first iteration movement in top left corner
    private Vector2 start = new(-6.25f, 6.75f);
    private const float pirateSpeed = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = pirate.GetComponent<Animator>();
        tweener = GetComponent<WalkTweener>();

        //animator.SetTrigger("HitWall"); //initial trigger to start cycle

        lastPos = pirate.transform.position;
        distance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(lastPos, pirate.transform.position);
    }

    void PlayFootstepAudio()
    {
        if (distance >= 0.5f)
        {
            lastPos = pirate.transform.position;
            if (!footstepSource.isPlaying)
            {
                footstepSource.clip = footstepClips[footstepSource.clip == footstepClips[0] ? 1 : 0]; //alternate between two clips
                footstepSource.Play();
            }
        }
    }
}
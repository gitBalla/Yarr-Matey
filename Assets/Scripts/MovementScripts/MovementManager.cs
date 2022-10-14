using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    static float west = -6.25f;
    static float east = -3.75f;
    static float north = 6.75f;
    static float south = 4.75f;
    private Vector3 vectorSW = new(west, south, 0.0f);
    private Vector3 vectorSE = new(east, south, 0.0f);
    private Vector3 vectorNE = new(east, north, 0.0f);
    private Vector3 vectorNW = new(west, north, 0.0f);
    private const float pirateSpeed = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = pirate.GetComponent<Animator>();
        tweener = GetComponent<WalkTweener>();

        animator.SetTrigger("HitWall"); //initial trigger to start cycle

        lastPos = pirate.transform.position;
        distance = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveClockwise();

        distance = Vector3.Distance(lastPos, pirate.transform.position);
        if (distance >= 0.5f)
        {
            lastPos = pirate.transform.position;
            PlayFootstepAudio();
        }

    }

    private void MoveClockwise()
    {
        //move clockwise depending on location over 3 seconds
        if (pirate.transform.position == vectorSW)
        {
            animator.SetTrigger("UpPress");
            tweener.AddTween(pirate.transform, vectorSW, vectorNW, 1 / pirateSpeed);
        }
        else if (pirate.transform.position == vectorNW)
        {
            animator.SetTrigger("RightPress");
            tweener.AddTween(pirate.transform, vectorNW, vectorNE, 1 / pirateSpeed);
        }
        else if (pirate.transform.position == vectorNE)
        {
            animator.SetTrigger("DownPress");
            tweener.AddTween(pirate.transform, vectorNE, vectorSE, 1 / pirateSpeed);
        }
        else if (pirate.transform.position == vectorSE)
        {
            animator.SetTrigger("LeftPress");
            tweener.AddTween(pirate.transform, vectorSE, vectorSW, 1 / pirateSpeed);
        }
    }

    void PlayFootstepAudio()
    {
        if (!footstepSource.isPlaying)
        {
            footstepSource.clip = footstepClips[footstepSource.clip == footstepClips[0] ? 1 : 0]; //alternate between two clips
            footstepSource.Play();
        }
    }
}
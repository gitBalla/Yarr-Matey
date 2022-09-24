using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    // Member Variables
    [SerializeField] private GameObject pirate;
    private WalkTweener walkTweener;

    //vector list
    //Pirate's first iteration movement in top left corner
    Vector3 vectorSW = new(-6.25f, 4.75f, 0.0f);
    Vector3 vectorSE = new(-3.75f, 4.75f, 0.0f);
    Vector3 vectorNE = new(-3.75f, 6.75f, 0.0f);
    Vector3 vectorNW = new(-6.25f, 6.75f, 0.0f);

    float pirateSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        walkTweener = GetComponent<WalkTweener>();
    }

    // Update is called once per frame
    void Update()
    {
        //move clockwise depending on location over 3 seconds
        if (pirate.transform.position == vectorSW)
            TryAddTween(pirate, vectorNW, pirateSpeed);
        if (pirate.transform.position == vectorNW)
            TryAddTween(pirate, vectorNE, pirateSpeed);
        if (pirate.transform.position == vectorNE)
            TryAddTween(pirate, vectorSE, pirateSpeed);
        if (pirate.transform.position == vectorSE)
            TryAddTween(pirate, vectorSW, pirateSpeed);
    }


    //does addTween essentially, but removes some duplicate code above (anyItem.transform, anyItem.transform.position) to make it more readable
    public bool TryAddTween(GameObject anyItem, Vector3 endPos, float duration)
    {
        return walkTweener.AddTween(anyItem.transform, anyItem.transform.position, endPos, duration);
    }
}

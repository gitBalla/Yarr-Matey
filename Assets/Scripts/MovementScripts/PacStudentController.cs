using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // Movement enum
    private enum Movement { Idle, Up, Down, Left, Right }

    // Member Variables
    //// Input
    private Movement currentInput = Movement.Idle;
    private Movement lastInput = Movement.Idle;
    //// Pirate
    [SerializeField] private GameObject pirate;
    //// Tweener
    private WalkTweener tweener;
    //// Movement
    private Vector2 lastPos, nextPos = new(-6.25f, 6.75f);
    private const float pirateSpeed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<WalkTweener>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        GetAnimationState();
        MovePirate();
        Debug.Log(pirate.transform.position);
    }

    void GetMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = Movement.Up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = Movement.Left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = Movement.Down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = Movement.Right;
        }
    }

    void GetAnimationState()
    {

    }

    // calculates 
    void MovePirate()
    {
        if (!tweener.TweenExists(pirate.transform))
        {
            currentInput = lastInput;
            lastPos = nextPos;
        }

        switch (currentInput)
        {
            case Movement.Idle:
                break;
            case Movement.Up:
                nextPos = lastPos + Vector2.up / 2;
                TweenPirate();
                break;
            case Movement.Down:
                nextPos = lastPos + Vector2.down / 2;
                TweenPirate();
                break;
            case Movement.Left:
                nextPos = lastPos + Vector2.left / 2;
                TweenPirate();
                break;
            case Movement.Right:
                nextPos = lastPos + Vector2.right / 2;
                TweenPirate();
                break;
            default:
                break;
        }
    }

    void TweenPirate()
    {
        tweener.AddTween(pirate.transform, lastPos, nextPos, 1 / pirateSpeed);
    }
}

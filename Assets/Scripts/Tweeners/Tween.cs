using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; }
    public Vector3 StartPos { get; }
    public Vector3 EndPos { get; }
    public float StartTime { get; }
    public float Duration { get; }

    public Tween(Transform targetObject, Vector3 startPos, Vector3 endPos, float start, float duration)
    {
        this.Target = targetObject;
        this.StartPos = startPos;
        this.EndPos = endPos;
        this.StartTime = start;
        this.Duration = duration;
    }
}

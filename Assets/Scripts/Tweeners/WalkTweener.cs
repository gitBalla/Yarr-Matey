using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTweener : Tweener
{
    // Member variables
    // variables inherited from tweener

    // Update is called once per frame
    void Update()
    {
        Tween activeTween;
        for (int i = activeTweens.Count - 1; i >= 0; i--)
        {
            activeTween = activeTweens[i];
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                float elapsedTime = Time.time - activeTween.StartTime;
                float timeFraction = elapsedTime / activeTween.Duration;
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            }
            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTweens.RemoveAt(i);
            }
        }
    }
}

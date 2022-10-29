using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 ** This is a walking tweener, inheriting the the parent tweener script but specifying updates to walking movement
 */
public class WalkTweener : Tweener
{
    // Member variables

    // Update is called once per frame
    override public void Update()
    {
        Tween activeTween;
        for (int i = activeTweens.Count - 1; i >= 0; i--)
        {
            activeTween = activeTweens[i];
            if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.05f)
            {
                float elapsedTime = timer - activeTween.StartTime;
                float timeFraction = elapsedTime / activeTween.Duration;
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            }
            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTweens.RemoveAt(i);
            }
        }

        base.Update(); //timer update from tween base class

    }
}

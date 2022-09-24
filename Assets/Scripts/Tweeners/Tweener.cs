using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    // Member variables
    protected List<Tween> activeTweens;
    protected float timer;

    // Start is called before the first frame update
    void Start()
    {
        activeTweens = new List<Tween>();
        timer = 0.0f;
    }

    // Update is called once per frame
    virtual public void Update()
    {
        timer += Time.deltaTime;
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (!TweenExists(targetObject))
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        return false;
    }

    public bool TweenExists(Transform target)
    {
        foreach (Tween activeTween in activeTweens)
        {
            if (activeTween.Target.transform == target) return true;
        }
        return false;
    }
}

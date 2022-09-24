using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showcase : MonoBehaviour
{
    // Member Variables
    private Animator animator;
    private Vector3 showcase = new(-5.25f, 1.75f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position == showcase)
        {
            animator.SetTrigger("Showcase");
            //animator.SetBool("isShowcase", isShowcase);
        }
    }
}

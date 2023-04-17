using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    private Animator animator;
    public float animationSpeed=1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = animationSpeed;
        animator.Play("Wheel1");
        
    }
}

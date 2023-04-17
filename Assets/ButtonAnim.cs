using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
  
    // Start is called before the first frame update

    private Animator animator;
    public float animationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = animationSpeed;       
    }
    private void OnMouseEnter()
    {
        animator.Play("MenuButton1Hover");
    }
    private void OnMouseExit()
    {
        animator.Play("MenuButton1Exit");
    }
}

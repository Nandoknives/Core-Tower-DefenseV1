using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ButtonsAnimator : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseEnter()
    {
        animator.SetTrigger("Enter");
        Debug.Log("Hover");
    }
    private void OnMouseExit()
    {
        animator.SetTrigger("Exit");
    }
}

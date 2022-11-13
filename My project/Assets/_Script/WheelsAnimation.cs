using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsAnimation : MonoBehaviour
{
    private Animator animator;
    private CarController carController;
    [SerializeField] private TrailRenderer[] trailRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        carController = GetComponent<CarController>();
        
    }

    void Update()
    {
        if (carController.turnInput > 0)
        {
            animator.SetBool("goingLeft", false);
            animator.SetBool("goingRight", true);


        }
        else if(carController.turnInput < 0)
        {
            animator.SetBool("goingLeft", true);
            animator.SetBool("goingRight", false);
        }
        else
        {
            animator.SetBool("goingLeft", false);
            animator.SetBool("goingRight", false);

        }
        if (carController.turnInput != 0)
        {
            foreach (var trail in trailRenderer)
            {
                trail.emitting = true;
            }
        }
        else
        {
            foreach(var trail in trailRenderer)
            {
                trail.emitting= false;
            }
        }
    }
}

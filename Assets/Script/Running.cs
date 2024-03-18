using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class running : MonoBehaviour
{
    private Animator animator;
    public float speed;
    public float speedback;
    public float speedleft;
    public float speedright;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", speed);
        animator.SetFloat("SpeedBack", speedback);
        animator.SetFloat("SpeedLeft", speedleft);
        animator.SetFloat("SpeedRight", speedright);

        if (Input.GetKey(KeyCode.W))
            speed = 1;
        else 
            speed = 0;

        if (Input.GetKey(KeyCode.S))
            speedback = 1;
        else
            speedback = 0;

        if(Input.GetKey(KeyCode.D))
            speedleft = 1;
        else 
            speedleft = 0;

        if (Input.GetKey(KeyCode.A))
            speedright = 1;
        else
            speedright = 0;

    }
}

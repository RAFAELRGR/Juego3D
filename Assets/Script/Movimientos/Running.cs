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
    public int jump;
    public int phaseone;
    public int phasetwo;
    public int phasethree;
    public int phasefour;

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
        animator.SetInteger("Jump", jump);
        animator.SetInteger("phaseone",phaseone);
        animator.SetInteger("phasetwo", phasetwo);
        animator.SetInteger("phasethree", phasethree);
        animator.SetInteger("phasefour", phasefour);

        if (Input.GetKey(KeyCode.W))
            speed = 1;
        else
            speed = 0;

        if (Input.GetKey(KeyCode.S))
            speedback = 1;
        else
            speedback = 0;

        if (Input.GetKey(KeyCode.D))
            speedleft = 1;
        else
            speedleft = 0;

        if (Input.GetKey(KeyCode.A))
            speedright = 1;
        else
            speedright = 0;

        if (Input.GetKey(KeyCode.Space))
            jump = 1;
        else
            jump = 0;
        if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.Mouse0))
            phaseone = 1;
        else
            phaseone = 0;
        if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.Mouse0))
            phasetwo = 1;
        else
            phasetwo = 0;
        if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.Mouse0))
            phasethree = 1;
        else
            phasethree = 0;
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.Mouse0))
            phasefour = 1;
        else
            phasefour = 0;

    }
}

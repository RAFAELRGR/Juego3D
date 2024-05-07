using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    public CharacterController controller;

    Animator animator = new Animator();


    public float speed = 3f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Pausa Pausa;
    public AudioSource pasos;


    private bool HActive;
    private bool VActive;


    PlayerInteraction playerInteraction;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;
        move = Vector3.ProjectOnPlane(move, Vector3.up);

        controller.Move(move * speed * Time.deltaTime);

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        Interact();

        playerInteraction = GetComponentInChildren<PlayerInteraction>();

        if (Input.GetButtonDown("Horizontal"))
        {
            if (VActive == false)
            {
                HActive = true;
                pasos.Play();
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (HActive == false)
            {
                VActive = true;
                pasos.Play();
            }
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            HActive = false;
            if (VActive == false)
            {
                pasos.Pause();
            }
        }
        if (Input.GetButtonUp("Vertical"))
        {
            VActive = false;
            if (HActive == false)
            {
                pasos.Pause();
            }
        }
    }

    public void Interact()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerInteraction.Interact();
            }
        }

    
}

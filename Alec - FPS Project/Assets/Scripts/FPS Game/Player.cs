using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //We go ahead and put the variables we'll need for the code
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    [SerializeField] Transform playerTransform;
    [SerializeField] Transform cameraTransform;

    public CharacterController controller;

    float camLook = 0.0f;
    float velocityY;



    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        //Script for movement

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (controller.isGrounded && !Input.GetKeyDown(KeyCode.Space))
        {
            velocityY = 0f;
        }
        else
        {
            Jump();
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * movement.y + transform.right * movement.x) * moveSpeed + Vector3.up* velocityY;

        controller.Move(velocity * Time.deltaTime);

    }

    private void Rotate()
    {

        Vector2 rotation = new Vector2(Input.GetAxis("Mouse X"), (Input.GetAxis("Mouse Y")));

        camLook -= rotation.y * turnSpeed;

        camLook = Mathf.Clamp(camLook, -90.0f, 90.0f);

        cameraTransform.localEulerAngles = Vector3.right * camLook;

        transform.Rotate(Vector3.up * rotation.x * turnSpeed);

    }

    private void Jump()
    {
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocityY = jumpForce;
        }
    }
}

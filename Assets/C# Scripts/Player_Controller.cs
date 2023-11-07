using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float walkSpeed = 5f; // Regular movement speed
    public float sprintSpeed = 10f; // Sprinting speed
    public float sensitivity = 2f; // Mouse look sensitivity
    public float jumpForce = 5f; // Jump force
    public Transform playerCamera; // Reference to the camera

    private Rigidbody rb;
    private float verticalLookRotation;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Toggle sprinting with Left Shift key
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        rb.velocity = new Vector3(moveDirection.normalized.x * currentSpeed, rb.velocity.y, moveDirection.normalized.z * currentSpeed);

        // Player looking
        float horizontalLook = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0f, horizontalLook, 0f);

        verticalLookRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0f, 0f);

        // Player jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}

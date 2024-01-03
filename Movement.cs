using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] float jumpForce;
	[SerializeField] float gravity = -10f;
	[SerializeField] float walkSpeed;
	[SerializeField] float mouseSensivity;

	[SerializeField] GameObject cameraHolder;

	Vector3 playerInput;
	Vector3 velocity;

	CharacterController characterController;
	float verticalLookRotation;

    private void Start()
    {
		characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
		Move();
		Look();
    }
    void Move()
	{
		playerInput = Vector3.zero;
		playerInput += transform.forward * Input.GetAxis("Vertical");
		playerInput += transform.right * Input.GetAxis("Horizontal");

		if (characterController.isGrounded)//----------  J U M P
		{
			velocity.y = -1f;
			if (Input.GetButton("Jump"))
			{
				velocity.y = jumpForce;
			}
		}

		velocity.y += gravity * Time.deltaTime;
		characterController.Move(playerInput * walkSpeed * Time.deltaTime);
		characterController.Move(velocity * Time.deltaTime);
	}
	void Look()
	{
		transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60f, 30f);
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;

    }

}

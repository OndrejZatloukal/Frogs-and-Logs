using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    {
    private float moveHorizontal;
    private float moveVertical;
    private float turningSpeed = 20f;

    private Animator playerAnimator;
    private Vector3 movement;
    private Rigidbody playerRigidbody;

    [SerializeField] private RandomSoundPlayer playerFootsteps;

	// Use this for initialization
	void Start()
    {
        // Gather components from the Player GameObjects
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
    {
        // Gather input from the keyboard
        RespondToUserInput();
    }

    private void RespondToUserInput()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    private void FixedUpdate()
    {
        // If the player's movement Vector does not equal zero...
        if (movement != Vector3.zero)
        {
            ProcessRotation();

            AnimationEnabled();
        }
        else
        {
            AnimationDisabled();
        }
    }

    private void AnimationDisabled()
    {
        // Otherwise, don't play the jump animation.
        playerAnimator.SetFloat("Speed", 0f);

        // Don't play footstep sounds.
        playerFootsteps.enabled = false;
    }

    private void AnimationEnabled()
    {
        // ...then play the jump animation...
        playerAnimator.SetFloat("Speed", 2f);

        // ...play footsteps sounds.
        playerFootsteps.enabled = true;
    }

    private void ProcessRotation()
    {
        // ...then create a target rotation based on the movement vector
        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

        // ...and create another rotation that moves from the current rotatation to the target rotation...
        Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, turningSpeed * Time.deltaTime);

        // ...and change the players rotation to the new incremental rotation...
        playerRigidbody.MoveRotation(newRotation);
    }
}

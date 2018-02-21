using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	private double characterPosition = 0;
	private int lanePosition = 0; // -1 0 1
	public bool moveLocked = false;
	public Animator playerAnim; //animation
	public Rigidbody player;
	public KeyCode moveLeftKey;
	public KeyCode moveRightKey;


	// Use this for initialization
	void Start () {
		//telling unity to grab animatior form the player
		playerAnim = GetComponent<Animator>();

		// Player 
		player = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		// Handle moving character constantly forward
		player.velocity = new Vector3 (0, 0, Constants.forwardMovementSpeed);

		// Check for movement locked
		if (!moveLocked) {
			
			// Check for left movement 
			if ((Input.GetKeyDown (moveLeftKey)) && (lanePosition > -1)) { 

				//for animation
				playerAnim.Play ("fly_left");

				// Set lane position to go to and lock movement
				lanePosition -= 1;
				moveLocked = true;
			}

			// Check for right movement
			if ((Input.GetKeyDown (moveRightKey)) && (lanePosition < 1)) { 

				//for animation
				playerAnim.Play ("fly_right");

				// Set lane position to go to and lock movement
				lanePosition += 1;
				moveLocked = true;
			}
		} 

		// Movement is locked
		else 
		{
			// Get character x position
			characterPosition = System.Math.Round (transform.position.x, 1);

			// Move character to the right 
			if (characterPosition < lanePosition) {
				transform.position += new Vector3 (Constants.strafeMovementSpeed, 0, 0);
			}

			// Move character to the left
			else if (characterPosition > lanePosition) {
				transform.position += new Vector3 ((Constants.strafeMovementSpeed * -1), 0, 0);
			}

			// Reset lock on movement
			else if (characterPosition == lanePosition) {
				playerAnim.StopPlayback ();
				moveLocked = false;
			}
		}
	}
}
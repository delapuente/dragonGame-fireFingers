
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	// Reference to the player's movement.
	PlayerMovement playerMovement; 

	private bool attackLocked = false;

	public Animator playerAnim; //animation
	public Rigidbody player;
	public KeyCode attackKey;
	public GameObject fireballPrefab;


	void Start () {
		// Get player and components 
		player = GetComponent<Rigidbody> ();
		playerMovement = GetComponent <PlayerMovement> ();
		playerAnim = GetComponent<Animator>();

	}

	void Update () {
		// Check for attack and movement locked
		if (!attackLocked && !playerMovement.moveLocked) {
			// Check for attack
			if (Input.GetKeyDown (attackKey)) {

				//for animation
				playerAnim.Play ("attack");

				// Fire a fireball!!!
				Fire();
			}
		} 
	}

	void Fire () {
		// Create the fireball from prefab
		var fireball = (GameObject)Instantiate (
			fireballPrefab,
			new Vector3 (player.position.x, player.position.y, (player.position.z + .4f)),
			player.rotation);

		// Add velocity to the bullet
		fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * Constants.fireballSpeed;

		// Destroy the bullet after 2 seconds
		Destroy(fireball, 2.0f);
	}
}
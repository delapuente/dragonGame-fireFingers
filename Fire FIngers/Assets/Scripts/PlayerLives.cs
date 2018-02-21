using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLives : MonoBehaviour {
	// Reference to the player's movement.
	PlayerMovement playerMovement;
	PlayerAttack playerAttack;

	public Animator playerAnim; //animation
	public Rigidbody player;

	public int lifeCount;                                   
	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.


	void Awake () {
		// Get player and components 
		player = GetComponent<Rigidbody> ();
		playerMovement = GetComponent <PlayerMovement> ();
		playerAttack = GetComponent <PlayerAttack> ();
		playerAnim = GetComponent<Animator>();

		// Set the initial health of the player.
		lifeCount = Constants.playerLifeCount;
	}


	void Update () {
		// If the player has just been damaged
//		if(damaged){
//			// animate the player
//		}

		// Reset the damaged flag.
		damaged = false;
	}


	public void TakeDamage (int amount)
	{
		// Set the damaged flag for animations
		damaged = true;

		// Reduce the lifeCount
		lifeCount -= amount;

		// Check if player is dead or a zombie
		if(lifeCount <= 0 && !isDead)
		{
			Death ();
		}
	}


	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;

		// Turn off any remaining shooting effects.
//		playerAttack.DisableEffects ();

		// Tell the animator that the player is dead.
//		playerAnim.SetTrigger ("Die");

		// Turn off the movement and shooting scripts.
		playerMovement.enabled = false;
		playerAttack.enabled = false;
	}  

	void OnTriggerEnter(Collider other)
	{
		// Check for collision with tower
		if (other.name == "Tower(Clone)" && !(other.GetComponent<Tower> ().isDead)) {
			print ("Collision with tower");
			//TakeDamage(1);
		}
		
	}
}
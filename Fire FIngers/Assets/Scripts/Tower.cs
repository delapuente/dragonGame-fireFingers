using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tower : MonoBehaviour {
	
	public Animator towerAnim; //animation
	public GameObject tower;
                            
	public bool isDead;  // Whether the tower is dead.


	void Start () {
		// Get player and components 
		towerAnim = GetComponent<Animator>();
	}
		
	void Update () {}

	void Death ()
	{
		// Set the death flag so player can disregaurd collisions
		isDead = true;

		// Tell the animator that the tower is dead.
		towerAnim.Play("BlowUp");

		// Turn off the movement and shooting scripts.
		Destroy(tower, 2f);
	}  

	void OnTriggerEnter(Collider other)
	{
		// If the tower is not dead
		if (!isDead) {
			
			// Call to destroy the tower
			Death ();

			// Call destroy on object that hit the tower
			if (other.name == "Fireball(Clone)") {
				Destroy (other.gameObject, 0f);
			}
		}
	}
}
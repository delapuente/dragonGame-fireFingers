using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

	// Map Section to be initialized 
	public Transform mapSection;

	// Enemies (catapult, tower)
	public Transform[] enemies;

	public float zMapSectionPosition = 16;

	void Start(){}

	void Update(){
		//----------- Instantiate the next piece of the map every update -------------
		if (zMapSectionPosition < Constants.totalLengthOfLevel) {
			Spawn ();
		}
	}

	void Spawn(){
		// Variable for saving parent map section
		Transform map;

		// Place the next piece of the map down
		map = Instantiate (mapSection, new Vector3 (0, 0, zMapSectionPosition), mapSection.rotation) as Transform;

		// Loop over the three back spots on the map section
		for (int i = 0; i < 3; i++) {

			// If chance of placing enemy is true
			if (Random.Range (0, 100) <= Constants.chanceOfEnemyPlacement) {

				Debug.Log("Creating an enemy");
	
				// Place random enemy
				Transform enemy = Instantiate (
					enemies[Random.Range(0, enemies.Length)],
					new Vector3 ( // position
						(i-1), // -1, 0, 1 the center of the lanes
						Constants.towerInstatiationYOffset, 
						(zMapSectionPosition + Constants.towerInstatiationZOffset)
					),
					Quaternion.Euler(new Vector3(0, 89.566f, 0)) // rotation
					//map // parent
				) as Transform;

				enemy.SetParent(map);
			}

		}

		// Update map section position
		zMapSectionPosition += Constants.mapSectionDepth;
	}
}
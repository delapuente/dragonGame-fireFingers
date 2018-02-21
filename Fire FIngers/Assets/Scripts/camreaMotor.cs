using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camreaMotor : MonoBehaviour {
	private Transform lookAt;
	private Vector3 startOffSet;
	private Vector3 moveVector;

	//for animation at the begining
	private float transition = 0.0f;
	private float animationDuration = 2.0f;
	private Vector3 animationOffSet = new Vector3 (0, 5, 5);

	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffSet = transform.position - lookAt.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		moveVector = lookAt.position + startOffSet;
		//locking camrea
		//x
		moveVector.x = 0;
		//y --- for hills exc.
		//moveVector.y = Mathf.Clamp(moveVector.y,3,5);
		//z
		transform.position = moveVector;
	}
}

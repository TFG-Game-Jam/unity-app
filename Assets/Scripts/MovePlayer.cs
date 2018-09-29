using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class MovePlayer : MonoBehaviour {

	public float x_input = 0;
	public bool left;
	public bool right;
	public int speed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		left = Networking.playerActions.port;
		right = Networking.playerActions.starboard;

		if (left) {
			x_input = -1;
		}
		else if (right) {
			x_input = 1;
		}
		else {
			x_input = 0;
		}
		
        Vector3 movement = new Vector3 (x_input, 0.0f, 0.0f);
        GetComponent<Rigidbody> ().velocity = movement * speed;
	}
}

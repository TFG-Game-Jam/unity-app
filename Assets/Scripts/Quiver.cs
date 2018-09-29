using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiver : MonoBehaviour {
	public GameObject arrowPrefab;


	private GameObject _heldLaser;

	private void AllignLaser(GameObject laser) {
		_heldLaser = laser;
		
		// make a child of this object
		_heldLaser.transform.SetParent(transform, false);
		_heldLaser.transform.localPosition = new Vector3(0, 0, 1);
		_heldLaser.transform.localEulerAngles = new Vector3(90, 0, 0);
	}

	private void ReleaseLaser(GameObject laser) {
		// change the parent to the world
		laser.transform.SetParent(null, true);
		laser = null;
	}

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {

  	// listen for click events
  		if (GvrControllerInput.ClickButtonDown) {
    	ShootLasers();
  		}
	}

	private void ShootLasers() {
		GameObject laser =  Instantiate(arrowPrefab);
		AllignLaser(laser);
		ReleaseLaser(laser);
		Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
		laserRigidbody.isKinematic = false;
		laserRigidbody.AddRelativeForce( (new Vector3(0, 1, 0)) * 10, ForceMode.VelocityChange);
	}
}

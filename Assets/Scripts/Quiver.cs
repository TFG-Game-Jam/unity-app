using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Quiver : MonoBehaviour {
	public GameObject arrowPrefab;

	private GameObject _heldLaser;

	private void AllignLaser(GameObject laser) {
		_heldLaser = laser;
				
		// make a child of this object
		_heldLaser.transform.SetParent(transform, false);
		_heldLaser.transform.localPosition = new Vector3(0, 0, 0);
        float y_ang = _heldLaser.transform.eulerAngles.y;
        _heldLaser.transform.eulerAngles = new Vector3(90, y_ang, 0);
		
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
	  	bool available_ammo = Networking.playerActions.loadCyan || Networking.playerActions.loadGreen || Networking.playerActions.loadPurple|| Networking.playerActions.loadWhite;
  		if (GvrControllerInput.ClickButtonDown && available_ammo) {
			Networking.shot = true;
    		ShootLasers();
  		}
		// if(!available_ammo){
		// 	DoBeep();
		// }
	}

	private void ShootLasers() {

		GameObject laser =  Instantiate(arrowPrefab);

		bool loadWhite = Networking.playerActions.loadWhite;
		bool loadGreen = Networking.playerActions.loadGreen;
		bool loadCyan = Networking.playerActions.loadCyan;
		bool loadPurple = Networking.playerActions.loadPurple;

		if (loadWhite) {
			laser.GetComponent<Renderer> ().material.color = new Color(1, 1, 1, 1); // white
		}
		else if (loadGreen) {
			laser.GetComponent<Renderer> ().material.color = new Color(0, 1, 0, 1); // green
		}
		else if (loadCyan) {
			laser.GetComponent<Renderer> ().material.color = new Color(0, 1, 1, 1); //cyan
		}
		else if (loadPurple) {
			laser.GetComponent<Renderer> ().material.color = new Color(1, 0, 1, 1); // purple (magenta)
		}
		
		AllignLaser(laser);
		ReleaseLaser(laser);
		Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
		laserRigidbody.isKinematic = false;
		laserRigidbody.useGravity = false;
		laserRigidbody.AddRelativeForce( (new Vector3(0, 1, 0)) * 60, ForceMode.VelocityChange);
	}
}

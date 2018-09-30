using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

	public GameObject ShotPrefab;
	private GameObject _heldLaser;

	float SHOT_PROB = 0.0005f;

	void FixedUpdate () {
		if (Random.value > 1.0f - SHOT_PROB){
			FireShot(ShotPrefab);
		}	
	}

	void FireShot (GameObject shot){
		GameObject player = GameObject.Find("Player");
		GameObject laser =  Instantiate(shot);
		laser.transform.position = GetComponent<Rigidbody>().position;
		AllignShot(laser);

		Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
		laserRigidbody.isKinematic = false;
		laserRigidbody.useGravity = false;

		Vector3 stt = player.transform.position;
		Vector3 tgt = laser.transform.position;

		Vector3 direction = (stt - tgt).normalized;
		
		laserRigidbody.AddForce(direction * 10, ForceMode.VelocityChange);
		// laser.GetComponent<Rigidbody> ().MovePosition(stt + direction * 60 * Time.deltaTime);
	}

	private void ReleaseShot(GameObject laser) {
		// change the parent to the world
		laser.transform.SetParent(null, true);
		laser = null;
	}

	private void AllignShot(GameObject laser) {
		laser.transform.eulerAngles = new Vector3 (90, 0, 0);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
	
	void OnCollisionEnter (Collision col)
    {
		Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag == "enemy"){
			Debug.Log("Enemy collision!");
		}
		Destroy(col.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject invaderPrefab;
	
	// Use this for initialization
	void Start () {
		float X_BOUND = 20;
		float BLOCK_H  = 3;
		float BLOCK_W  = 3;
		float MAX_Z = 120;

		float z = MAX_Z;
		for(int i = 0; i < BLOCK_H; i++){
			float x = X_BOUND;
			for (int j = 0; j < BLOCK_W; j++){
				GameObject invader = Instantiate(invaderPrefab);
				invader.transform.position = new Vector3(x, 0, z);
				
				x -= 2*X_BOUND/(BLOCK_W-1);
			}
			z -= 2*X_BOUND/(BLOCK_W-1);
		}
		
	}
	
	// // Update is called once per frame
	// void Update () {
		
	// }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour {

	void OnCollisionEnter (Collision col)
    {
			Color projectileColor = this.gameObject.GetComponent<Renderer> ().material.color;
			
			Destroy(this.gameObject);
			if (col.gameObject.tag == "enemy"){
				Color enemyColor = col.gameObject.GetComponent<Renderer> ().material.color;
				if (projectileColor == enemyColor) {
					Destroy(col.gameObject);
				}
			}
    }
}

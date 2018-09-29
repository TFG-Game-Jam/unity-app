using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour {

	void OnCollisionEnter (Collision col)
    {
			Destroy(this.gameObject);
			if (col.gameObject.tag == "enemy"){
				Destroy(col.gameObject);
			}
    }
}

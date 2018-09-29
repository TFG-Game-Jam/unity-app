using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColision : MonoBehaviour {

	void OnCollisionEnter (Collision col)
    {
		Destroy(col.gameObject);
		Destroy(this.gameObject);
    }
}

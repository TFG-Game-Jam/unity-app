using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiver : MonoBehaviour {
	public GameObject arrowPrefab;


	private GameObject _heldArrow;

	private void HoldArrow(GameObject arrow) {
	_heldArrow = arrow;

	// make a child of this object
	_heldArrow.transform.SetParent(transform, false);
	_heldArrow.transform.localPosition = new Vector3(0, 0, 1);
	_heldArrow.transform.localEulerAngles = new Vector3(90, 0, 0);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {

  	// listen for click events
  		if (GvrControllerInput.ClickButtonDown) {
    	CreateArrow();
  		}
	}

	private void CreateArrow() {
	Instantiate(arrowPrefab);
	}
}

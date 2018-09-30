using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour{
	int cont = 0;
	void Update ()
	{
		cont +=1;
		if (cont > 1000){
			SceneManager.LoadScene("ship_shot_translate", LoadSceneMode.Single);
		}
	}
}

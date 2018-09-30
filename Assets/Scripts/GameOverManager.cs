using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour{
	
	void Update ()
	{
		if(Networking.playerActions.roomState[0] == 2 && Networking.playerActions.roomState[1] == 2 && Networking.playerActions.roomState[2] == 2){
			Networking.playerActions.roomState[0] = 0;
			SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
			// Application.LoadLevel(Application.loadedLevel);
		}
	}
}

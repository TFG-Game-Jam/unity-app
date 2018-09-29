using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeComputerUV : MonoBehaviour {
	const int ROOM_COUNT = 1;
	Texture2D[] textures = new Texture2D[2 * ROOM_COUNT + 1];
	int counter = 0;
	int currentRoom = 0;
	int[] roomStatus = new int[ROOM_COUNT]{0};

	IEnumerator Start () {
		string[] textureFiles = new string[] {
			"UVs/Monitor/PropulsionWarning.png",
			"UVs/Monitor/PropulsionError.png",
			"UVs/Monitor/AllOK.png",
		};
		for (int i = 0; i < textureFiles.Length; i++) {
        	textures[i] = new Texture2D(4, 4, TextureFormat.DXT1, false);
			using (WWW www = new WWW(localPathToUri(textureFiles[i])))
			{
				yield return www;
				www.LoadImageIntoTexture(textures[i]);
			}
		}
		setRoomStatus(Room.PROPULSION, 1);
	}

	string localPathToUri(string path) {
		String fullPath = Application.dataPath + "/" + path;
		UriBuilder uriBuilder = new UriBuilder(fullPath);
		uriBuilder.Scheme = "file";
		string s = uriBuilder.ToString();
		Debug.Log(s);
		return s;
	}

	void FixedUpdate() {
		counter++;
		if (counter >= 80) {
			counter = 0;
			updateRoom();
		}
    }

	void updateRoom() {
		for (int i = (currentRoom + 1) % ROOM_COUNT; i != currentRoom; i = (i + 1) % ROOM_COUNT) {
			if (roomStatus[i] != 0) {
				currentRoom = i;
				break;
			}
		}
		GetComponent<Renderer>().material.mainTexture = roomStatus[currentRoom] == 0 ? textures[2 * ROOM_COUNT] :
			(roomStatus[currentRoom] == 1 ? textures[2 * currentRoom] : textures[2 * currentRoom + 1]);
	}

	void setRoomStatus(Room room, int status) {
		roomStatus[(int)room] = status;
	}
}

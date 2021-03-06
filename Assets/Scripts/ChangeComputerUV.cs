﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeComputerUV : MonoBehaviour {
	public Texture2D[] textures;

	const int ROOM_COUNT = 3;
	int counter = 0;
	int currentRoom = 0;

	void FixedUpdate() {
		counter++;
		if (counter >= 80) {
			counter = 0;
			updateRoom();
		}
    }

	void updateRoom() {
		for (int i = (currentRoom + 1) % ROOM_COUNT; i != currentRoom; i = (i + 1) % ROOM_COUNT) {
			if (Networking.playerActions.roomState[i] != 0) {
				currentRoom = i;
				break;
			}
		}
		GetComponent<Renderer>().material.mainTexture = Networking.playerActions.roomState[currentRoom] == 0 ? textures[2 * ROOM_COUNT] :
			(Networking.playerActions.roomState[currentRoom] == 1 ? textures[2 * currentRoom] : textures[2 * currentRoom + 1]);
	}
}

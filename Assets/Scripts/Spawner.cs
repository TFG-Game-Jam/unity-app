using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject invader1;
    public GameObject invader2;
    public GameObject invader3;
    public GameObject invader4;

    void Start()
    {
        float X_BOUND = 20;
        float BLOCK_H = 3;
        float BLOCK_W = 3;
        float MAX_Z = 120;
        Debug.Log("Started");
        float z = MAX_Z;
        for (int i = 0; i < BLOCK_H; i++)
        {
            float x = X_BOUND;
            for (int j = 0; j < BLOCK_W; j++)
            {
                GameObject invader;

                if ((i % 2 == 0) && (j % 2 == 0)) {
                    Debug.Log("i1");
                    invader = Instantiate(invader1);
                }
                else if ((i % 2 == 1) && (j % 2 == 1)) {
                    Debug.Log("i2");
                    invader = Instantiate(invader2);
                }
                else if ((i % 2 == 1) && (j % 2 == 0)) {
                    Debug.Log("i3");
                    invader = Instantiate(invader3);
                }
                else {
                    Debug.Log("i4");
                    invader = Instantiate(invader4);
                }

                invader.transform.position = new Vector3(x, 0, z);

                x -= 2 * X_BOUND / (BLOCK_W - 1);
            }
            z -= 2 * X_BOUND / (BLOCK_W - 1);
        }

    }
}

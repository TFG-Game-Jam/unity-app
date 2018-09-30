using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject invader1;
    public GameObject invader2;
    public GameObject invader3;
    public GameObject invader4;

    public static int wave = 2;

    void Generate_Wave(float BLOCK_H, float BLOCK_W){
        float MAX_Z = 120;
        float z = MAX_Z;
        float X_BOUND = 20;
        
    
        for (int i = 0; i < BLOCK_H; i++)
        {
            float x = X_BOUND;
            for (int j = 0; j < BLOCK_W; j++)
            {
                GameObject invader;

                if ((i % 2 == 0) && (j % 2 == 0)) {
                    invader = Instantiate(invader1);
                }
                else if ((i % 2 == 1) && (j % 2 == 1)) {
                    invader = Instantiate(invader2);
                }
                else if ((i % 2 == 1) && (j % 2 == 0)) {
                    invader = Instantiate(invader3);
                }
                else {
                    invader = Instantiate(invader4);
                }

                invader.transform.position = new Vector3(x, 0, z);

                x -= 2 * X_BOUND / (BLOCK_W - 1);
            }
            z -= 2 * X_BOUND / (BLOCK_W - 1);
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("enemy").Length == 0) {
            Generate_Wave(wave,wave);
            wave++;
        }
    }
}

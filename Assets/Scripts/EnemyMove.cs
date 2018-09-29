using UnityEngine;
using System.Collections;

// [System.Serializable]
// public class MovementLimits
// {
//     public float xMin, xMax, zMin, zMax;
// }

public class EnemyMove : MonoBehaviour
{
    float X_SPD = 3;
    float Y_SPD = 1;
    float SPD = 4;
    float ACC = 1.05f; //acceleration factor
    int TIME_HORIZ = 200;
    int TIME_VERT = 100;
    
    
    float x_speed = 0;
    float y_speed = 0;
    int time = 100;
    int dir = 0;            //0 1 2 3

    void FixedUpdate ()     //L U R U
    {
        if (dir == 0){
            x_speed = X_SPD;
            y_speed = 0;
        } 

        if (dir == 1){
            x_speed = 0;
            y_speed = -Y_SPD;
        }

        if (dir == 2){
            x_speed = -X_SPD;
            y_speed = 0;
        }

        if (dir == 3){
            x_speed = 0;
            y_speed = -Y_SPD;
        }
        
        time--;

        if (time == 0){
            dir = (dir+1)%4;
            if (dir == 1 || dir == 3){
                time = TIME_VERT;
                SPD *= ACC;
                TIME_HORIZ = (int) (TIME_HORIZ / ACC);
                TIME_VERT = (int) (TIME_VERT / ACC);
            }
            if (dir == 0 || dir == 2){
                time = TIME_HORIZ;
            }
        }


        Vector3 movement = new Vector3 (x_speed, 0.0f, y_speed);
        GetComponent<Rigidbody> ().velocity = movement * SPD;
    }
}
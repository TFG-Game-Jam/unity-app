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

    bool crossedPlayer = false;

    void FixedUpdate ()     //L U R U
    {
        if (GetComponent<Rigidbody> ().position.z < 5.0f || crossedPlayer){
            SPD *= 1.04f;
            crossedPlayer = true;
            GameObject player = GameObject.Find("Player");
            Vector3 tgt = player.transform.position;
            Vector3 stt = GetComponent<Rigidbody> ().position;
            Vector3 direction = (tgt - stt).normalized;
            GetComponent<Rigidbody> ().MovePosition(stt + direction * SPD * Time.deltaTime);

            // time = TIME_HORIZ;
            // if (!crossedPlayer){ 
            //     if (dir == 1){
            //         x_speed = -X_SPD;
            //     }

            //     if (dir == 3){
            //         x_speed = X_SPD;
            //     }
            //     crossedPlayer = true;
            // }

            // else{
            //     if (time == 0){
            //         time = TIME_HORIZ;
            //         x_speed *= -1;
            //     }
            //     Vector3 oscil = new Vector3 (x_speed, 0.0f, 0.0f);
            //     GetComponent<Rigidbody> ().velocity = oscil * SPD;
            // }
            // time--;
            
        }

        else{
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

        }
        Vector3 movement = new Vector3 (x_speed, 0.0f, y_speed);
        GetComponent<Rigidbody> ().velocity = movement * SPD;

    }
}
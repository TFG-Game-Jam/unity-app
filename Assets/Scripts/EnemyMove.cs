using UnityEngine;
using System.Collections;

// [System.Serializable]
// public class MovementLimits
// {
//     public float xMin, xMax, zMin, zMax;
// }

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float x_speed;
    public float y_speed;

    void FixedUpdate ()
    {

        Vector3 movement = new Vector3 (x_speed, 0.0f, y_speed);
        GetComponent<Rigidbody> ().velocity = movement * speed;

    }
}
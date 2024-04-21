using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private float speed = 4.0f;
    public void MoveCannon(Vector2 move)
    {
        Vector3 change = Time.deltaTime * new Vector3(move.x, 0, move.y) * speed;
        transform.position += change;
        transform.LookAt(transform.position + change);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public float lerpParameter;
    public bool movingRight;
    public int health;
    void Update()
    {
        lerpParameter += Time.deltaTime * speed;

        if(movingRight)
        {
            transform.position = Vector3.Lerp(waypoints[0].position, waypoints[1].position, lerpParameter);
        }
        else
        {
            transform.position = Vector3.Lerp(waypoints[1].position, waypoints[0].position, lerpParameter);
        }

        if(lerpParameter >= 1)
        {
            movingRight = !movingRight;
            lerpParameter = 0f;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) 
            Destroy(gameObject);

    }
}

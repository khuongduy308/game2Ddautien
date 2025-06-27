using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Vector3 movementDirection;
    void Start()
    {
        Destroy(gameObject, 5f); // Destroy the bullet after 5 seconds to prevent memory leaks
    }

    void Update()
    {
        if (movementDirection == Vector3.zero) return;
        transform.position += movementDirection * Time.deltaTime;
    }
    
    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }
}

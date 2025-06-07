using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Enemy
{
    [SerializeField] private GameObject explosionPrefabs;
    private void createExplosion()
    {
        if(explosionPrefabs != null)
        {
            Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
        }
    }
    protected override void Die()
    {
        createExplosion(); // Create explosion effect when this enemy dies
        base.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                createExplosion(); // Create explosion effect when colliding with player;
            }
        }
    }
}

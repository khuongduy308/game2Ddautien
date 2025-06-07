using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damageForPlayer = 30f;
    [SerializeField] private float damageForEnemy = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(damageForPlayer);
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            if (enemy != null)
            {
                enemy.TakeDame(damageForEnemy);
            }
        }
    }
    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}

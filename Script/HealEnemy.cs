using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealEnemy : Enemy
{
    [SerializeField] private float healValue = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDame(stayDamage);
            }
        }
    }
    protected override void Die()
    {
        Heal(); // Heal the player when this enemy dies
        base.Die();
    }
    private void Heal()
    {
        if (player != null)
        {
            player.Heal(healValue);
        }
    }
}

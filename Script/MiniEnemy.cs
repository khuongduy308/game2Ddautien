using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDame(enterDamage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDame(stayDamage);
        }
    }
}

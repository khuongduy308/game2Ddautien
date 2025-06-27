using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameManager gameManager;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.TakeDame(10f);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Usb"))
        {
            gameManager.WinGame();
        }
        else if (collision.CompareTag("Energy"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddEnergy();
            audioManager.EnergyAudio();
            Destroy(collision.gameObject);
        }
    }
}

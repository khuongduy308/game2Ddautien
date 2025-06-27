using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedDanThuong = 20f;
    [SerializeField] private float speedDanVongTron = 10f;
    [SerializeField] private float hoiMauBoss = 100f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 10f; // Thời gian chờ giữa các lần bắn
    private float skillTimer = 0f;
    [SerializeField] private GameObject Usb;

    protected override void Update()
    {
        base.Update();
        if (Time.time >= skillTimer)
        {
            HoiSkill();
        }

    }

    protected override void Die()
    {
        Instantiate(Usb, transform.position, Quaternion.identity);
        base.Die();
    }
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

    private void BanDanThuong()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            Debug.Log("Da co dan thuong");
            enemyBullet.SetMovementDirection(directionToPlayer * speedDanThuong);
        }
    }

    private void BanDanVongTron()
    {
        const int numberOfBullets = 12; // Số lượng viên đạn trong vòng tròn
        float angle = 360f / numberOfBullets;
        for (int i = 0; i < numberOfBullets; i++)
        {
            float currentAngle = i * angle * Mathf.Deg2Rad; // Chuyển đổi góc sang radian
            Vector3 bulletDirection = new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle), 0);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection * speedDanVongTron);
        }
    }

    private void HoiMau(float hpAmount)
    {
        currentHP = Mathf.Min(currentHP + hpAmount, maxHP);
        UpdateHpBar();
        Debug.Log("da hoi" + hpAmount + "mau");
    }

    private void SinhMiniEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }

    private void DichChuyen()
{
    if (player != null)
    {
        float distanceToPlayer = 2f; // khoảng cách muốn giữ với người chơi
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position = player.transform.position - direction * distanceToPlayer;
    }
}
    private void ChonSkill()
    {
        int randomSkill = UnityEngine.Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                HoiMau(hoiMauBoss);
                break;
            case 3:
                SinhMiniEnemy();
                break;
            case 4:
                DichChuyen();
                break;
        }
        Debug.Log("Da chon skill số " + randomSkill + " cho boss");
    }
    private void HoiSkill()
    {
        skillTimer = Time.time + skillCooldown;
        ChonSkill();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gun : MonoBehaviour
{
    private float rotateOffset = 180f;

    //các biến liên quan đến bắn viên đạn 
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shotDelay = 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmmo = 24;
    [SerializeField] public TextMeshProUGUI ammoText;
    public int currentAmmo;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Shoot();
        ReLoad();
    }
    void RotateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }

        //xử lý lấy tọa độ con trỏ chuột để xoay súng
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - rotateOffset);

        //xử lý súng bị lật ngược
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmoText();
        }
    }
    void ReLoad()
    {
        if (Input.GetMouseButtonDown(1) && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            UpdateAmmoText();
        }
    }
    private void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo.ToString();
        }
    }
}

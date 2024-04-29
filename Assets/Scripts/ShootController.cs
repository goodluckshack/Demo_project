using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private float _reloadTime = 1f;

    private float _lastShotTime;
    private Button _shootButton;

    void Start()
    {
        _shootButton = GetComponent<Button>();
        _lastShotTime = -_reloadTime;
    }

    void Update()
    {
        if (Time.time - _lastShotTime > _reloadTime)
        {
            _shootButton.interactable = true;
            _shootButton.image.color = Color.green;
        }
        else
        {
            _shootButton.interactable = false;
            _shootButton.image.color = Color.red;
        }
    }

    public void Shoot()
    {
        if (Time.time - _lastShotTime > _reloadTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.up * _bulletSpeed;

            _lastShotTime = Time.time;
        }
    }

    public void OnButtonPress()
    {
        Shoot();
    }
}

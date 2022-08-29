using ProjectileMVC;
using UnityEngine;
using Interfaces;
using Enums;

public class PlayerController : MonoBehaviour,IDamagable
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private int firePerSecond;
    [SerializeField] private ProjectileType projectileType;

    private float fireRate;
    private float canFire;

    private void Awake()
    {
        fireRate = 1 / firePerSecond;
    }

    private void FixedUpdate()
    {
        MoveNRotate();
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void MoveNRotate()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.Translate(0f, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }

    private void Shoot()
    {
        if (canFire < Time.time)
        {
            ProjectileService.Instance.CreateNewProjectile(projectileType, shootingPosition);
            canFire = fireRate + Time.time;
        }
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
    }
}
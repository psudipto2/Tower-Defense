using ProjectileMVC;
using UnityEngine;
using Interfaces;
using Common;
using TMPro;
using Enums;

public class PlayerController : MonoBehaviour,IDamagable
{
    [SerializeField] private float speed;
    [SerializeField] private int health;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private int firePerSecond;
    [SerializeField] private ProjectileType projectileType;
    [SerializeField] private ProjecileOrigin projecileOrigin;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI bulletsFiredText;

    private float fireRate;
    private float canFire;
    private int bulletsFired;

    private void Start()
    {
        DisplayHealth();
        DisplayBulletsFired();
    }
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
        if (Input.GetKeyDown(KeyCode.RightShift))
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
            bulletsFired += 1;
            DisplayBulletsFired();
        }
    }
    public void TakeDamage(int damage,ProjecileOrigin projecileOrigin)
    {
        if (this.projecileOrigin == projecileOrigin)
        {
            damage = 0;
        }
        health = health - damage;
        if (health <= 0)
        {
            health = 0;
            PopUpController.Instance.DisplayLosePopUp();
            Destroy(this.gameObject);
        }
        DisplayHealth();
    }
    public void DisplayHealth()
    {
        healthText.text = "Health: " + health.ToString();
    }
    public void DisplayBulletsFired()
    {
        bulletsFiredText.text = "Bullets Fired: " + bulletsFired.ToString();
    }
}
using UnityEngine;
using Interfaces;
using TMPro;

namespace TowerMVC
{
    public class TowerView : MonoBehaviour, IDamagable
    {
        [HideInInspector] public int health;
        [HideInInspector] public int bulletsFired = 0;
        [HideInInspector] public Vector3 scale;

        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI bulletsFiredText;

        public TowerController towerController;
        public Transform shootingPosition;
        public GameObject target;

        private bool attacking;

        private void Start()
        {
            this.transform.localScale = scale;
            attacking = false;
            DisplayHealth();
            DisplayBulletsFired();
        }

        private void FixedUpdate()
        {
            towerController.Shooting();
        }

        public void TakeDamage(int damage)
        {
            towerController.ApplyDamage(damage);
        }
        public void DestroyTower()
        {
            Destroy(this.gameObject);
            this.towerController.towerModel = null;
            this.towerController = null;
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
}
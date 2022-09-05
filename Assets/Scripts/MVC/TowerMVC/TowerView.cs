using UnityEngine;
using Interfaces;
using TMPro;
using Enums;

namespace TowerMVC
{
    public class TowerView : MonoBehaviour, IDamagable
    {
        [HideInInspector] public int health;
        [HideInInspector] public int bulletsFired = 0;
        [HideInInspector] public Vector3 scale;

        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI bulletsFiredText;

        private TowerController towerController;
        public Transform shootingPosition;
        public GameObject target;

        public void SetTowerController(TowerController _towerController)
        {
            towerController = _towerController;
        }

        private void Start()
        {
            this.transform.localScale = scale;
            DisplayHealth();
            DisplayBulletsFired();
        }

        private void FixedUpdate()
        {
            towerController.Shooting();
        }

        public void TakeDamage(int damage,ProjecileOrigin projecileOrigin)
        {
            towerController.ApplyDamage(damage,projecileOrigin);
        }
        public void DestroyTower()
        {
            Destroy(this.gameObject);
            TowerService.Instance.RemoveTower(towerController);
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
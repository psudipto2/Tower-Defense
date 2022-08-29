using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace TowerMVC
{
    public class TowerView : MonoBehaviour, IDamagable
    {
        [HideInInspector] public int health;
        [HideInInspector] public Vector3 scale;

        public TowerController towerController;
        public Transform shootingPosition;
        public GameObject target;

        private bool attacking;
        private Coroutine shoot;

        private void Start()
        {
            this.transform.localScale = scale;
            attacking = false;
        }

        private void Update()
        {
            CheckAttackingStatus();
        }

        private void CheckAttackingStatus()
        {
            if (!attacking)
            {
                if (checkTargetInRange())
                {
                    EnableAttack();
                }
            }
        }

        private bool checkTargetInRange()
        {
            return towerController.checkTargetInAttackRange();
        }

        private void EnableAttack()
        {
            attacking = true;
            Debug.Log(towerController.towerModel.name);
            shoot = StartCoroutine(towerController.Shooting());
        }

        public void DisableAttack()
        {
            attacking = false;
            StopCoroutine(towerController.Shooting());
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
    }

}
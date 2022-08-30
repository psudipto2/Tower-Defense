using ProjectileMVC;
using UnityEngine;

namespace TowerMVC
{
    public class TowerController
    {
        public TowerModel towerModel;

        private TowerView towerView;
        private float distanceFromTarget;
        private float angleFromTarget;
        private float fireRate;
        private float canFire;


        public TowerController(TowerModel towerModel, TowerView towerView)
        {
            this.towerModel = towerModel;
            this.towerView = towerView;
            this.towerView.scale = towerModel.scale;
            this.towerView.SetTowerController(this);
            this.towerView.health = towerModel.health;
            fireRate = 1 / towerModel.firePerSecond;
        }

        public bool checkTargetInAttackRange()
        {
            Vector3 targetDistance = (towerView.target.transform.position - towerView.transform.position).normalized;
            Quaternion angle = Quaternion.LookRotation(new Vector3(targetDistance.x, 0, targetDistance.z));
            distanceFromTarget = Vector3.Distance(towerView.target.transform.position, towerView.transform.position);
            angleFromTarget = angle.y * 100;
            if (angleFromTarget < 0)
            {
                angleFromTarget = angleFromTarget * -1;
            }
            if ((distanceFromTarget < towerModel.attackRadius) && (angleFromTarget < towerModel.attackAngle))
            {
                return true;
            }
            return false;
        }
        protected void faceTarget()
        {
            Vector3 direction = (towerView.target.transform.position - towerView.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            towerView.transform.rotation = Quaternion.Slerp(towerView.transform.rotation, lookRotation, Time.deltaTime * 100f);
        }

        public void Shooting()
        {
            if ((canFire < Time.time) && (checkTargetInAttackRange()))
            {
                faceTarget();
                ProjectileService.Instance.CreateNewProjectile(towerModel.projectileType, towerView.shootingPosition);
                canFire = fireRate + Time.time;
                towerView.bulletsFired += 1;
                towerView.DisplayBulletsFired();
            }
        }

        public void ApplyDamage(int damage,ProjecileOrigin projecileOrigin)
        {
            if (towerModel.projecileOrigin == projecileOrigin)
            {
                damage = 0;
            }
            towerView.health = towerView.health - damage;
            if (towerView.health <= 0)
            {
                towerView.health = 0;
                towerView.DestroyTower();
            }
            towerView.DisplayHealth();
        }
    }
}
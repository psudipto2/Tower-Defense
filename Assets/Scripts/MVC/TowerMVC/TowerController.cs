using System.Collections;
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
        private Coroutine shoot;
        private float fireRate;

        public TowerController(TowerModel towerModel, TowerView towerView)
        {
            this.towerModel = towerModel;
            this.towerView = towerView;
            this.towerView.scale = towerModel.scale;
            this.towerView.towerController = this;
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

        public IEnumerator Shooting()
        {
            towerView.transform.LookAt(towerView.target.transform.position);
            ProjectileService.Instance.CreateNewProjectile(towerModel.projectileType,towerView.shootingPosition);
            yield return new WaitForSeconds(fireRate);
            if (!checkTargetInAttackRange())
            {
                towerView.DisableAttack();
            }
        }

        public void ApplyDamage(int damage)
        {
            towerView.health = towerView.health - damage;
            if (towerView.health <= 0)
            {
                towerView.health = 0;
                towerView.DestroyTower();
            }
        }
    }
}

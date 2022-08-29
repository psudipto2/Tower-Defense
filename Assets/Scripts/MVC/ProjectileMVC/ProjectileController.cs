using UnityEngine;
using Interfaces;

namespace ProjectileMVC
{
    public class ProjectileController
    {
        private ProjectileModel projectileModel;
        private ProjectileView projectileView;
        private Rigidbody rigidbody;

        public ProjectileController(ProjectileModel projectileModel,ProjectileView projectileView)
        {
            this.projectileModel = projectileModel;
            this.projectileView = GameObject.Instantiate(projectileView, projectileModel.shootingPosition.position, projectileModel.shootingPosition.rotation);
            projectileView.projectileController = this;
            rigidbody = projectileView.GetComponent<Rigidbody>();
            rigidbody.AddForce(projectileView.transform.forward * projectileModel.speed);
        }

        public void Enable(Transform shootingPosition)
        {
            projectileView.transform.position = shootingPosition.position;
            projectileView.transform.rotation = shootingPosition.rotation;
            projectileView.Enable();
            rigidbody.AddForce(projectileView.transform.forward * projectileModel.speed);
        }

        public void ApplyDamage(GameObject damagableObject)
        {
            IDamagable damagable = damagableObject.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(projectileModel.damage);
            }
            projectileView.Disable();
        }

        public void ReturnProjectile()
        {
            ProjectileService.Instance.ReturnProjectileToPool(this);
        }
    }
}
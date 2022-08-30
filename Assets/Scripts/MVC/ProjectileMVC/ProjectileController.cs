using UnityEngine;
using Interfaces;

namespace ProjectileMVC
{
    public class ProjectileController
    {
        public ProjectileModel projectileModel;
        private ProjectileView projectileView;
        private Rigidbody rigidbody;

        public ProjectileController(ProjectileModel projectileModel,ProjectileView projectileView)
        {
            this.projectileModel = projectileModel;
            this.projectileView = GameObject.Instantiate(projectileView, projectileModel.shootingPosition.position, projectileModel.shootingPosition.rotation);
            this.projectileView.projectileController = this;
            this.projectileView.renderer.material = projectileModel.material;
            rigidbody = this.projectileView.GetComponent<Rigidbody>();
            rigidbody.AddForce(this.projectileView.transform.forward * this.projectileModel.speed, ForceMode.Impulse);
        }

        public void ApplyDamage(GameObject damagableObject)
        {
            IDamagable damagable = damagableObject.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(projectileModel.damage,projectileModel.projecileOrigin);
            }
            projectileView.Disable();
        }
    }
}
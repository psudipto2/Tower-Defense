using UnityEngine;

namespace ProjectileMVC
{
    public class ProjectileView : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public ProjectileController projectileController;
        public MeshRenderer renderer;

        private void OnTriggerEnter(Collider other)
        {
            if (projectileController != null)
            {
                projectileController.ApplyDamage(other.gameObject);
            }
           
        }

        public void Disable()
        {
            Destroy(this.gameObject);
            projectileController.projectileModel = null;
            projectileController = null;
        }
    }
}
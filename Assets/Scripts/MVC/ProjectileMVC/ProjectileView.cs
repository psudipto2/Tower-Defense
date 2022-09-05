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

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            projectileController.ReturnProjectile();
        }
    }
}
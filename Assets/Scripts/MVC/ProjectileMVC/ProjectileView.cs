using UnityEngine;

namespace ProjectileMVC
{
    public class ProjectileView : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public ProjectileController projectileController;

        private void Start()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }

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
            projectileController.ReturnProjectile();
            gameObject.SetActive(false);
        }
    }
}
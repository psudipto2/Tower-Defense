using ProjectileSO;
using UnityEngine;
using Enums;

namespace ProjectileMVC
{
    public class ProjectileModel
    {
        public ProjectileType projectileType;
        public int damage;
        public float speed;
        public Material material;
        public Transform shootingPosition;

        public ProjectileModel(ProjectileScriptableObject projectile,Transform shootingPosition)
        {
            this.projectileType = projectile.projectileType;
            this.damage = projectile.damage;
            this.speed = projectile.damage;
            this.material = projectile.material;
            this.shootingPosition = shootingPosition;
        }
    }
}

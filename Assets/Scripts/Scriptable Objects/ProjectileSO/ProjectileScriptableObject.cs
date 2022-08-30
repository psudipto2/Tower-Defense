using ProjectileMVC;
using UnityEngine;
using Enums;

namespace ProjectileSO
{
    [CreateAssetMenu(fileName ="Projectile Scriptable Object",menuName ="Scriptable Objects/Projectile/New Projectile Scriptable Object")]
    public class ProjectileScriptableObject : ScriptableObject
    {
        public ProjectileType projectileType;
        public ProjecileOrigin projecileOrigin;
        public ProjectileView projectileView;
        public int damage;
        public float speed;
        public Material material;
    }
}


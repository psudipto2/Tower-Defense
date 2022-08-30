using UnityEngine;

namespace ProjectileSO
{
    [CreateAssetMenu(fileName = "Projectile Scriptable Object List", menuName = "Scriptable Objects/Projectile/New Projectile Scriptable Object List")]
    public class ProjectileScriptableObjectList : ScriptableObject
    {
        public ProjectileScriptableObject[] projectiles;
    }
}


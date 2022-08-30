using UnityEngine;
using TowerSO;
using Enums;

namespace TowerMVC
{
    public class TowerModel
    {
        public int health;
        public int firePerSecond;
        public float attackAngle;
        public float attackRadius;
        public Vector3 scale;
        public ProjectileType projectileType;
        public ProjecileOrigin projecileOrigin;
        public string name;

        public TowerModel(TowerScriptableObject tower)
        {
            this.health = tower.health;
            this.firePerSecond = tower.firePerSecond;
            this.attackAngle = tower.attackAngle;
            this.attackRadius = tower.attackRadius;
            this.scale = tower.scale;
            this.projectileType = tower.projectileType;
            this.projecileOrigin = tower.projecileOrigin;
            this.name = tower.name;
        }
    }
}

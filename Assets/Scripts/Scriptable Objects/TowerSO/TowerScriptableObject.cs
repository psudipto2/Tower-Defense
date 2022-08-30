using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

namespace TowerSO
{
    [CreateAssetMenu(fileName ="Tower Scriptable Object",menuName ="Scriptable Objects/Tower/New TowerScriptable Object")]
    public class TowerScriptableObject : ScriptableObject
    {
        public int health;
        public int firePerSecond;
        public float attackAngle;
        public float attackRadius;
        public Vector3 scale;
        public ProjectileType projectileType;
        public ProjecileOrigin projecileOrigin;
    }
}

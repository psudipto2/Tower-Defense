using UnityEngine;

namespace TowerSO
{
    [CreateAssetMenu(fileName ="Tower Scriptable Object List",menuName ="Scriptable Objects/Tower/New Tower Scriptable Object List")]
    public class TowerScriptableObjectList : ScriptableObject
    {
        public TowerScriptableObject[] towers;
    }
}

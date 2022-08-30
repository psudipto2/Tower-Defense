using ProjectileSO;
using UnityEngine;
using Singleton;
using Enums;

namespace ProjectileMVC
{
    public class ProjectileService : MonoGenericSingleton<ProjectileService>
    {
        private ProjectileModel projectileModel;
        private ProjectileController projectileController;
        public ProjectileScriptableObjectList projectileList;

        public void CreateNewProjectile(ProjectileType projectileType, Transform shootingPosition)
        {
            for(int i=0; i < projectileList.projectiles.Length; i++)
            {
                if (projectileList.projectiles[i].projectileType == projectileType)
                {
                    projectileModel = new ProjectileModel(projectileList.projectiles[i],shootingPosition);
                    projectileController = new ProjectileController(projectileModel, projectileList.projectiles[i].projectileView);
                }
            }
        }
    }
}

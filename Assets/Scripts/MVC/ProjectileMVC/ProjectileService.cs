using ProjectileSO;
using UnityEngine;
using ObjectPool;
using Singleton;
using Enums;

namespace ProjectileMVC
{
    public class ProjectileService : MonoGenericSingleton<ProjectileService>
    {
        private ProjectileView projectileView;
        [SerializeField] private PoolProjectile poolProjectile;

        private ProjectileModel projectileModel;
        private ProjectileController projectileController;
        public ProjectileScriptableObjectList projectileList;

        public ProjectileController CreateNewProjectile(ProjectileType projectileType, Transform shootingPosition)
        {
            for(int i=0; i < projectileList.projectiles.Length; i++)
            {
                if (projectileList.projectiles[i].projectileType == projectileType)
                {
                    projectileModel = new ProjectileModel(projectileList.projectiles[i],shootingPosition);
                    projectileController = poolProjectile.GetProjectile(projectileModel, projectileList.projectiles[i].projectileView);
                    projectileController.Enable(shootingPosition);
                    return projectileController;
                }
            }
            return null;
        }

        public void ReturnProjectileToPool(ProjectileController projectileController)
        {
            poolProjectile.ReturnItem(projectileController);
        }

    }
}

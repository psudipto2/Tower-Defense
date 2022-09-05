using ProjectileMVC;

namespace ObjectPool
{
    public class PoolProjectile : PoolerService<ProjectileController>
    {
        private ProjectileView projectileView;
        private ProjectileModel projectileModel;

        public ProjectileController GetProjectile(ProjectileModel projectileModel, ProjectileView projectileView)
        {
            this.projectileModel = projectileModel;
            this.projectileView = projectileView;
            return GetItem();
        }

        protected override ProjectileController CreateItem()
        {
            ProjectileController projectileController = new ProjectileController(projectileModel, projectileView);
            return projectileController;
        }
    }
}
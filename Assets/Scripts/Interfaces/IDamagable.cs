using Enums;

namespace Interfaces
{
    public interface IDamagable
    {
        void TakeDamage(int damage,ProjecileOrigin projecileOrigin);
    }
}
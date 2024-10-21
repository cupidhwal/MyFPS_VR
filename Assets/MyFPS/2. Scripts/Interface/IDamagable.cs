using UnityEngine;

namespace MyFPS
{
    public interface IDamagable
    {
        public void TakeDamage(float damage);
        public void Die();
    }
}
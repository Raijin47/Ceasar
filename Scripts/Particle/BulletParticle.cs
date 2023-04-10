using UnityEngine;
using Enemy;

namespace Bullet
{
    public class BulletParticle : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private int _damage;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _damage = Equipment.damageValue;
        }

        public void Shot()
        {
            _particleSystem.Play();
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.TryGetComponent(out IDamageable enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }
    }
}
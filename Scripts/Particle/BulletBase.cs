using System;
using Pool;
using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletBase : MonoBehaviour, IPoolObject<BulletBase>
    {
        public event Action<BulletBase> Clean;

        [SerializeField] private ParticleSystem _particle;
        private int _damage;

        private float _currentLifeTime;

        public void Init()
        {
            _damage = Equipment.damageValue;
            _particle.Play();
        }

        public void Release()
        {

        }

        private void Update()
        {
            _currentLifeTime -= Time.deltaTime;
            if (_currentLifeTime < 0) Clean?.Invoke(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyBase>().TakeDamage(_damage);
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if(other.TryGetComponent(out EnemyBase en))
            {
                en.TakeDamage(_damage);
                Clean?.Invoke(this);
            }
        }
        private void OnParticleTrigger()
        {
            
        }
    }
}
using System;
using Pool;
using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletBase : MonoBehaviour, IPoolObject<BulletBase>
    {
        public event Action<BulletBase> Clean;

        [SerializeField] private ParticleSystem _blood;
        [SerializeField] private float _lifeTime;
        [SerializeField] private int _damage;
        [SerializeField] private Transform[] _transforms;

        private float _currentLifeTime;

        public void Init()
        {
            for (int i = 0; i < _transforms.Length; i++)
                _transforms[i].localPosition = Vector3.zero;

            _currentLifeTime = _lifeTime;
            _damage = Equipment.damageValue;
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
            if(other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyBase>().TakeDamage(_damage);
                _blood.Play();
            }
        }
    }
}
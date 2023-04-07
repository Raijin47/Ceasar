using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Bullet
{
    public class BulletParticle : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private int _damage;
        //List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

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
            //int events = _particleSystem.GetCollisionEvents(other, colEvents);



            if (other.TryGetComponent(out EnemyBase enemy))
            {
                enemy.TakeDamage(_damage);
                Debug.Log("Нанесён урон");
                //for (int i = 0; i < events; i++)
                //{
                //    Instantiate(_blood, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
                //}
            }
        }
    }
}


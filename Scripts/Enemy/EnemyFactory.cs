using Pool;
using UnityEngine;

namespace Enemy
{
    public class EnemyFactory
    {
        private readonly PoolInstantiateObject<EnemyBase> _poolEnemy;
        private readonly Transform _content;

        public EnemyFactory(PoolInstantiateObject<EnemyBase> poolEnemy, Transform content)
        {
            _content = content;
            _poolEnemy = poolEnemy;
        }

        public EnemyBase Spawn(Vector3 position)
        {
            var obj = _poolEnemy.GetInstantiate();
            var transform = obj.transform;
            transform.parent = _content;
            transform.position = position;
            return obj;
        }
    }
}
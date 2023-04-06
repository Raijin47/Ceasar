using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Enemy
{
    public class EnemyProvider
    {
        private List<EnemyBase> _enemyBases = new List<EnemyBase>();
        private readonly PoolInstantiateObject<EnemyBase> _poolInstantiateObject;
        private readonly EnemyFactory _enemyFactory;
        private Transform _player;

        public EnemyProvider(PoolInstantiateObject<EnemyBase> poolInstantiateObject, Transform _content, Transform player)
        {
            _player = player;
            _enemyFactory = new EnemyFactory(poolInstantiateObject, _content);
            _poolInstantiateObject = poolInstantiateObject;
        }

        private void InitEnemy(EnemyBase enemyBase, Transform player)
        {
            player = _player;
            enemyBase.gameObject.SetActive(true);
            enemyBase.Die += OnDie;
            enemyBase.Init(_player);
        }

        private void OnDie(EnemyBase enemyBase)
        {
            enemyBase.Die -= OnDie;
            Remove(enemyBase);
        }

        public void CreateEnemy(Vector3 position)
        {
            var enemyBase = _enemyFactory.Spawn(position);
            if (IsHave(enemyBase))
                return;
            Add(enemyBase);
        }

        public void Add(EnemyBase enemyBase)
        {
            _enemyBases.Add(enemyBase);
            InitEnemy(enemyBase, _player);
        }

        public void Remove(EnemyBase enemyBase)
        {
            enemyBase.gameObject.SetActive(false);
            _enemyBases.Remove(enemyBase);
            enemyBase.Release();
            _poolInstantiateObject.Release(enemyBase);
        }

        private bool IsHave(EnemyBase enemyBase)
        {
            foreach(var Enemy in _enemyBases)
            {
                if (Enemy.GetInstanceID() == enemyBase.GetInstanceID()) return true;
            }
            return false;
        }
    }
}

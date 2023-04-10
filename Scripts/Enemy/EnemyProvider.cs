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

        private void InitEnemy(EnemyBase enemyBase, Transform player, int health)
        {
            player = _player;
            enemyBase.gameObject.SetActive(true);
            enemyBase.Die += OnDie;
            enemyBase.Init(_player, health);
        }

        private void OnDie(EnemyBase enemyBase)
        {               
            Remove(enemyBase);
        }

        public void Dispose()
        {
            for(int i = 0; i < _enemyBases.Count; i++)
            {
                _enemyBases[i].Die -= OnDie;
            }
        }

        public void CreateEnemy(Vector3 position, int health)
        {
            var enemyData = _enemyFactory.Spawn(position);
            var enemyBase = enemyData.Item1;
            if (enemyBase == null)
                return;
            var isInstantiate = enemyData.Item2;
            if(isInstantiate) Add(enemyBase, health);
            else ResetPoolEnemy(enemyBase, health);
        }

        private void ResetPoolEnemy(EnemyBase enemyBase, int health)
        {
            enemyBase.gameObject.SetActive(true);
            enemyBase.ResetData(health);
        }

        public void Add(EnemyBase enemyBase, int health)
        {
            _enemyBases.Add(enemyBase);
            InitEnemy(enemyBase, _player, health);
        }

        public void Remove(EnemyBase enemyBase)
        {
            enemyBase.gameObject.SetActive(false);
            _enemyBases.Remove(enemyBase);
            enemyBase.Release();
            _poolInstantiateObject.Release(enemyBase);
        }
    }
}
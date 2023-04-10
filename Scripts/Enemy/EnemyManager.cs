using System.Collections;
using Pool;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance;

        [SerializeField] private Transform _content;
        [SerializeField] private EnemyLocator _enemyLocator;
        [SerializeField] private Transform[] _enemySpawnPosition;
        [SerializeField] private Transform _player;

        [SerializeField] private float _intervalSpawn;
        [SerializeField] private float _health;
        [SerializeField] private float _multiplyHealth;

        [SerializeField] private int _maxCountEnemy;
        [SerializeField] private int _countSpawnEnemy;
 
        private Coroutine corSpawner;
        private EnemyFactory _enemyFactory;
        private EnemyProvider _enemyProvider;
        private PoolInstantiateObject<EnemyBase> _instantiateObject;

        private int _healthInt;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Init();
            EnemyScore.Clean();
            _healthInt = Mathf.RoundToInt(_health);
            corSpawner = StartCoroutine(SpawnerCOR());
            Application.targetFrameRate = 60;
        }

        IEnumerator SpawnerCOR()
        {
            while (true)
            {
                yield return new WaitForSeconds(_intervalSpawn);
                for(int i = 0; i < _countSpawnEnemy; i++)
                    StartSpawn();
            }
        }

        public void IncreaseHealth()
        {
            _health *= _multiplyHealth;
            _healthInt = Mathf.RoundToInt(_health);
        }

        private void Init()
        {
            _instantiateObject = new PoolInstantiateObject<EnemyBase>(_enemyLocator.EnemyBase, _maxCountEnemy);
            _enemyProvider = new EnemyProvider(_instantiateObject, _content, _player);
        }

        private void StartSpawn()
        {
            _enemyProvider.CreateEnemy(_enemySpawnPosition[Random.Range(0, _enemySpawnPosition.Length)].position, _healthInt);
        }

        private void OnDestroy()
        {
            _enemyProvider.Dispose();
        }
    }
}
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
        [SerializeField] private float _intervalSpawn;
        [SerializeField] private Transform _player;

        private Coroutine corSpawner;
        private EnemyFactory _enemyFactory;
        private EnemyProvider _enemyProvider;
        private PoolInstantiateObject<EnemyBase> _instantiateObject;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Init();
            EnemyScore.Clean();
            corSpawner = StartCoroutine(SpawnerCOR());
            Application.targetFrameRate = 60;
        }

        IEnumerator SpawnerCOR()
        {
            while (true)
            {
                yield return new WaitForSeconds(_intervalSpawn);
                StartSpawn();
            }
        }

        private void Init()
        {
            _instantiateObject = new PoolInstantiateObject<EnemyBase>(_enemyLocator.EnemyBase);
            _enemyProvider = new EnemyProvider(_instantiateObject, _content, _player);
        }

        private void StartSpawn()
        {
            _enemyProvider.CreateEnemy(_enemySpawnPosition[Random.Range(0, _enemySpawnPosition.Length)].position);
        }
    }
}

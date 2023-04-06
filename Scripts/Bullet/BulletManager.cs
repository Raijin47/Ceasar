using Pool;
using UnityEngine;

namespace Bullet
{
    public class BulletManager : MonoBehaviour
    {
        public static BulletManager Instance;

        [SerializeField] private Transform _content;

        private BulletLocator _bulletLocator;
        private ParticleSystem _particle;
        private Transform _bulletSpawnPosition;
        private BulletFactory _bulletFactory;
        private BulletProvider _bulletProvider;
        private PoolInstantiateObject<BulletBase> _instantiateObject;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Init();
        }

        public void CreateBullet()
        {
            _particle.Play();
            _bulletProvider.CreateBullet(_bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
        }

        private void Init()
        {
            _bulletLocator = GetComponentInChildren<BulletLocator>();
            _particle = GetComponentInChildren<ParticleSystem>();
            _bulletSpawnPosition = GetComponentInChildren<ParticleSystem>().transform;

            _instantiateObject = new PoolInstantiateObject<BulletBase>(_bulletLocator.BulletBase);
            _bulletProvider = new BulletProvider(_instantiateObject, _content);
        }
    }
}
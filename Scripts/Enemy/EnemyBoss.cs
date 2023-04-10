using UnityEngine;

namespace Enemy
{
    public class EnemyBoss : MonoBehaviour, IDamageable
    {
        [SerializeField] private ParticleSystem particleForObstacle;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform spawnPos;
        [SerializeField] private EnemyBossTrigger _bossTrigger;
        [SerializeField] private Animator anim;

        [SerializeField] private float _trackingRange = 1f;
        [SerializeField] private float _speedTracking;

        [SerializeField] private int _maxHealth;
        [SerializeField] private int _multiplyHealth;

        private Vector3 moveDirection = Vector3.zero;

        private float _rotationEnemy;
        private float _currentSpeed;
        private float _minSpeed;
        private float _maxSpeed;

        private int _currentHealth;

        private bool isDeath;

        private static readonly int DeathA = Animator.StringToHash("isDeath");

        private void Start()
        {
            _minSpeed = Equipment.acceleration - 1f;
            _maxSpeed = Equipment.acceleration + 1f;
            _currentSpeed = _maxSpeed;
        }

        public void Init()
        {
            _currentHealth = _maxHealth;
            transform.position = spawnPos.position;
            isDeath = false;
        }

        private void Update()
        {
            anim.SetBool(DeathA, isDeath);
            if (!isDeath)
            {
                Rotation();
                Movement();
            }
        }

        private void Rotation()
        {
            if (_player.position.z - transform.position.z > _trackingRange) _rotationEnemy = _speedTracking;
            else if (_player.position.z - transform.position.z < -_trackingRange) _rotationEnemy = -_speedTracking;
            else _rotationEnemy = 0;
        }

        private void Movement()
        {
            moveDirection = new Vector3(1, 0, _rotationEnemy);
            transform.position = Vector3.Lerp(transform.position, transform.position + moveDirection, _currentSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                if (!particleForObstacle.isPlaying)
                    particleForObstacle.Play();
            }
        }

        public void TakeDamage(int damageValue)
        {
            _currentHealth -= damageValue;
            if (_currentHealth <= 0) isDeath = true;            
        }

        public void SetMaxSpeed()
        {
            _currentSpeed = _maxSpeed;
        }

        public void SetMinSpeed()
        {
            _currentSpeed = _minSpeed;
        }

        private void Death()
        {
            EnemyScore.BossKilled();
            _maxHealth *= _multiplyHealth;
            _enemyManager.IncreaseHealth();
            _bossTrigger.BossKilled();
        }
    }
}
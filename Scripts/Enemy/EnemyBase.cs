using System;
using Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IPoolObject<EnemyBase>, IDamageable
    {
        public event Action<EnemyBase> Die;

        [SerializeField] private Animator anim;
        [SerializeField] private GameObject[] presets;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _trackingRange = 1f;
        [SerializeField] private float _speedYMin = 0.1f;
        [SerializeField] private float _speedYMax = 0.5f;

        [SerializeField] private int _maxHealth = 10;

        private Vector3 moveDirection = Vector3.zero;
        private Transform _player;

        private float _speedTracking;
        private float _rotationEnemy;
        private float _currentSpeed;

        private int _health;
        private int i = -1;
        private static readonly int DeathA = Animator.StringToHash("isDeath");

        public void Init(Transform player)
        {
            _player = player;
            if (i != -1) presets[i].SetActive(false);
            i = Random.Range(0, presets.Length);
            presets[i].SetActive(true);
            
            ResetData();
        }

        private void Update()
        {
            Rotation();
            Movement();
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

        public void Cleaner()
        {
            Die?.Invoke(this);
        }

        public void Release()
        {
            
        }

        public void ResetData()
        {
            _health = _maxHealth;
            _currentSpeed = Equipment.speed + Random.Range(0.5f, _maxSpeed);
            _speedTracking = Random.Range(_speedYMin, _speedYMax);
            anim.SetBool(DeathA, false);
        }

        public void TakeDamage(int damageValue)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                EnemyScore.ZombieKilled();
                Death();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle")) Death();
        }

        private void Death()
        {
            anim.SetBool(DeathA, true);
            _currentSpeed = 0;
        }
    }
}
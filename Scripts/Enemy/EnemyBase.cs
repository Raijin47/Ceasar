using System;
using Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IPoolObject<EnemyBase>, IDamageable
    {
        public event Action<EnemyBase> Die;

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator anim;
        [SerializeField] private GameObject[] presets;
        [SerializeField] private float _intervalCor;
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
            if(i != -1) presets[i].SetActive(false);
            i = Random.Range(0, presets.Length);
            presets[i].SetActive(true);

            anim.SetBool(DeathA, false);
            _speedTracking = Random.Range(_speedYMin, _speedYMax);
            _currentSpeed = Equipment.speed + Random.Range(0.5f, _maxSpeed);
            _player = player;
            _health = _maxHealth;
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
            moveDirection = new Vector3(1, 0f, _rotationEnemy);
            moveDirection *= _currentSpeed;
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        public void Cleaner()
        {
            Die?.Invoke(this);
        }

        public void Release()
        {

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
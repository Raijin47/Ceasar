using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _trackingRange = 1f;
        [SerializeField] private float _speedYMin = 0.1f;
        [SerializeField] private float _speedYMax = 0.5f;
        [SerializeField] private Transform _player;

        private Vector3 moveDirection = Vector3.zero;

        private float _speedTracking;
        private float _rotationEnemy;
        private float _currentSpeed;

        private void Start()
        {
            _currentSpeed = Equipment.acceleration - 1f;
            _speedTracking = Random.Range(_speedYMin, _speedYMax);
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
    }
}
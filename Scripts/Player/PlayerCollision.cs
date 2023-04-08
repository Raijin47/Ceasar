using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private PlayerLose _playerLose;

        private void Start()
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
            _playerLose = GetComponentInParent<PlayerLose>();
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Obstacle"))
            {
                playerMovement.StopMovement();
                _playerLose.GameOver();
            }
            if (other.CompareTag("Enemy"))
            {
                playerMovement.StopMovement();
                _playerLose.GameOver();
            }
        }
    }
}
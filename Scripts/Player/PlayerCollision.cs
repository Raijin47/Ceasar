using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private PlayerLose playerLose;

        private void Start()
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
            playerLose = GetComponentInParent<PlayerLose>();
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Obstacle"))
            {
                playerMovement.StopMovement();
                playerLose.GameOver();
            }
            if (other.CompareTag("Enemy"))
            {
                
            }
        }
    }
}
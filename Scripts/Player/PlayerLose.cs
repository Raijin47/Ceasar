using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Enemy;

namespace Player
{
    public class PlayerLose : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPunel;
        [SerializeField] private Text zombieKilledText;
        [SerializeField] private Text distanceTravelledText;
        [SerializeField] private Text timer;
        [SerializeField] private Text addGoldText;

        [SerializeField] private float timerAfterLose;
        [SerializeField] private int multiplierZombie;
        [SerializeField] private float multiplierDistance;

        private bool isGameOver = false;

        public void GameOver()
        {
            if(!isGameOver)
            {
                isGameOver = true;
                StartCoroutine(GameOverCOR());
            }          
        }

        private IEnumerator GameOverCOR()
        {
            while (true)
            {
                yield return new WaitForSeconds(timerAfterLose);
                gameOverPunel.SetActive(true);              
                timer.text = Mathf.Round(Time.time - timerAfterLose) + "с".ToString();
                zombieKilledText.text = EnemyScore._zombieKilled.ToString();
                float distanceTravelled = transform.position.x;
                distanceTravelledText.text = Mathf.Round(distanceTravelled) + "м".ToString();

                int goldReceived = (Mathf.FloorToInt(distanceTravelled * multiplierDistance)) + (EnemyScore._zombieKilled * multiplierZombie * EnemyScore._bossKilled);
                addGoldText.text = goldReceived.ToString();
                ManagerData.money += goldReceived;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                ManagerData.SaveData();

                //Time.timeScale = 0;
                yield break;
            }
        }
    }
}
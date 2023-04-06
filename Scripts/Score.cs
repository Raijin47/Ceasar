using UnityEngine;
using UnityEngine.UI;
using Enemy;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float multiplierFactor;
    [SerializeField] private Text zombieKilledText;
    [SerializeField] private Text distanceTravelledText;
    [SerializeField] private Text timer;

    public void GameOver()
    {
        timer.text = Mathf.Round(Time.time - 2) + "ñ".ToString();
        zombieKilledText.text = EnemyScore._zombieKilled.ToString();
        distanceTravelledText.text = Mathf.Round((player.position.x * multiplierFactor)).ToString();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
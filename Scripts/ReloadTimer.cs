using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Image timerImage;

    private float timeLeft = 0f;

    private void Start()
    {
        timeLeft = time;
        //StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            yield return null;
        }
    }
}
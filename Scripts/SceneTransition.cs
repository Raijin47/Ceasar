using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject imageFade;
    [SerializeField] private Image progressBar;
    [SerializeField] private Text loadingText;
    AsyncOperation asyncOperation;

    public void AsyncLoadButton(string sceneName) => StartCoroutine("AsyncLoadCOR", sceneName);

    IEnumerator AsyncLoadCOR(string sceneName)
    {
        float loadingProgress;
        asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        imageFade.SetActive(true);
        while(!asyncOperation.isDone)
        {
            loadingProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            loadingText.text = $"Загрузка... {(loadingProgress * 100).ToString("0")}%";
            progressBar.fillAmount = loadingProgress;
            yield return null;
        }
    }
}
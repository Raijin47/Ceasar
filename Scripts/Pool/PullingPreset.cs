using UnityEngine;

public class PullingPreset : MonoBehaviour
{
    [SerializeField] private GameObject[] preset;
    [SerializeField] private float offset;
    private int firstPreset;
    private int secondPreset;
    private int thirdPreset;
    private float currentDistanse = 20;

    void Start()
    {
        firstPreset = 0;

        secondPreset = Random.Range(1, preset.Length);
        preset[secondPreset].SetActive(true);
        preset[secondPreset].transform.position = new Vector3(currentDistanse, 0, 0);
        currentDistanse += offset;

        for (int i = 0; i < 5; i++)
        {
            thirdPreset = Random.Range(1, preset.Length);
            if (thirdPreset != secondPreset) i = 5;
            else i = 0;
        }
        preset[thirdPreset].SetActive(true);
        preset[thirdPreset].transform.position = new Vector3(currentDistanse, 0, 0);
        currentDistanse += offset;
    }

    public void Generate()
    {
        preset[firstPreset].SetActive(false);
        firstPreset = secondPreset;
        secondPreset = thirdPreset;
        for (int i = 0; i < 5; i++)
        {
            thirdPreset = Random.Range(1, preset.Length);
            if (thirdPreset != secondPreset && thirdPreset != firstPreset) i = 5;
            else i = 0;
        }
        preset[thirdPreset].SetActive(true);
        preset[thirdPreset].transform.position = new Vector3(currentDistanse, 0, 0);
        currentDistanse += offset;
    }
}
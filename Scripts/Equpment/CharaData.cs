using UnityEngine;

[CreateAssetMenu(fileName = "New CharaData", menuName = "Chara Data", order = 52)]
public class CharaData : ScriptableObject
{
    [SerializeField] private GameObject prefabMale;
    [SerializeField] private GameObject prefabWoman;
    [SerializeField] private Sprite icon;
    [SerializeField] private string charaName;
    [SerializeField] private string charaDescription;

    public GameObject PrefabMale
    {
        get { return prefabMale; }
    }
    public GameObject PrefabWoman
    {
        get { return prefabWoman; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    public string CharaName
    {
        get { return charaName; }
    }
    public string CharaDescription
    {
        get { return charaDescription; }
    }
}
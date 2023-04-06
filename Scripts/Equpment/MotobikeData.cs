using UnityEngine;

[CreateAssetMenu(fileName = "New MotobikeData", menuName = "Motobike Data", order = 52)]
public class MotobikeData : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite icon;
    [SerializeField] private string motobikeName;
    [SerializeField] private int goldCost;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField, Range(0.1f, 1f)] private float controllability;


    public GameObject Prefab
    {
        get { return prefab; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    public string MotobikeName
    {
        get { return motobikeName; }
    }
    public int GoldCost
    {
        get { return goldCost; }
    }
    public float Speed
    {
        get { return speed; }
    }
    public float Controllability
    {
        get { return controllability; }
    }
    public float Acceleration
    {
        get { return acceleration; }
    }
}
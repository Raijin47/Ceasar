using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite icon;
    [SerializeField] private string weaponName;
    [SerializeField] private int goldCost;
    [SerializeField] private int damageValue;
    [SerializeField] private int ammoCount;
    [SerializeField] private float reloadTime;
    [SerializeField] private float intervalShot;

    public GameObject Prefab
    {
        get { return prefab; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }
    public string WeaponName
    {
        get { return weaponName; }
    }
    public int GoldCost
    {
        get { return goldCost; }
    }
    public int DamageValue
    {
        get { return damageValue; }
    }
    public int AmmoCount
    {
        get { return ammoCount; }
    }
    public float ReloadTime
    {
        get { return reloadTime; }
    }
    public float IntervalShot
    {
        get { return intervalShot; }
    }
}
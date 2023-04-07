using UnityEngine;
using UnityEngine.UI;

public class LoadingData : MonoBehaviour
{
    [SerializeField] private WeaponData[] weaponData;
    [SerializeField] private MotobikeData[] motobikeData;
    [SerializeField] private CharaData[] charaData;
    [SerializeField] private Text moneyText;

    private int money;
    private int weaponID;
    private int motobikeID;
    private int charaID;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        ManagerData.LoadingData();
        money = ManagerData.money;
        motobikeID = ManagerData.motobike;
        weaponID = ManagerData.weapon;
        moneyText.text = money.ToString();

        Equipment.SetWeapon(weaponData[weaponID].DamageValue, weaponData[weaponID].Prefab, weaponData[weaponID].AmmoCount, weaponData[weaponID].ReloadTime, weaponData[weaponID].IntervalShot);
        Equipment.SetMotobike(motobikeData[motobikeID].Speed, motobikeData[motobikeID].Prefab, motobikeData[motobikeID].Controllability, motobikeData[motobikeID].Acceleration);
        Equipment.SetChara(charaData[charaID].PrefabMale, charaData[charaID].PrefabWoman);
    }
}
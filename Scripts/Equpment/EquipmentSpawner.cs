using UnityEngine;

public class EquipmentSpawner : MonoBehaviour
{
    private Transform weaponPoint;

    void Awake()
    {
        if (Equipment.prefabWoman != null) Instantiate(Equipment.prefabWoman, transform);
        weaponPoint = GetComponentInChildren<WeaponSpawner>().transform;
        if (Equipment.prefabMotobike != null) Instantiate(Equipment.prefabMotobike, transform);     
        if(Equipment.prefabMale != null) Instantiate(Equipment.prefabMale, transform);
        if (Equipment.prefabWeapon != null) Instantiate(Equipment.prefabWeapon, weaponPoint);

    }
}
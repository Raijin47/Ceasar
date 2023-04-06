using UnityEngine;

public class EquipmentSpawner : MonoBehaviour
{
    [SerializeField] private Transform weaponPoint;
    [SerializeField] private Transform motobikePoint;

    void Start()
    {
        if(Equipment.prefabMotobike != null) Instantiate(Equipment.prefabMotobike, motobikePoint);
        if(Equipment.prefabWeapon != null) Instantiate(Equipment.prefabWeapon, weaponPoint);
    }
}
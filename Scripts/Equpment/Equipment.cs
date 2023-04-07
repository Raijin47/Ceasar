using UnityEngine;

public static class Equipment
{
    public static GameObject prefabMotobike;
    public static float speed = 5f;
    public static float controllability = 1f;
    public static float acceleration = 10f;

    public static GameObject prefabWeapon;
    public static int damageValue = 5;
    public static int ammoCount;
    public static float reloadTime;
    public static float intervalShot;

    public static GameObject prefabMale;
    public static GameObject prefabWoman;

    public static void SetMotobike(float getSpeed, GameObject getPrefab, float getControllability, float getAcceleration)
    {
        prefabMotobike = getPrefab;
        speed = getSpeed;
        controllability = getControllability;
        acceleration = getAcceleration;
    }

    public static void SetWeapon(int getDamageValue, GameObject getPrefab, int getAmmoCount, float getReloadTime, float getIntervalShot)
    {
        prefabWeapon = getPrefab;
        damageValue = getDamageValue;
        ammoCount = getAmmoCount;
        reloadTime = getReloadTime;
        intervalShot = getIntervalShot;
    }

    public static void SetChara(GameObject getPrefabMale, GameObject getPrefabWoman)
    {
        prefabMale = getPrefabMale;
        prefabWoman = getPrefabWoman;
    }
}
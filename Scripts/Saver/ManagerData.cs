using UnityEngine;
using Saver;
using System.IO;

public static class ManagerData
{
    public static int money;
    public static int weapon;
    public static int motobike;
    public static int chara;

    public static bool[] weaponPurchased = new bool[12];
    public static bool[] motobikePurchased = new bool[4];
    private static Data data;



    public static void LoadingData()
    {

        if (File.Exists(Application.dataPath + "/Save.json"))
        {
            var data = SaveService<Data>.Load(Application.dataPath + "/Save.json");
            money = data.Money;
            weapon = data.WeaponID;
            motobike = data.MotobikeID;
            chara = data.CharaID;
            motobikePurchased = data.MotobikePurchased;
        }
        else
        {
            money = 10000;
            weapon = 0;
            motobike = 0;
            chara = 0;
            weaponPurchased = new bool[12] { true, false, false, false, false, false, false, false, false, false, false, false };
            motobikePurchased = new bool[4] { true, false, false, false };
        }
    }

    public static void SaveData()
    {
        data = new Data()
        {
            Money = money,
            WeaponID = weapon,
            MotobikeID = motobike,
            CharaID = chara,
            WeaponPurchased = weaponPurchased,
            MotobikePurchased = motobikePurchased
        };
        SaveService<Data>.Save(data, "/", "Save");
    }
}

public struct Data
{
    public int Money;
    public int WeaponID;
    public int MotobikeID;
    public int CharaID;
    public bool[] WeaponPurchased;
    public bool[] MotobikePurchased;
}
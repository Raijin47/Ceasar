using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private Text description;
    [SerializeField] private Image previewImage;
    [SerializeField] private GameObject selectedButton;
    [SerializeField] private GameObject purchasedButton;
    [SerializeField] private WeaponData[] weaponData;
    [SerializeField] private LoadingData loadingData;

    [SerializeField] private bool[] isPurchased;
    [SerializeField] private bool[] isSelected;



    private int i = 0;
    private int selected = 0;


    private void Start()
    {
        UpdateDisplayUI(i);
    }

    private void UpdateDisplayUI(int a)
    {
        previewImage.sprite = weaponData[a].Icon;
        description.text = weaponData[a].WeaponName;        
        selectedButton.SetActive(isPurchased[a]);
        purchasedButton.SetActive(!isPurchased[a]);
    }

    public void LeftButton()
    {
        if (i == 0) i = weaponData.Length;
        i--;
        UpdateDisplayUI(i);
    }

    public void RightButton()
    {
        i++;
        if (i >= weaponData.Length) i = 0;
        UpdateDisplayUI(i);
    }

    public void SelectedButton()
    {
        isSelected[selected] = false;
        selected = i;
        isSelected[i] = true;
        Equipment.SetWeapon(weaponData[i].DamageValue, weaponData[i].Prefab, weaponData[i].AmmoCount, weaponData[i].ReloadTime, weaponData[i].IntervalShot);
        UpdateDisplayUI(i);
        loadingData.SaveWeapon(i);
    }

    public void PurchasedButton()
    {
        isPurchased[i] = true;
        UpdateDisplayUI(i);
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private Image previewImage;
    [SerializeField] private Image damageImage;
    [SerializeField] private Image shotRateImage;
    [SerializeField] private Image ammoCountImage;
    [SerializeField] private GameObject selectedButton;
    [SerializeField] private GameObject purchasedButton;
    [SerializeField] private GameObject noMoneyPanel;
    [SerializeField] private WeaponData[] weaponData;

    private int i = 0;
    private int selected = 0;

    private void Start()
    {
        UpdateDisplayUI(i);
    }

    private void UpdateDisplayUI(int a)
    {
        previewImage.sprite = weaponData[a].Icon;
        title.text = weaponData[a].WeaponName;
        damageImage.fillAmount = weaponData[a].DamageValue / 10;
        shotRateImage.fillAmount = weaponData[a].IntervalShot / 10;
        ammoCountImage.fillAmount = weaponData[a].AmmoCount / 20;
        costText.text = weaponData[a].GoldCost.ToString();
        money.text = ManagerData.money.ToString();
        selectedButton.SetActive(ManagerData.weaponPurchased[a]);
        purchasedButton.SetActive(!ManagerData.weaponPurchased[a]);
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
        selected = i;
        Equipment.SetWeapon(weaponData[i].DamageValue, weaponData[i].Prefab, weaponData[i].AmmoCount, weaponData[i].ReloadTime, weaponData[i].IntervalShot);
        UpdateDisplayUI(i);
        ManagerData.weapon = i;
    }

    public void PurchasedButton()
    {
        if (ManagerData.money >= weaponData[i].GoldCost)
        {
            ManagerData.money -= weaponData[i].GoldCost;
            ManagerData.weaponPurchased[i] = true;
            UpdateDisplayUI(i);
        }
        else noMoneyPanel.SetActive(true);
    }
}
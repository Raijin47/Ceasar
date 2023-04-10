using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MotobikeShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private Image previewImage;
    [SerializeField] private Image speedImage;
    [SerializeField] private Image controllabilityImage;
    [SerializeField] private Image accelerationImage;
    [SerializeField] private GameObject selectedButton;
    [SerializeField] private GameObject purchasedButton;
    [SerializeField] private GameObject noMoneyPanel;
    [SerializeField] private MotobikeData[] motobikeData;
    
    private int i = 0;
    private int selected = 0;

    private void Start()
    {
        UpdateDisplayUI(i);
    }

    private void UpdateDisplayUI(int a)
    {
        previewImage.sprite = motobikeData[a].Icon;
        title.text = motobikeData[a].MotobikeName;
        speedImage.fillAmount = motobikeData[a].Speed / 10;
        controllabilityImage.fillAmount = motobikeData[a].Controllability;
        accelerationImage.fillAmount = motobikeData[a].Acceleration / 20;
        costText.text = motobikeData[a].GoldCost.ToString();
        money.text = ManagerData.money.ToString();
        selectedButton.SetActive(ManagerData.motobikePurchased[a]);
        purchasedButton.SetActive(!ManagerData.motobikePurchased[a]);
    }

    public void LeftButton()
    {
        if (i == 0) i = motobikeData.Length;
        i--;      
        UpdateDisplayUI(i);
    }

    public void RightButton()
    {
        i++;
        if (i >= motobikeData.Length) i = 0;
        UpdateDisplayUI(i);
    }

    public void SelectedButton()
    {
        selected = i;
        Equipment.SetMotobike(motobikeData[i].Speed, motobikeData[i].Prefab, motobikeData[i].Controllability, motobikeData[i].Acceleration);
        UpdateDisplayUI(i);
        ManagerData.motobike = i;
    }

    public void PurchasedButton()
    {
        if (ManagerData.money >= motobikeData[i].GoldCost)
        {
            ManagerData.money -= motobikeData[i].GoldCost;
            ManagerData.motobikePurchased[i] = true;
            UpdateDisplayUI(i);
        }
        else noMoneyPanel.SetActive(true);
    }
}
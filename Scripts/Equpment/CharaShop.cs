using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharaShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image previewImage;
    [SerializeField] private GameObject selectedButton;
    [SerializeField] private GameObject purchasedButton;
    [SerializeField] private CharaData[] charaData;

    private int i = 0;
    private int selected = 0;

    private void Start()
    {
        UpdateDisplayUI(i);
    }

    private void UpdateDisplayUI(int a)
    {
        previewImage.sprite = charaData[a].Icon;
        title.text = charaData[a].CharaName;
        descriptionText.text = charaData[a].CharaDescription;
        selectedButton.SetActive(ManagerData.charaPurchased[a]);
        purchasedButton.SetActive(!ManagerData.charaPurchased[a]);
    }

    public void LeftButton()
    {
        if (i == 0) i = charaData.Length;
        i--;
        UpdateDisplayUI(i);
    }

    public void RightButton()
    {
        i++;
        if (i >= charaData.Length) i = 0;
        UpdateDisplayUI(i);
    }

    public void SelectedButton()
    {
        selected = i;
        Equipment.SetChara(charaData[i].PrefabMale, charaData[i].PrefabWoman);
        UpdateDisplayUI(i);
        ManagerData.chara = i;
    }

    public void PurchasedButton()
    {

    }
}
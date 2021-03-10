using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public Text PriceTxt;
    public Text QuantityTxt;

    [SerializeField]
    private ShopManagerScript shopManagerScript;

    [SerializeField]
    private string upgradeName;

    public string UpgradeName { get => upgradeName; set => upgradeName = value; }

    void Start()
    {
        UpdateText();
    }

    internal void UpdateText()
    {
        int upgradeIndex = GameState.upgradeIndices[UpgradeName];

        QuantityTxt.text = upgradeIndex.ToString();

        if (upgradeIndex < 9)
        {
            PriceTxt.text = shopManagerScript.allPrices[UpgradeName][upgradeIndex].ToString();
        }
        else
        {
            PriceTxt.text = "--";
        }
    }
}

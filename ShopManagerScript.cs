using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ShopManagerScript : MonoBehaviour
{
    [SerializeField]
    private Transform eventSystem;

    [Header("Prices")]
    [SerializeField]
    private int[] enginePrices = new int[] { 5, 10, 20, 30, 40, 50, 75, 100, 200 };

    [SerializeField]
    private int[] fuelTankPrices = new int[] { 5, 10, 15, 20, 30, 40, 50, 75, 100 };

    [SerializeField]
    private int[] aeroPrices = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 100 };

    [SerializeField]
    private int[] gyroPrices = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 100 };
    
    [SerializeField]
    private int[] altitudePrices = new int[] { 15, 30, 45, 60, 80, 100, 120, 150, 200 };

    internal Dictionary<string, int[]> allPrices;

    private int[] upgradeIndices;

    public Text MoneyTxt;

    void Awake()
    {
        allPrices = new Dictionary<string, int[]>()
        {
            { "Engine", enginePrices },
            { "Fuel Tank", fuelTankPrices },
            { "Aero", aeroPrices },
            { "Gyro", gyroPrices },
            { "Altitude", altitudePrices }
        };

        UpdateMoney();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void UpdateMoney()
    {
        MoneyTxt.text = "Money: " + GameState.Money.ToString();
    }

    internal void Buy()
    {
        ButtonInfo buttonInfo = eventSystem.GetComponent<EventSystem>().currentSelectedGameObject.GetComponent<ButtonInfo>();
        string upgradeName = buttonInfo.UpgradeName;

        int upgradeIndex = GameState.upgradeIndices[upgradeName];
        int[] prices = allPrices[upgradeName];

        if (upgradeIndex < 9 && GameState.Money >= prices[upgradeIndex])
        {
            GameState.Money -= prices[upgradeIndex];
            UpdateMoney();

            GameState.upgradeIndices[upgradeName] += 1;
            buttonInfo.UpdateText();
        }
    }
}

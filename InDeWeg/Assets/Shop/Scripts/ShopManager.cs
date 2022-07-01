using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public TMP_Text otherCoinUI;
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shoppanels;
    public GameObject[] shoppannelsGO;
    public Button[] myPurchaseBTNs;

    public GameObject inventoryManager;
    public ItemSeeds[] allPosibleItems;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shoppannelsGO[i].SetActive(true);
        coinUI.text = "€: " + coins.ToString();
        LoadPanels();

        AddCoins(100);

        CheckPurchaceable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckPurchaceable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost)
            {
                myPurchaseBTNs[i].interactable = true;
            }
            else
            {
                myPurchaseBTNs[i].interactable = false;
            }
        }
    }
    public void AddCoins(int coinAmount)
    {
        coins += (coinAmount);
        coinUI.text = "€: " + coins.ToString();
        otherCoinUI.text = "€: " + coins.ToString();
        CheckPurchaceable();
    }
    public void PurchaseItem(int BTNNo)
    {
        if (coins >= shopItemsSO[BTNNo].baseCost)
        {
            coins = coins - shopItemsSO[BTNNo].baseCost;
            coinUI.text = "€: " + coins.ToString();
            otherCoinUI.text = "€: " + coins.ToString();

            inventoryManager.GetComponent<InventoryManager>().addItemAmount = 1;
            inventoryManager.GetComponent<InventoryManager>().AddItemSeeds(allPosibleItems[BTNNo]);

            CheckPurchaceable();
            //
        }
    }
    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shoppanels[i].TitleTXT.text = shopItemsSO[i].title;
            shoppanels[i].DescriptionTXT.text = shopItemsSO[i].description;
            shoppanels[i].PriceTXT.text = "€: " + shopItemsSO[i].baseCost.ToString();
            //shoppanels[i].iconIMG. = shopItemsSO[i].icon;
        }
    }
}

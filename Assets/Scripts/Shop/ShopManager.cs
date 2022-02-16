using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField]
    private GameObject shopMenu, buyPanel, sellPanel;

    [SerializeField]
    TextMeshProUGUI currentGilText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShopMenu()
	{
        shopMenu.SetActive(true);

        GameManager.instance.ShopOpened = true;

        currentGilText.text = GameManager.instance.CurrentGil + " G";

        buyPanel.SetActive(true);
    }

    public void CloseShopMenu()
	{
        shopMenu.SetActive(false);

        GameManager.instance.ShopOpened = false;
	}

    public void OpenBuyPanel()
	{
        buyPanel.SetActive(true);
        sellPanel.SetActive(false);
	}

    public void OpenSellPanel()
    {
        buyPanel.SetActive(false);
        sellPanel.SetActive(true);
    }
}

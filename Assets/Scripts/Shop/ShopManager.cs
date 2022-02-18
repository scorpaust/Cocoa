using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField]
    private GameObject shopMenu, buyPanel, sellPanel;

    [SerializeField]
    TextMeshProUGUI currentGilText;

    [SerializeField]
    private GameObject itemSlotContainer;

    [SerializeField]
    private Transform itemSlotBuyContainerParent, itemSlotSellContainerParent;

    private List<ItemsManager> itemsForSale;

    public List<ItemsManager> ItemsForSale { get { return itemsForSale; } set { itemsForSale = value; } }

    bool buyPanelOpened = false;

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

        UpdateShopItems(itemSlotBuyContainerParent, itemsForSale);
    }

    public void OpenSellPanel()
    {
        buyPanel.SetActive(false);
        sellPanel.SetActive(true);

        UpdateShopItems(itemSlotSellContainerParent, Inventory.instance.GetItemsList());
    }

    private void ClearItemsSlotFromInventory(Transform itemSlotContainerParent)
    {
        if (itemSlotContainerParent.childCount <= 0) return;

        foreach (Transform itemSlot in itemSlotContainerParent)
        {
            Destroy(itemSlot.gameObject);
        }
    }

    private void UpdateShopItems(Transform itemSlotContainerParent, List<ItemsManager> itemsToLookTo)
	{
        ClearItemsSlotFromInventory(itemSlotContainerParent);

        foreach (ItemsManager item in itemsToLookTo)
        {
            RectTransform itemSlot = Instantiate(itemSlotContainer, itemSlotContainerParent).GetComponent<RectTransform>();

            Image itemImage = itemSlot.Find("Item Image").GetComponent<Image>();

            itemImage.sprite = item.ItemImage;

            TextMeshProUGUI itemAmountText = itemSlot.Find("Item amount").GetComponent<TextMeshProUGUI>();

            if (item.Amount > 1)
            {
                itemAmountText.text = "";
            }
            else
            {
                itemAmountText.text = "";
            }

            itemSlot.GetComponent<ItemButton>().ItemOnButton = item;
        }
    }

	private void OnDisable()
	{
        buyPanelOpened = false;
	}
}

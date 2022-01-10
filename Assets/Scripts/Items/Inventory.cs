using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private List<ItemsManager> itemsList;

    private bool itemAlreadyInInventory = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        itemsList = new List<ItemsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(ItemsManager item)
	{
        if (item.IsStackable)
		{
            foreach (ItemsManager itemInInventory in itemsList)
			{
                if (itemInInventory.ItemName == item.ItemName)
				{
                    itemInInventory.Amount += item.Amount;

                    itemAlreadyInInventory = true;
				}
			}

            if (!itemAlreadyInInventory)
			{
                itemsList.Add(item);
			}
		}
        else
		{
            itemsList.Add(item);
        }       
	}

    public void RemoveItem(ItemsManager item)
	{
        if (item.IsStackable)
		{
            ItemsManager inventoryItem = null;

            foreach (ItemsManager itemInInventory in itemsList)
			{
                if (itemInInventory.ItemName == item.ItemName)
				{
                    itemInInventory.Amount -= 1;

                    inventoryItem = itemInInventory;
				}
			}

            if (inventoryItem != null && inventoryItem.Amount <= 0)
			{
                itemsList.Remove(inventoryItem);

                UIController.instance.ItemName.text = "";

                UIController.instance.ItemDescription.text = "";
			}
		}
        else
		{
            itemsList.Remove(item);
		}
	}

    public List<ItemsManager> GetItemsList()
	{
        return itemsList;
	}
}

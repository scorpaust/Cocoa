using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField]
    private ItemsManager itemOnButton;

    public ItemsManager ItemOnButton {  get { return itemOnButton; } set { itemOnButton = value; } }

	public void Press()
	{
        UIController.instance.ItemName.text = itemOnButton.ItemName;

        UIController.instance.ItemDescription.text = itemOnButton.ItemDescription;

        UIController.instance.ActiveItem = itemOnButton;
	}
}

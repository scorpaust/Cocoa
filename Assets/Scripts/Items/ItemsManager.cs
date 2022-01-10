using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public enum ItemType { PowerUp, Weapon, Armor }

    public enum AffectType { HP, Mana }

    [SerializeField]
    private ItemType itemType;

    [SerializeField]
    private string itemName, itemDescription;

    public string ItemName { get { return itemName; } private set { } }

    public string ItemDescription { get { return itemDescription; } private set { } }

    [SerializeField]
    private int valueInCoins;

    [SerializeField]
    private Sprite itemImage;

    public Sprite ItemImage { get { return itemImage; } private set { } }

    [SerializeField]
    private int amountOfAffect;

    [SerializeField]
    private AffectType affectType;

    [SerializeField]
    private int weaponDexterity, armorDefence;

    public int WeaponDexterity {  get { return weaponDexterity; } private set { } }

    public int ArmorDefence {  get { return armorDefence; } private set { } }

    [SerializeField]
    private bool isStackable;

    public bool IsStackable {  get { return isStackable; } private set { } }

    [SerializeField]
    private int amount;

    public int Amount {  get { return amount; } set { amount = value; } }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            Inventory.instance.AddItem(this);
            gameObject.SetActive(false);
		}
	}

    public void UseItem(int charToUseOn)
	{
        PlayerStats selectedChar = GameManager.instance.GetPlayerStats()[charToUseOn];

        if (itemType == ItemType.PowerUp)
		{
            if (affectType == AffectType.HP)
			{
                selectedChar.AddHp(amountOfAffect);

                UIController.instance.DiscardItem();
			}

            else if (affectType == AffectType.Mana)
			{
                selectedChar.AddMana(amountOfAffect);

                UIController.instance.DiscardItem();
            }

		}
        else if (itemType == ItemType.Weapon)
		{
            if (selectedChar.EquippedWeaponName != "")
			{
                Inventory.instance.AddItem(selectedChar.EquippedWeapon);
			}

            selectedChar.EquipWeapon(this);
		}
        else if (itemType == ItemType.Armor)
		{
            if (selectedChar.EquippedArmorName != "")
			{
                Inventory.instance.AddItem(selectedChar.EquippedArmor);
			}

            selectedChar.EquipArmor(this);
		}
	}
}

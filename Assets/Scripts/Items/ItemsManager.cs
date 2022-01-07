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

    [SerializeField]
    private int valueInCoins;

    [SerializeField]
    private Sprite itemImage;

    [SerializeField]
    private int amountOfAffect;

    [SerializeField]
    private AffectType affectType;

    [SerializeField]
    private int weaponDexterity, armorDefence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            Inventory.instance.AddItem(this);
            Destroy(gameObject);
		}
	}
}

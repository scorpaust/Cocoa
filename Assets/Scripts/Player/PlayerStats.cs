using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [SerializeField]
    private Sprite charImage;

    public Sprite CharImage {  get { return charImage; } private set { } }

    [SerializeField]
    private string playerName;

    public string PlayerName {  get { return playerName; } private set { } }

    [SerializeField]
    private int playerLevel;

    public int PlayerLevel {  get { return playerLevel; } private set { } }

    [SerializeField]
    private int currentXp;

    public int CurrentXp {  get { return currentXp; } private set { } }

    [SerializeField]
    private int maxHP = 100;

    public int MaxHP {  get { return maxHP; } private set { } }

    [SerializeField]
    private int currentHP;

    public int CurrentHP {  get { return currentHP; } private set { } } 

    [SerializeField]
    private int maxMana = 20;

    public int MaxMana {  get { return maxMana; } private set { } }

    [SerializeField]
    private int currentMana;

    public int CurrentMana {  get { return currentMana; } private set { } }

    [SerializeField]
    private int dexterity;

    public int Dexterity {  get { return dexterity; } private set { } }

    [SerializeField]
    private int defence;

    public int Defence {  get { return defence; } private set { } }

    [SerializeField]
    private int inteligence;

    public int Inteligence {  get { return inteligence; } private set { } }

    [SerializeField]
    private int luck;

    public int Luck {  get { return luck; } private set { } }

    [SerializeField]
    private int maxLevel = 100;

    [SerializeField]
    private int[] xpForNextLevel;

    public int[] XpForNextLevel {  get { return xpForNextLevel; } private set { } }

    [SerializeField]
    private int baseLevelXp;

    public int BaseLevelXp {  get { return baseLevelXp; } private set { } }

    [SerializeField]
    private string equippedWeaponName, equippedArmorName;

    public string EquippedWeaponName {  get { return equippedWeaponName; } }

    public string EquippedArmorName {  get { return equippedArmorName; } }

    [SerializeField]
    private int weaponPower;

    public int WeaponPower { get { return weaponPower; } }

    [SerializeField]
    private int armorDefence;

    public int ArmorDefence {  get { return armorDefence; } }

    [SerializeField]
    private ItemsManager equippedWeapon, equippedArmor;

    public ItemsManager EquippedWeapon {  get { return equippedWeapon; } }

    public ItemsManager EquippedArmor {  get { return equippedArmor; } }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        xpForNextLevel = new int[maxLevel];
        xpForNextLevel[1] = baseLevelXp;

        for (int i = 2; i < xpForNextLevel.Length; i++)
		{
            float xpPow3 = Mathf.Pow(i, 3);
            float xpPow2 = Mathf.Pow(i, 2);
            xpForNextLevel[i] = (int)((0.02f * xpPow3 + 3.06f * xpPow2 + 105.6f * i) - (dexterity + luck + inteligence));
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
		{
            AddXp(100);
		}
    }

    private void UpgradeStats()
    {
        if (playerLevel % 2 == 0)
        {
            dexterity++;
        }
        else
        {
            defence++;
        }

        if (playerLevel % 3 == 0)
        {
            luck++;
        }
        else
        {
            inteligence++;
        }

        maxHP = Mathf.FloorToInt(maxHP * Random.Range(1.01f, 1.06f));
        currentHP = maxHP;

        maxMana = Mathf.FloorToInt(maxMana * Random.Range(0.9f, 1.02f));
        currentMana = maxMana;
    }

    public void AddXp(int amountOfXp)
	{
        currentXp += amountOfXp;

        if (currentXp > xpForNextLevel[playerLevel])
		{
            currentXp -= xpForNextLevel[playerLevel];

            playerLevel++;

            UpgradeStats();
		}
	}

    public void AddHp(int amountOfHp)
	{
        currentHP += amountOfHp;

        if (currentHP > maxHP)
		{
            currentHP = maxHP;
		}
	}

    public void AddMana(int amountOfMana)
    {
        currentMana += amountOfMana;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    public void EquipWeapon(ItemsManager weaponToEquip)
	{
        equippedWeapon = weaponToEquip;

        equippedWeaponName = equippedWeapon.ItemName;

        weaponPower = equippedWeapon.WeaponDexterity;
	}

    public void EquipArmor(ItemsManager armorToEquip)
    {
        equippedArmor = armorToEquip;

        equippedArmorName = equippedArmor.ItemName;

        armorDefence = equippedArmor.ArmorDefence;
    }
}

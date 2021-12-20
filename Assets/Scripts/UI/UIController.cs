using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField]
    private Image imageToFade;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private TextMeshProUGUI[]  nameText, hpText, manaText, currentXp, xpText;

    [SerializeField]
    private Slider[] xpSlider;

    [SerializeField]
    private Image[] charImage;

    [SerializeField]
    private GameObject[] charPanel;

    [SerializeField]
    private GameObject[] statsButtons;

    [SerializeField]
    private TextMeshProUGUI statsName, statsHP, statsMana, statsDexterity, statsDefence, statsLuck, statsInteligence;

    [SerializeField]
    private Image charStatsImage;

    private PlayerStats[] playerStats;

	private void Awake()
	{
        instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToggleMenuOnOff();
    }

    private void ToggleMenuOnOff()
	{
        if (Input.GetKeyDown(KeyCode.M))
		{
            if (menu.activeInHierarchy)
            {
                menu.SetActive(false);
                GameManager.instance.GameMenuOpened = false;
            }
            else
            {
                UpdateStats();
                menu.SetActive(true);
                GameManager.instance.GameMenuOpened = true;
            }
        } 
	}

    public void UpdateStats()
	{
        playerStats = GameManager.instance.GetPlayerStats();

        for (int i = 0; i < playerStats.Length; i++)
		{
            charPanel[i].SetActive(true);
            nameText[i].text = playerStats[i].PlayerName;
            charImage[i].sprite = playerStats[i].CharImage;
            hpText[i].text = "HP: " + playerStats[i].CurrentXp + "/" + playerStats[i].MaxHP;
            manaText[i].text = "Mana: " + playerStats[i].CurrentMana + "/" + playerStats[i].MaxMana;
            currentXp[i].text = "Current Xp: " + playerStats[i].CurrentXp;
            xpText[i].text = playerStats[i].CurrentXp.ToString() + "/" + playerStats[i].XpForNextLevel[playerStats[i].PlayerLevel];
            xpSlider[i].maxValue = playerStats[i].XpForNextLevel[playerStats[i].PlayerLevel];
            xpSlider[i].value = playerStats[i].CurrentXp;
		}
	}

    public void StatsMenu()
	{
        StatsMenuUpdate(0);
        for (int i = 0; i < playerStats.Length; i++)
		{
            statsButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerStats[i].PlayerName;
            statsButtons[i].SetActive(true);
		}
	}

    public void StatsMenuUpdate(int playerSelectedNumber)
	{
        PlayerStats playerSelected = playerStats[playerSelectedNumber];

        statsName.text = playerSelected.PlayerName;
        statsHP.text = playerSelected.CurrentHP.ToString() + "/" + playerSelected.MaxHP.ToString();
        statsMana.text = playerSelected.CurrentMana.ToString() + "/" + playerSelected.MaxMana.ToString();
        statsDexterity.text = playerSelected.Dexterity.ToString();
        statsDefence.text = playerSelected.Defence.ToString();
        statsLuck.text = playerSelected.Luck.ToString();
        statsInteligence.text = playerSelected.Inteligence.ToString();
        charStatsImage.sprite = playerSelected.CharImage;
	}

    public void QuitGame()
	{
        Application.Quit();
	}

    public void FadeImage()
	{
        imageToFade.GetComponent<Animator>().SetTrigger("StartFading");
	}
}

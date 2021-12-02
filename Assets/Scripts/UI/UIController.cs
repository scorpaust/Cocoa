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
    private TextMeshProUGUI[]  nameText, hpText, manaText, levelText, xpText;

    [SerializeField]
    private Slider[] xpSlider;

    [SerializeField]
    private Image[] charImage;

    [SerializeField]
    private GameObject[] charPanel;

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
                UpdateStats();
                menu.SetActive(false);
                GameManager.instance.GameMenuOpened = false;
            }
            else
            {
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
            charPanel[i].gameObject.SetActive(true);
		}
	}

    public void FadeImage()
	{
        imageToFade.GetComponent<Animator>().SetTrigger("StartFading");
	}
}

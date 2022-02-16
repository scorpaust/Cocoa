using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private PlayerStats[] playerStats;

    [SerializeField]
    private bool gameMenuOpened, dialogBoxOpened;

    [SerializeField]
    private int currentGil = 0;

    public int CurrentGil { get { return currentGil; } set { currentGil = value; } }

    public bool GameMenuOpened {  get { return gameMenuOpened; } set { gameMenuOpened = value; } }

    public bool DialogBoxOpened {  get { return dialogBoxOpened; } set { dialogBoxOpened = value; } }

    private bool shopOpened = false;

    public bool ShopOpened {  get { return shopOpened; } set { shopOpened = value; } }

    private void Awake()
	{
        if (instance == null && instance != this)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

	// Start is called before the first frame update
	void Start()
    {
        playerStats = FindObjectsOfType<PlayerStats>();
        SortPlayerStatsArray();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
    }

    private void SortPlayerStatsArray()
	{
        for (int i = 0; i < playerStats.Length; i++)
        {
            PlayerStats temp = playerStats[i];
            if (playerStats[i].gameObject.CompareTag("Player"))
            {
                if (i > 0)
                {
                    playerStats[i] = playerStats[0];
                    playerStats[0] = temp;
                }
            }
        }
    }

    private void HandlePlayerMovement()
	{
        if (dialogBoxOpened || gameMenuOpened || shopOpened)
		{
            PlayerController.instance.CanMove = false;
		}
        else
		{
            PlayerController.instance.CanMove = true;
        }
	}

    public PlayerStats[] GetPlayerStats()
	{
        return playerStats;
	}
}

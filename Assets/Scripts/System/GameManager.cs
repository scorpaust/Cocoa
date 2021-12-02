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

    public bool GameMenuOpened {  get { return gameMenuOpened; } set { gameMenuOpened = value; } }

    public bool DialogBoxOpened {  get { return dialogBoxOpened; } set { dialogBoxOpened = value; } }

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
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
	{
        if (dialogBoxOpened || gameMenuOpened)
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

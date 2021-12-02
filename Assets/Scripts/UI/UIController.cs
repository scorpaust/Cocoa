using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField]
    private Image imageToFade;

    [SerializeField]
    private GameObject menu;

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
            }
            else
            {
                menu.SetActive(true);
            }
        } 
	}

    public void FadeImage()
	{
        imageToFade.GetComponent<Animator>().SetTrigger("StartFading");
	}
}

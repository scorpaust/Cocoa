using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public static DialogController instance;

    [SerializeField]
    private TextMeshProUGUI dialogText, nameText;

    [SerializeField]
    private GameObject dialogBox, nameBox;

    [SerializeField]
    private string[] dialogSentences;

    private int currentSentence;

    private bool dialogJustStarted;

	private void Awake()
	{
        instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        dialogText.text = dialogSentences[currentSentence];
    }

    // Update is called once per frame
    void Update()
    {
        HandleDialog();
    }

    private void HandleDialog()
	{
        if (dialogBox.activeInHierarchy)
		{
            if (Input.GetButtonUp("Fire1"))
			{
                if (!dialogJustStarted)
				{
                    currentSentence++;

                    if (currentSentence >= dialogSentences.Length)
                    {
                        currentSentence = 0;
                        nameBox.SetActive(false);
                        dialogBox.SetActive(false);
                        PlayerController.instance.CanMove = true;
                    }
                    else
                    {
                        CheckForName();
                        dialogText.text = dialogSentences[currentSentence];
                    }

                }
                else
				{
                    dialogJustStarted = false;
				}    
            }
		}
	} 

    private void CheckForName()
	{
        if (dialogSentences[currentSentence].StartsWith("#"))
		{
            nameText.text = dialogSentences[currentSentence].Replace("#", "");

            currentSentence++;
		}
	}

    public void ActivateDialog(string[] newSentencesToUse)
	{
        dialogSentences = newSentencesToUse;
        
        currentSentence = 0;

        CheckForName();

        dialogText.text = dialogSentences[currentSentence];

        dialogBox.SetActive(true);

        nameBox.SetActive(true);

        dialogJustStarted = true;

        PlayerController.instance.CanMove = false;
	}

    public bool IsDialogBoxActive()
	{
        return dialogBox.activeInHierarchy;
	}
}

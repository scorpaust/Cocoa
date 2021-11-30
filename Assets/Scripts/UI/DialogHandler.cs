using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    [SerializeField]
    private string[] sentences;

    private bool canActivateBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActivateDialog();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
            canActivateBox = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
            canActivateBox = false;
	}

    private void ActivateDialog()
	{
        if (canActivateBox && Input.GetButtonDown("Fire1") && !DialogController.instance.IsDialogBoxActive())
		{
            DialogController.instance.ActivateDialog(sentences);
		}
	}
}

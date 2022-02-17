using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private List<ItemsManager> itemsForSale;

    private bool canOpenShop;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenShop && Input.GetButtonDown("Fire1") && PlayerController.instance.CanMove && ShopManager.instance.gameObject.activeInHierarchy)
		{
            ShopManager.instance.OpenShopMenu();

            ShopManager.instance.ItemsForSale = itemsForSale;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            canOpenShop = true;

            anim.SetBool("communicate", true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            canOpenShop = false;

            anim.SetBool("communicate", false);
		}
	}
}

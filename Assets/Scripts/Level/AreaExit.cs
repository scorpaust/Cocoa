using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private string transitionAreaName;

    private AreaEnter areaEnter;

	private void Awake()
	{
        areaEnter = GetComponentInChildren<AreaEnter>();
	}

	// Start is called before the first frame update
	void Start()
    {
        areaEnter.TransitionAreaName = transitionAreaName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            PlayerController.instance.TransitionName = transitionAreaName;
            SceneManager.LoadScene(sceneToLoad);
		}
	}
}

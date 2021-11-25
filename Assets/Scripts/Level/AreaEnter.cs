using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField]
    private string transitionAreaName;

    public string TransitionAreaName {  get { return transitionAreaName; } set { transitionAreaName = value; } }

    // Start is called before the first frame update
    void Start()
    {
        if (transitionAreaName == PlayerController.instance.TransitionName)
		{
            PlayerController.instance.transform.position = transform.position;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

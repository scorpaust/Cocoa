using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
	{
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        float verticalMovement = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontalMovement, verticalMovement);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private string transitionName;

    public string TransitionName { get { return transitionName; } set { transitionName = value; } }

    private Rigidbody2D rb;

    private Animator anim;

    private bool walking;

	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        if (instance == null)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
	{
        walking = rb.velocity != Vector2.zero;

        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        float verticalMovement = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        anim.SetBool("walk", walking);
        
        HandleFacingDirection(horizontalMovement);
    }

    private void HandleFacingDirection(float horizontalMovement)
	{
        Vector3 temp = transform.localScale;

        if (horizontalMovement == 1)
		{
            transform.localScale = new Vector3(-0.2f, 0.2f, 1f);
		}
        else if (horizontalMovement == -1)
		{
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
        else
		{
            transform.localScale = temp;
		}
	}
}

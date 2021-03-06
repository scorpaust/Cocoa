using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private string transitionName;

    public string TransitionName { get { return transitionName; } set { transitionName = value; } }

    [SerializeField]
    private Vector3 bottomLeftEdge;

    [SerializeField]
    private Vector3 topRightEdge;

    private Rigidbody2D rb;

    private Animator anim;

    private bool walking;

    private bool canMove = true;

    public bool CanMove { get { return canMove; } set { canMove = value; } }

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
        HandleOutOfBounds();

        Move();
    }

    private void Move()
	{
        walking = rb.velocity != Vector2.zero;

        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        float verticalMovement = Input.GetAxisRaw("Vertical");

        if (!canMove)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
        }

        anim.SetBool("walk", walking);
        
        if (canMove)
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

    private void HandleOutOfBounds()
	{
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(transform.position.z, bottomLeftEdge.z, topRightEdge.z)

            );
    }

    public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
	{
        bottomLeftEdge = bottomEdgeToSet;

        topRightEdge = topEdgeToSet;
	}
}

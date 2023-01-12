using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	Animator playerAnimator;

	float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;


	public static bool hadMoved = false;
	int direct = 0;

	public Transform leftReset,rightReset;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
		hadMoved = false;
	}

    // Update is called once per frame
    void Update()
	{
		if (!hadMoved)
		{
			if (Input.GetAxisRaw("Horizontal") != 0)
				hadMoved = true;
			playerAnimator.SetBool("HadMove", hadMoved);
		}
		else
		{ 
			float move = Input.GetAxisRaw("Horizontal");
			if (move == 0) horizontalMove = direct * runSpeed;
			else
			{
				direct = move > 0 ? 1 : -1;
				horizontalMove = direct * runSpeed;
			}
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
			if(collision.tag == "Wall")
            {
				if (transform.position.x < 0) transform.position = new Vector2(rightReset.position.x,transform.position.y);
				else transform.position = new Vector2(leftReset.position.x, transform.position.y);
			}
        }
    }
}
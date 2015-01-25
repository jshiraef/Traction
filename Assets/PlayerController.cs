using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {

	// player handling
	public float gravity = 20;
	public float walkSpeed = 8;
	public float runSpeed = 12;
	public float acceleration = 30;
	public float jumpHeight = 12;

	public Vector3 velocity = Vector3.zero;

	public const float GRAVITY_STRENGTH = 0.5f;

	float jumpCooldown;
	float jumpTweaker = .0025f;

	CharacterController controller;

	public float currentSpeed;
	public float targetSpeed;
	private Vector2 amountToMove;

	PlayerPhysics playerPhysics;
	

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		// testing new movement
		float speed = (Input.GetKey(KeyCode.B) ? runSpeed: walkSpeed);
		targetSpeed = Input.GetAxisRaw ("Horizontal") * -speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

		if(playerPhysics.movementStopped)	
		{
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		if(playerPhysics.grounded)
		{
			amountToMove.y = 0;
			
			// Jump
			if(Input.GetKey (KeyCode.V)) // second jump
			{
			amountToMove.y = jumpHeight;
			}
		}

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		
		playerPhysics.move (amountToMove * Time.deltaTime);
		
		float moveDirection = Input.GetAxisRaw ("Horizontal");
		
		transform.eulerAngles = (moveDirection > 0) ? Vector3.up * 180: Vector3.zero;
		
		if (Input.GetKey("up"))
		{
			transform.Translate (0, 0, (-Time.deltaTime * speed));
		}
		if (Input.GetKey("down"))
		{
			transform.Translate (0, 0, (Time.deltaTime * speed));
		}
//		
//		if (Input.GetKey("left"))
//		{
//			transform.Translate ((Time.deltaTime * speed), 0, 0);
//		}
//		
//		if (Input.GetKey("right"))
//		{
//			transform.Translate ((-Time.deltaTime * speed), 0, 0);
//		}


//		// Jumping code
//		if (controller.isGrounded) {
//			if (Input.GetKey ("space")) {
//				jumpCooldown = 150;
//			}
//			velocity.y = 0;
//		} 
//
//		if(jumpCooldown > 0)
//		{
//			controller.Move (Vector3.up * (jumpTweaker * jumpCooldown));
//			jumpCooldown -= Time.deltaTime * 300f;
//			velocity.y = 0;
//		}
//		
//		if(jumpCooldown < 0)
//		{
//			jumpCooldown = 0;
//		}	
//
//		velocity.y -= GRAVITY_STRENGTH * Time.deltaTime;
//
//		controller.Move(velocity) ;
		
	}

	// increment n towards target by speed
	private float IncrementTowards(float n, float target, float a) 
	{
		if(n == target)
		{
			return n;
		}
		
		else {
			float direction = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * direction;
			return( direction == Mathf.Sign(target - n)) ? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
}


	
	
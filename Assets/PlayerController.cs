using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public Vector3 velocity = Vector3.zero;

	public const float GRAVITY_STRENGTH = 0.5f;

	float jumpCooldown;
	float jumpTweaker = .0025f;

	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey("up"))
		{
			transform.Translate (0, 0, (-Time.deltaTime * speed));
		}
		if (Input.GetKey("down"))
		{
			transform.Translate (0, 0, (Time.deltaTime * speed));
		}
		
		if (Input.GetKey("left"))
		{
			transform.Translate ((Time.deltaTime * speed), 0, 0);
		}
		
		if (Input.GetKey("right"))
		{
			transform.Translate ((-Time.deltaTime * speed), 0, 0);
		}


		// Jumping code
		if (controller.isGrounded) {
			if (Input.GetKey ("space")) {
				jumpCooldown = 150;
			}
			velocity.y = 0;
		} 

		if(jumpCooldown > 0)
		{
			controller.Move (Vector3.up * (jumpTweaker * jumpCooldown));
			jumpCooldown -= Time.deltaTime * 300f;
			velocity.y = 0;
		}
		
		if(jumpCooldown < 0)
		{
			jumpCooldown = 0;
		}	

		velocity.y -= GRAVITY_STRENGTH * Time.deltaTime;

		controller.Move(velocity) ;
		
	}


}

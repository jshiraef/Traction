using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 3f;
	public float jumpSpeed;
	public Vector3 gravity = Vector3.down;

	private bool isJumping;
	private bool isFalling;
	private bool isSliding;
	private bool grounded;

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

		if (controller.isGrounded) {
						if (Input.GetKey ("space")) {
								Debug.Log ("this happened");
								isJumping = true;
								controller.Move(Vector3.up * 100f);
			
						}
		
				} else {
						transform.Translate(gravity * Time.deltaTime) ;
						}

	}

	void onCollisionEnter3D()
	{
		if(collider.gameObject.tag == "Ground floor")
		{
			Debug.Log ("this is happening");
		}
	}

}

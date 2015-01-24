using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 1000f;
	public float jumpSpeed;
	public Vector3 gravity = Vector3.down * 0.1f;
	public Vector3 velocity = Vector3.zero;

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
				controller.Move(Vector3.up * 100f);
			}
			velocity.y = 0;
		} 

		velocity += gravity * Time.deltaTime;

		controller.Move(velocity) ;
		
	}


}

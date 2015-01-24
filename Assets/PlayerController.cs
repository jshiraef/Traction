using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey("up"))
		    {
			transform.Translate (0, 0, (Time.deltaTime * speed));
			}

		if (Input.GetKey("down"))
		{
			transform.Translate (0, 0, (-Time.deltaTime * speed));
		}

		if (Input.GetKey("left"))
		{
			transform.Translate ((-Time.deltaTime * speed), 0, 0);
		}

		if (Input.GetKey("right"))
		{
			transform.Translate ((Time.deltaTime * speed), 0, 0);
		}

	}
}

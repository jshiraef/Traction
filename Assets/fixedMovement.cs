using UnityEngine;
using System.Collections;

public class fixedMovement : MonoBehaviour {

	Vector3 startPosition; 
	private bool movingLeft = false;

		
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.transform.position.x < 0  || this.gameObject.transform.position.x > 30)
		{
			movingLeft = !movingLeft;
		}
		if(movingLeft)
		{
			this.gameObject.transform.Translate(new Vector3(Time.deltaTime * 10f, 0 ,0));
		}
		
		else 
		{
			this.gameObject.transform.Translate(new Vector3(-Time.deltaTime * 10f, 0 ,0));
		}
	}


}

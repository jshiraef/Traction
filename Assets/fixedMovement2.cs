using UnityEngine;
using System.Collections;

public class fixedMovement2 : MonoBehaviour {
	
	Vector3 startPosition; 
	private bool movingLeft = false;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.transform.position.z < -10  || this.gameObject.transform.position.z > 20)
		{
			movingLeft = !movingLeft;
		}
		if(movingLeft)
		{
			this.gameObject.transform.Translate(new Vector3(0,0, Time.deltaTime * 10f ));
		}
		
		else 
		{
			this.gameObject.transform.Translate(new Vector3(0, 0, -Time.deltaTime * 10f));
		}
	}
	
	
}

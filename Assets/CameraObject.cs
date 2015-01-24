using UnityEngine;
using System.Collections;

public class CameraObject : MonoBehaviour {

	private Vector3 movement;
	private Vector3 position;
	private Vector3 distanceFromPlayer = new Vector3(0, 0, 0);


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// ControlCameraWithInputAxes ();

		MoveCameraToPlayerLocation ();
	}

	void ControlCameraWithInputAxes() {
		float xAxisValue = Input.GetAxis ("Horizontal");
		float yAxisValue = Input.GetAxis ("Vertical");
		if (Camera.current != null) {
				Camera.current.transform.Translate (new Vector3 (xAxisValue, yAxisValue, 0f));
		}
	}

	void MoveCameraToPlayerLocation() {
		
		// Get the player
		//Component player = GetComponent("Player") as Component;
		GameObject player = GameObject.Find("Player");
		
		if (Camera.current != null) {
			Camera.current.transform.position = player.transform.position;
		}
	}

}

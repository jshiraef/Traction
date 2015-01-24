using UnityEngine;
using System.Collections;

public class CameraObject : MonoBehaviour {

	private static Vector3 DISTANCE_FROM_PLAYER =
		new Vector3(0.4f, 0.3f, 0.5f);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		 //ControlCameraWithInputAxes ();
		//ControlOffsetWithInputAxes ();

		MoveCameraToPlayerLocation ();
	}

	void ControlCameraWithInputAxes() {
		float xAxisValue = Input.GetAxis ("Horizontal");
		float yAxisValue = Input.GetAxis ("Vertical");
		if (Camera.current != null) {
			Camera.current.transform.Translate (new Vector3 (xAxisValue, yAxisValue, 0f));
		}
	}

	void ControlOffsetWithInputAxes() {
		float xAxisValue = Input.GetAxis ("Horizontal");
		float yAxisValue = Input.GetAxis ("Vertical");
		DISTANCE_FROM_PLAYER.x += xAxisValue/100;
		DISTANCE_FROM_PLAYER.y += yAxisValue/100;
		Debug.Log (DISTANCE_FROM_PLAYER);
//		if (Camera.current != null) {
//			Camera.current.transform.Translate (new Vector3 (xAxisValue, yAxisValue, 0f));
//		}
	}

	void MoveCameraToPlayerLocation() {

		// Get the player
		//Component player = GetComponent("Player") as Component;
		GameObject player = GameObject.Find("Player");

		if (Camera.current != null) {
			Vector3 playerPos = player.transform.position;
			Vector3 newCameraPos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
			newCameraPos.x += DISTANCE_FROM_PLAYER.x;
			newCameraPos.y += DISTANCE_FROM_PLAYER.y;
			newCameraPos.z += DISTANCE_FROM_PLAYER.z;
			Camera.current.transform.position = newCameraPos;
			Camera.current.transform.LookAt (playerPos);
		}
	}

}

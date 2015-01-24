using UnityEngine;
using System.Collections;

public class CameraObject : MonoBehaviour {

	private static Vector3 DISTANCE_FROM_PLAYER =
		new Vector3(8.5f, 4.43f, -11.73f);


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
			Vector3 playerPos = player.transform.position;
			Vector3 newCameraPos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
			newCameraPos.x += DISTANCE_FROM_PLAYER.x;
			newCameraPos.y += DISTANCE_FROM_PLAYER.y;
			newCameraPos.z += DISTANCE_FROM_PLAYER.z;
			Camera.current.transform.position = newCameraPos;
		}
	}

}

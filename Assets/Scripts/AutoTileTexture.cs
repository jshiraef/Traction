using UnityEngine;
using System.Collections;
public class AutoTileTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	void OnDrawGizmos()
	{
		gameObject.renderer.sharedMaterial.SetTextureScale("_MainTex",
			new Vector2(
				gameObject.transform.lossyScale.x,
				gameObject.transform.lossyScale.y
			)
		);
	}
}

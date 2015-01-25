﻿using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider collider;
	private Vector3 s;
	private Vector3 c;
	
	private Vector3 originalSize;
	private Vector3 originalCenter;
	private float colliderScale;

	private int collisionDivisionX = 3;
	private int collisionDivisionY = 10;

	private float skin = .005f;

	[HideInInspector]
	public bool grounded;
	
	[HideInInspector]
	public bool movementStopped;

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {

	collider = GetComponent<BoxCollider>();
	colliderScale = transform.localScale.x;

	originalSize = collider.size;
	originalCenter = collider.center;

	setCollider(originalSize, originalCenter);
	
	}

	public void move(Vector3 moveAmount)
	{
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		
		Vector3 p = transform.position;

		// Check vertical collisions above and below
		grounded = false;

		for (int i = 0; i < collisionDivisionX; i++)
		{
			float direction = Mathf.Sign (deltaY);
			float x = (p.x + c.x - s.x/2) + s.x/(collisionDivisionX-1) * i; // Left, center and then rightmost point of collider
			float y = p.y + c.y + s.y/2 * direction; // bottom of collider

			ray = new Ray(new Vector2(x, y), new Vector2(0, direction));

			Debug.DrawRay (ray.origin, ray.direction);

			if(Physics.Raycast (ray, out hit, Mathf.Abs (deltaY) + skin, collisionMask))	
				{

					// Get distance between player and ground
					float dst = Vector3.Distance (ray.origin, hit.point);

					// Stop player's downwards movement after coming within skin width of a collider
					if(dst > skin)	
					{
						deltaY = dst * direction - skin * direction;
					}
					else 
					{
						deltaY = 0;
					}

					grounded = true;
					
					break;
					
					}
				}
				
			// check horizontal collisions (x-axis)
			
			movementStopped = false;

			for(int i = 0; i < 3; i ++)
			{
				float direction = Mathf.Sign (deltaX);
				float x = p.x + c.x + s.x/2 * direction;
				float y = p.y + c.y - s.y/2 + s.y/(collisionDivisionY - 1) * i;

				ray = new Ray(new Vector2(x,y), new Vector2(direction, 0));
				
				Debug.DrawRay (ray.origin, ray.direction);
				
				if(Physics.Raycast (ray, out hit, Mathf.Abs (deltaX) + skin, collisionMask))
				{
					// Get Distancs between player and object
					float dst = Vector3.Distance (ray.origin, hit.point);

					// Stop player's downwards movement after coming within skin width of a collider
					if(dst > skin)
					{
						deltaX = dst * direction - skin * direction;
					}
					else {
						deltaX = 0;
					}
					
					movementStopped = true;
					
					break;
				}

			}

			if(!grounded && !movementStopped)
			{
				Vector3 playerDir = new Vector3(deltaX, deltaY);
				Vector3 o = new Vector3(p.x + c.x + s.x/2 * Mathf.Sign (deltaX), p.y + c.y + s.y/2 * Mathf.Sign (deltaY));
				
				ray = new Ray(o, playerDir.normalized);
				
				if(Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaY * deltaY), collisionMask))
				{
					grounded = true;
					deltaY = 0;
				}
			}
			
			Vector2 finalTransform = new Vector2(deltaX, deltaY);
				
			transform.Translate (finalTransform, Space.World);
	}
		

						
					
	
	// Update is called once per frame
	void Update () {
	
	}

	 void setCollider(Vector3 size, Vector3 center)
	{
		collider.size = size;
		collider.center = center;
		
		s = size * colliderScale;
		c = center * colliderScale;

		
	}


}

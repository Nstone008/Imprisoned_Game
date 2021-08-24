using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMenuScript : MonoBehaviour {

	public float moveForce = 0f;
	private Rigidbody rbody;
	public Vector3 moveDir;
	public LayerMask whatisWall;
	public float maxDistFromWall = 0f;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		moveDir = ChooseDirection();
		transform.rotation = Quaternion.LookRotation(moveDir);
	}
	
	// Update is called once per frame
	void Update () {
		rbody.velocity = moveDir * moveForce;

		if (Physics.Raycast (transform.position, transform.forward, maxDistFromWall, whatisWall)) 
		{
			moveDir = ChooseDirection();
			transform.rotation = Quaternion.LookRotation(moveDir);
		}
	}

	Vector3 ChooseDirection()
	{
		bool facing = false;
		Vector3 temp = new Vector3 ();

		if (facing == true) 
		{
			Debug.Log (facing);
			temp = transform.forward;
			facing = false;
		} 
		else if (facing == false) 
		{
			Debug.Log (facing);
			temp = -transform.forward;
			facing = true;
		}

		return temp;
	}
}

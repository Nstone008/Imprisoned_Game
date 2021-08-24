/**
Date: 3/2/17
Name: Nick Stone
Script: Player controller
Goal: Player controller with possibility for controller and keyboard


**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Variable Declaration
	Rigidbody player;
	GameObject cam,
			   torch;
	public float sprintVar,
				 tempSpeed,
				 horizontalSpeed,
				 naturalSpeed;
	public InGameMenu PauseScript;
	public bool paused,
				endGameBool,
				gameStart,
				torchActive;

	Vector3 moveVec,
			speed;


	void Awake()
	{
		player = GetComponent<Rigidbody> ();
		torch = GameObject.FindGameObjectWithTag ("Torch");
		cam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	// Use this for initialization
	void Start () {

		//setting certain vaiables in the first frame
		moveVec = new Vector3(0, 0, 0);
		speed = new Vector3 (0, 0, 0);
		horizontalSpeed = 1.0f;
		paused = false;
		gameStart = true;
		player.freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (paused == false) 
		{
			if (gameStart == false) {
				//Aligns the Camera on the y axis based from the cameras position
				transform.rotation = Quaternion.Euler (0, cam.GetComponent<cameraLook> ().currentYRotation, 0);

				//Setting variables to a normal amount to stop the player
				//from constantly moving or having an enhanced speed
				moveVec = Vector3.zero;
				tempSpeed = naturalSpeed;

				//Not certain if necessary
				//for stairs
				speed = new Vector3 (moveVec.x, 0, moveVec.z);

				//Forward and side movement
				moveVec.x += Input.GetAxis ("Horizontal");
				moveVec.z += Input.GetAxis ("Vertical");

				//for stairs
				speed = horizontalSpeed * transform.TransformDirection (speed);
				speed.y = player.velocity.y;
				player.velocity = speed;

				if (Input.GetKeyDown ("f")) {
					if (torchActive == true) {
						torch.SetActive (false);
						torchActive = false;
					} else if (torchActive == false) {
						torch.SetActive (true);
						torchActive = true;
					} else {
						Debug.Log ("Ya fucked up bitch");
					}
				}

				//If left shift is pressed sprint acitivates
				if (Input.GetKey (KeyCode.LeftShift)) {
					tempSpeed *= sprintVar;
				}
				
				//Player momvement from the transform class
				transform.Translate (moveVec.normalized * tempSpeed * Time.deltaTime);
			}
		} 


	}
		
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "EndGame") 
		{
			Debug.Log (paused);
		}
	}
}

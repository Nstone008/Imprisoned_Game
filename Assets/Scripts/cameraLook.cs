using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLook : MonoBehaviour {

	public float lookSensitivity,
				 xRotation,
				 yRotation,
				 currentXRotation,
				 currentYRotation,
				 xRotationV,
				 yRotationV,
				 looksmoothDamp = 0.01f;
	public PlayerController player;
	
	// Update is called once per frame
	void Update () {

		if (player.paused == false) 
		{
			xRotation += Input.GetAxis ("Mouse Y") * lookSensitivity;
			yRotation -= Input.GetAxis ("Mouse X") * lookSensitivity;

			xRotation = Mathf.Clamp (xRotation, -45, 50);
			currentXRotation = Mathf.SmoothDamp (currentXRotation, xRotation, ref xRotationV, looksmoothDamp);
			currentYRotation = Mathf.SmoothDamp (currentYRotation, yRotation, ref yRotationV, looksmoothDamp);

			transform.rotation = Quaternion.Euler (xRotation, yRotation, 0);
		}
	}
}

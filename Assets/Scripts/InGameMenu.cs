/*
 * NEED TO CHECK FUNCTIONALITY
 * SCRIPTS ON PLAYER BUT BUTTONS NOT SET
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour {

	//Variable Declaration
	public enum MenuMode {Active, InActive}
	public MenuMode currentState;
	public SceneSwitch levelSwitch;
	public PlayerController player;
	public GameObject PauseMenu;

	void Awake(){
		currentState = MenuMode.InActive;
		PauseMenu.SetActive (false);
		levelSwitch = GetComponent<SceneSwitch>();
	}
		
	
	// Update is called once per frame
	void Update () {

		//State to show if game is paused and menu is visible
		switch (currentState) 
		{

		case MenuMode.InActive:
			PauseMenu.SetActive (false);
			player.paused = false;
			break;

		case MenuMode.Active:
			PauseMenu.SetActive (true);
			player.paused = true;
			break;

		}

		//Pause Game
		if (Input.GetKeyDown(KeyCode.P)) {
			Debug.Log ("P is pressed");
			OnPauseMenu();
		}
	}

	//Function to pause game called by pressing escape
	public void OnPauseMenu()
	{
		Debug.Log ("Game Paused");
		currentState = MenuMode.Active;
		//Cursor.lockState = CursorLockMode.Confined;
		Time.timeScale = 0;
	}

	//Only Activated Right now with button press
	public void LeaveMenu()
	{
		//Cursor.lockState = CursorLockMode.Locked;
		currentState = MenuMode.InActive;
		Time.timeScale = 1;
	}

	public void ReturnToMain()
	{
		levelSwitch.SceneLoading (0);
	}
		
}
	



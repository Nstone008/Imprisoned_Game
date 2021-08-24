using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	//Menu States
	public enum MenuStates{Main, Options};
	public MenuStates currentState;

	//Menu panel objects
	public GameObject mainMenu;
	public GameObject optionsMenu;

	//When Script first starts
	void Awake()
	{
		currentState = MenuStates.Main;
	}

	void Start()
	{
		Time.timeScale = 1;
	}

	void Update()
	{
		//Checks current menu states
		switch (currentState) 
		{
		case MenuStates.Main:
			
			//Sets active gameobject for main menu
			mainMenu.SetActive (true);
			optionsMenu.SetActive (false);
			//Cursor.lockState = CursorLockMode.Confined;
			break;

		case MenuStates.Options:

			//Sets active gameobject for options menu
			mainMenu.SetActive (false);
			optionsMenu.SetActive (true);
			break;

		}
	}
		

	//When Options Button is pressed
	public void OnOptions()
	{
		//Change menu state
		currentState = MenuStates.Options;
	}

	public void OnWindowedMode()
	{
		//Change Resolution to windowed/fullscreen
	}

	public void OnMainMenu()
	{
		//Change menu state
		currentState = MenuStates.Main;
	}
}

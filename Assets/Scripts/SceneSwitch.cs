using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour {

	/*
	 * NEED TO REMAKE CHARACTER CONTROLLER - DONE
	 * MAKE CHANGIN MENUS
	 * AI pathing and sound design - DONE
	 */
	bool firstLoad = false;
	GameMaster GM;
	PlayerController playerScript;
	private IEnumerator coroutine;

	void Awake()
	{
		firstLoad = false;
		GM = this.GetComponent<GameMaster>();
		coroutine = StartingGameWait ();
		playerScript; //Link to the player script to stop movment at start
	}

	void Start()
	{
		StartCoroutine(coroutine);
	}

	IEnumerator StartingGameWait()
	{
		yield return new WaitForSeconds(5f);
	}


	public void SceneLoading(int sceneIndex)
	{
		if (firstLoad == false) {
			SceneManager.LoadScene(sceneIndex);
			firstLoad = true;
			GM.mainMenu = false;
		} 
		else 
		{
			SceneManager.LoadScene(sceneIndex);
			GM.BeginFade(-1);
			StartCoroutine(coroutine);

		}
	}

	public void QuitProgram()
	{
		//For the Program when Built
		Application.Quit ();

		//Used for Game inside the Editor
		//UnityEditor.EditorApplication.isPlaying = false;
	}
}

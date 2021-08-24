using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	static GameMaster Instance;

	//Need this to randomize a player start location
	//PlayerController playerScript;
	SceneSwitch sceneScript;
	GameObject player;
	int RandomSpawnNumber;

	//Fade to Black Variables
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.08f;

	private int drawDepth = -1000;
	private float alpha = 1f;
	private int fadeDir = -1;
	public bool mainMenu = true;

	void Awake()
	{
		if (Instance != null) 
		{
			GameObject.Destroy(gameObject);
		} 
		else 
		{
			GameObject.DontDestroyOnLoad(gameObject);
			Instance = this;
		}

		player = GameObject.FindGameObjectWithTag ("Player");
		//playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		sceneScript = this.GetComponent<SceneSwitch>();
	}

	// Use this for initialization
	void Start () {

		if (mainMenu == false) {
			RandomSpawnNumber = Random.Range (0, 3);
			Debug.Log (RandomSpawnNumber.ToString ());
			if (RandomSpawnNumber == 0) {
				player.transform.position = new Vector3 (-15.12f, 8.559f, -23.158f);	
			} else if (RandomSpawnNumber == 1) {
				player.transform.position = new Vector3 (5.041f, 8.559f, -54.108f);
			} else if (RandomSpawnNumber == 2) {
				player.transform.position = new Vector3 (12.939f, 8.559f, -54.108f);
			} else {
				Debug.Log ("Ya missnumbered");
			}
		} 
	}

	void OnGUI()
	{
		if (mainMenu == false) {
			alpha += fadeDir * fadeSpeed * Time.deltaTime;

			alpha = Mathf.Clamp01 (alpha);

			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
		}
	}

	public float BeginFade(int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);
	}

	void OnSceneWasLoaded(Scene scene, LoadSceneMode loadscene)
	{
		Debug.Log("It has Fired");
		if (mainMenu == false) {
			sceneScript.SceneLoading (1);
		} 

	}

	void OnEnabled()
	{
		SceneManager.sceneLoaded += OnSceneWasLoaded;
	}



	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneWasLoaded;
	}
}

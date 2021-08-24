using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEnd : MonoBehaviour {

	//Variable
	public float movement;
	public GameObject monster;
	public SceneSwitch endGame;
	public bool endMovement;

	// Use this for initialization
	void Start () {
		endMovement = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (endMovement == true) 
		{
			monster.transform.Translate(Vector3.forward*movement);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			endGame.SceneLoading (0);
		}
	}

	public void EndGame()
	{
		endMovement = true;
	}
}

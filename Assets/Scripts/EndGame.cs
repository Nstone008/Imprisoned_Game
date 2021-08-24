using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	//Variable Declaration
	public PlayerController player;
	public MonsterEnd monster;
	public bool endMovement;


	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			player.paused = true;
			monster.EndGame ();
			Debug.Log (player.paused);
		}
	}
}

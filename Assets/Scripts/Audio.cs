using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Audio : MonoBehaviour {

	public AudioSource audiosong;

	// Use this for initialization
	void Start () {
		audiosong.Play();
	}

}

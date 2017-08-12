using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgSoundController : MonoBehaviour {

	private bool isDead = false;
	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		isDead = GameObject.Find("Player").GetComponent<PlayerMotor>().isDead;

		if (isDead) {
			if (audio.volume > 0.2) {
				audio.volume -= 0.1f * Time.deltaTime;
			}
		}
	}
}

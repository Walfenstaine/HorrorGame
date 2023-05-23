using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {
	public AudioClip clip;
	private CharacterController controller;
	private float timer = 0;

	void Start () {
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		if (controller.velocity.magnitude > 0.1f) {
			timer += controller.velocity.magnitude * Time.deltaTime;
		} else {
			timer = 0;
		}
		if (timer > 3) {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
			timer = 0;
		}
	}
}

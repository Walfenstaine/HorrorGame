using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour {
	public AudioClip clip{ get; set; }
	public static SoundMaster regit {get; set;}
	private AudioSource Audi;

	void Awake(){
		Audi = GetComponent<AudioSource> ();
		if (regit == null) {
			regit = this;
		} else {
			Destroy (this);
		}
	}
	void OnDestroy(){
		regit = null;
	}

	void Update () {
		if (clip != null) {
			Audi.PlayOneShot (clip);
			clip = null;
		}
	}
}

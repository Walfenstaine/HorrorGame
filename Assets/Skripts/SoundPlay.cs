using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour {
	public string masage;
	public AudioClip clip;
	void Start () {
		SubTitres.rid.image.enabled = true;
		SubTitres.rid.not = masage;
		if (clip != null) {
			SoundMaster.regit.clip = clip;
		}
	}
}

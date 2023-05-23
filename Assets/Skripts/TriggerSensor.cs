using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSensor : MonoBehaviour {
	public Sprite sprite;
	public Image loot, vesch;
	public string masage;
	public float spector = 20;
	public Transform cam;
	public AudioClip clip;
	public bool activate;
	private bool activ;
	private float vzglyad;

	void Start(){
		cam = Camera.main.transform;
	}
	void Update(){
		if (activ) {
			var looker = transform.position - cam.position;
			vzglyad = Quaternion.Angle (cam.rotation, Quaternion.LookRotation(looker));
			if (vzglyad <= spector) {
				if (loot != null) {
					vesch = Instantiate (loot);
					vesch.transform.SetParent(LootElement.regit.inventar, false);
					vesch.sprite = sprite;
					vesch.name = gameObject.name;
				}
				activate = true;
				activ = false;
				if (masage != null) {
                    SubtTitres.regit.subtitres = masage;
				}
				if (clip != null) {
                    SoundPlayer.regit.sorse.PlayOneShot(clip);
                }
			}
		} else {
			activate = false;
		}
	}
	void OnTriggerEnter(Collider oser){
		if (oser.tag == "Player") {
			activ = true;
		}
	}
	void OnTriggerExit(Collider oser){
		if (oser.tag == "Player") {
			activ = false;
		}
	}
}

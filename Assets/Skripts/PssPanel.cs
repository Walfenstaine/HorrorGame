using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PssPanel : MonoBehaviour {
	public AudioClip ok, coll;
	public string masage, okay;
	public DorOpener door;
	public UnityEvent activate, deactivate;
	public int password;
	private TriggerSensor sensor;
	public int not{ get; set; }
	public bool activ{ get; set; }
	public static PssPanel rec {get; set;}
	private float timer;

	void Awake(){
		if (rec == null) {
			rec = this;
		} else {
			Destroy (this);
		}
	}
	void OnDestroy(){
		rec = null;
	}
	void Start () {
		sensor = GetComponent<TriggerSensor> ();
		door.locked = true;
	}

	void Update () {
		if (activ) {
			if (not == password) {
				not = 0;
				activ = false;
				SoundMaster.regit.clip = ok;
				SubTitres.rid.image.enabled = true;
				SubTitres.rid.not = okay;
				door.locked = false;
			} else {
				if (not != 0) {
					activ = false;
					SoundMaster.regit.clip = coll;
					SubTitres.rid.image.enabled = true;
					SubTitres.rid.not = masage;
				}
			}
		} else {
			deactivate.Invoke ();
			not = 0;
		}




		if (sensor.activate) {
			activate.Invoke ();
			Cursor_Event.regit.curActiv = true;
			activ = true;
		} else {
			return;
		}
	}
}

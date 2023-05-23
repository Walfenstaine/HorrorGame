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
    private Interface iF;
	void Awake(){
        iF = Interface.rid;
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
                iF.CursorOn();
                SoundPlayer.regit.sorse.PlayOneShot(ok);
                SubtTitres.regit.subtitres = okay;
				door.locked = false;
			} else {
				if (not != 0) {
					activ = false;
                    iF.CursorOn();
                    SoundPlayer.regit.sorse.PlayOneShot(coll);
                    SubtTitres.regit.subtitres = masage;
				}
			}
		} else {
			deactivate.Invoke ();
			not = 0;
		}




		if (sensor.activate) {
			activate.Invoke ();
            iF.CursorOff();
			activ = true;
		} else {
			return;
		}
	}
}

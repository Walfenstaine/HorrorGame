using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSkript : MonoBehaviour {
	public string text;
	private TriggerSensor sensor;
    private Interface iF;
	void Start () {
		sensor = GetComponent<TriggerSensor> ();
        iF = Interface.rid;
    }

	void Update () {
		if (sensor.activate) {
			NoteRider.regit.activate = true;
            iF.CursorOn();
            NoteRider.regit.not = text;
		}
	}
}

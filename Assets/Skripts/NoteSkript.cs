using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSkript : MonoBehaviour {
	public string text;
	private TriggerSensor sensor;

	void Start () {
		sensor = GetComponent<TriggerSensor> ();
	}

	void Update () {
		if (sensor.activate) {
			NoteRider.regit.activate = true;
			Cursor_Event.regit.curActiv = true;
			NoteRider.regit.not = text;
		}
	}
}

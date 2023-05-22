using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavelAnd : MonoBehaviour {
	public string level;
	private TriggerSensor sensor;

	void Start () {
		sensor = GetComponent<TriggerSensor> ();
	}

	void Update () {
		if (sensor.activate) {
			SceneManager.LoadScene (level);
		}
	}
}

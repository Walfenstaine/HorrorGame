using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elschid : MonoBehaviour {
	public string masage;
	public string worning;
	public Riscag cranc;
	public bool[] isTool;
	public GameObject[] tools;
	public TriggerSensor[] invens;
	public TriggerSensor sensor;
	public string[] names;

	void Start () {
		
	}

	void Update () {
		for (int i = 0; i < invens.Length; i++) {
			if (invens [i].activate) {
				names [i] = invens [i].name;
				isTool [i] = true;
				invens [i].gameObject.SetActive (false);
			}
		}
		if (sensor != null) {
			for (int i = 0; i < isTool.Length; i++) {
				if (isTool [i] == true) {
					cranc.oKay = true;
				} else {
					cranc.oKay = false;
				}
			}
			if (sensor.activate) {
				for (int i = 0; i < tools.Length; i++) {
					tools [i].SetActive (isTool [i]);
					Destroy (GameObject.Find (names [i]));
				}
				if (cranc.oKay) {
                    SubtTitres.regit.subtitres = masage;
				} else {
                    SubtTitres.regit.subtitres = worning;
				}
			}
		}
	}
}

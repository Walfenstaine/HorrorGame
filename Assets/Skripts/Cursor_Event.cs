using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Event : MonoBehaviour {
	public bool curActiv{ get; set; }
	public static Cursor_Event regit {get; set;}

	void Awake(){
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
		Cursor.visible = curActiv;
		if (curActiv) {
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1;
		}
	}
}

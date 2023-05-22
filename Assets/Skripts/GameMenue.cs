using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenue : MonoBehaviour {
	public NoteRider rider;
	public GameObject[] podmenues;
	public int num{ get; set; }
	public static GameMenue regit {get; set;}

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
	public void Menue(){
		num = 1;
		Cursor_Event.regit.curActiv = true;
		rider.Closed ();
		if (PssPanel.rec) {
			PssPanel.rec.activ = false;
		}

	}
	public void Gaming(){
		num = 0;
		Cursor_Event.regit.curActiv = false;
	}
	public void Quiter(){
		SceneManager.LoadScene ("MainMenue");
	}
	void Update () {
		if (num == 0) {
			if (Input.GetKeyDown (KeyCode.Tab)) {
				Menue ();
			}
		} else {
		}
		for (int i = 0; i < podmenues.Length; i++) {
			if (i == num) {
				podmenues [i].SetActive (true);
			} else {
				podmenues [i].SetActive (false);
			}
		}
	}
}

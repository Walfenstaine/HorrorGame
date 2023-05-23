using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteRider : MonoBehaviour {
	public Text text;
	public GameObject image;
	public bool activate{ get; set; }
	public string not{ get; set; }
	public static NoteRider regit {get; set;}
    private Interface iF;
	void Awake(){
        iF = Interface.rid;
        if (regit == null) {
			regit = this;
		} else {
			Destroy (this);
		}
	}
	void OnDestroy(){
		regit = null;
	}
	public void Deleyted(){
		activate = false;
        iF.CursorOff();
    }
	public void Closed(){
		activate = false;
	}
	void Update () {
		image.SetActive (activate);
		text.text = not; 
	}
}

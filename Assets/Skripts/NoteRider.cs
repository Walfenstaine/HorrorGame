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
    public Interface iF;
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
	public void Deleyted(){
		activate = false;
        iF.CursorOn();
    }
	public void Closed(){
		activate = false;
	}
	void Update () {
		image.SetActive (activate);
        if (activate)
        {
            iF.CursorOff();
        }
		text.text = not; 
	}
}

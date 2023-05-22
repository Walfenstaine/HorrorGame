using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Passworder : MonoBehaviour {
	public int number;
	public int maxKeys;
	public Button[] butt;
	public Text displayText;
	public GameObject panel;

	public void Activate(){
		panel.SetActive (true);
		Cursor_Event.regit.curActiv = true;
	}
	public void DeActivate(){
		panel.SetActive (false);
		PssPanel.rec.activ = false;
		Deselect ();
	}

	void Deselect(){
		if (PssPanel.rec.activ) {
			Cursor_Event.regit.curActiv = false;
		}
		PssPanel.rec.activ = false;
		number = 0;
		displayText.text = "";
	}
	void Select(){
		if (PssPanel.rec.activ) {
			Cursor_Event.regit.curActiv = false;
		}
		PssPanel.rec.not = number;
		if (PssPanel.rec.not == 0) {
			PssPanel.rec.activ = false;
		}
	}

     void OnEnable(){
		for (int i = 0; i < butt.Length; i++){
			Add(i);
		}
		number = 0;
		displayText.text = "";
	}
	 void OnDisable(){
		for (int i = butt.Length - 1; i >=0; i--){
			Remove(i);
		}
	}
	void Add(int i){
		butt[i].onClick.AddListener(delegate { Click(i);});
	}
	void Remove(int i){
		butt[i].onClick.RemoveAllListeners();
	}
	void Click(int i){
		if (displayText.text.Length >= maxKeys) {
			OnDisable ();
		} else {
			number = 10 * number + i;
			displayText.text = "" + number;
		}
	}
}
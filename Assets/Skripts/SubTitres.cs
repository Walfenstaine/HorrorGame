using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubTitres : MonoBehaviour {
	public float tim { get; set; }
	public Text text;
	public Image image{ get; set; }
	public string not{ get; set; }
	public static SubTitres rid {get; set;}
	private float timer;

	void Awake(){
		timer = 0;
		image = GetComponent<Image> ();
		image.enabled = false;
		if (rid == null) {
			rid = this;
		} else {
			Destroy (this);
		}
	}
	void OnDestroy(){
		rid = null;
	}

	void Update () {
		if (not != null) {
			text.text = not;
		} 
		if (image.enabled) {
			timer += Time.unscaledDeltaTime;
		}
		if (timer > tim) {
			image.enabled = false;
			timer = 0;
			not = "";
		}
	}
}

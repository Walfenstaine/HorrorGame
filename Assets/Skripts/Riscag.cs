using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riscag : MonoBehaviour {
	public ParticleSystem ps;
	public GameObject mechanizm;
	public bool oKay;
	public GameObject[] tools;
	public TriggerSensor sensor;
	public float sens;
	public AudioClip clip;
	private bool activate;
	private float rut;

	void Start () {
		rut = transform.localEulerAngles.x;
	}

	void oK(){
		if (sensor != null) {
			if (sensor.activate) {
				activate = true;
			}
		}
		if (activate) {
			transform.localEulerAngles = new Vector3 (rut,0,0);
			if (rut < 360) {
				rut += sens * Time.deltaTime;
			} else {
				ps.Play ();
				mechanizm.SetActive (true);
				SoundMaster.regit.clip = clip;
				activate = false;
				Destroy (sensor.gameObject,1);
			}
		}
	}

	void Update () {
		if (oKay) {
			oK ();
		}
	}
}

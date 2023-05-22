using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiftController : MonoBehaviour {
	public string level;
	public AudioClip clip;
	public TriggerSensor opene, closer, deactiveter;
	public bool open;
	public Transform dorl, dorr;
	private Vector3 l, r;
	public float timer;
	private bool run;
	void Start () {
		timer = 0;
		l = new Vector3(1.8f,0,-0.2f);
		r = new Vector3(-1.8f,0,-0.2f);
	}
	public void LiftMuve(){
		if (timer < 15) {
		}
	}

	void Update () {
		if (deactiveter != null) {
			if (deactiveter.activate) {
				opene.gameObject.SetActive (false);
				closer.gameObject.SetActive (true);
				Destroy(deactiveter.gameObject, 1);
				open = false;
			}
		}

		if (opene.activate) {
			open = true;
		}
		if (closer.activate) {
			opene.gameObject.SetActive (false);
			open = false;
			run = true;
			if (timer == 0) {
				MusikMaster.regit.clip = clip;
			}
		}
		if (run) {
			if (timer < 15) {
				timer += Time.deltaTime;
			} else {
				SceneManager.LoadScene (level);
			}
		}
		if (open) {
			dorl.localPosition = Vector3.Lerp (dorl.localPosition, l, 3 * Time.deltaTime);
			dorr.localPosition = Vector3.Lerp (dorr.localPosition, r, 3 * Time.deltaTime);
		} else {
			dorl.localPosition = Vector3.Lerp (dorl.localPosition, new Vector3(0,0,-0.2f), 3 * Time.deltaTime);
			dorr.localPosition = Vector3.Lerp (dorr.localPosition, new Vector3(0,0,-0.2f), 3 * Time.deltaTime);
		}
	}
}

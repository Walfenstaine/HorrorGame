using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasks : MonoBehaviour {
	public AudioClip clos, opyen;
	public bool locked = true;
	public string loced, opened;
	public BoxCollider bk;
	public TriggerSensor fomka;
	private TriggerSensor censor;
	private string nam;

	void Start () {
		censor = GetComponent<TriggerSensor> ();
	}

	void Update () {
		if (fomka != null) {
			if (fomka.activate) {
				nam = fomka.name;
				Destroy (fomka.gameObject);
				locked = false;
			}
		}

		if (locked) {
			censor.clip = clos;
			censor.masage = loced;
		} else {
			censor.clip = opyen;
			if (censor.activate) {
				Destroy(GameObject.Find(nam));
				bk.enabled = true;
				Destroy (gameObject);
			}
			censor.masage = opened;
		}
	}
}

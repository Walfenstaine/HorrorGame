using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorOpener : MonoBehaviour {
	public float timer = 3;
	public string masage;
	public string masageClose;
	public GameObject kay;
	public TriggerSensor key;
	public AudioClip[] clips;
	public Transform door;
	public bool locked, open;
	private Vector3 nap;
	private string nam;

	void Start () {
		nap = transform.position - transform.right - transform.forward;
	}
	void OnTriggerEnter(Collider oser){
		if (oser.tag == "Player") {
			if (!locked) {
				Destroy(GameObject.Find(nam));
				if (kay != null) {
					kay.SetActive (true);
				}
				open = true;
				SubTitres.rid.image.enabled = true;
				SubTitres.rid.not = masage;
				SubTitres.rid.tim = timer;
				SoundMaster.regit.clip = clips [0];
				Destroy (this,1);
				Destroy (GetComponent<BoxCollider>(),1);
			} else {
				SoundMaster.regit.clip = clips [1];
				SubTitres.rid.image.enabled = true;
				SubTitres.rid.not = masageClose;
			}
		}
	}
	void Update () {
		if (key != null) {
			if (key.activate) {
				nam = key.name;
				locked = false;
				Destroy (key.gameObject);
			}
		} 
		if (open) {
			var lookder = nap - door.transform.position;
			door.transform.rotation = Quaternion.Lerp (door.transform.rotation, Quaternion.LookRotation (lookder), 5 * Time.deltaTime);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorOpener : MonoBehaviour {
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
                SubtTitres.regit.subtitres = masage;
				SoundPlayer.regit.sorse.PlayOneShot(clips[0]);
				Destroy (this,1);
				Destroy (GetComponent<BoxCollider>(),1);
			} else {
                SoundPlayer.regit.sorse.PlayOneShot(clips[1]);
                SubtTitres.regit.subtitres = masageClose;
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

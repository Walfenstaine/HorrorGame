using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour {

	private Muwer muwer;
    private Interface iF;
	// Use this for initialization
	void Start () {
        muwer = Muwer.rid;
        iF = Interface.rid;
	}
	

	void Update () {
		muwer.muve = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape))
        {
            iF.Menue();
        }
	}
}

﻿using UnityEngine;
using System.Collections;

public class LearnModeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//--------------------------------------------------------------------------//
	//	CloseClickEvent
	//--------------------------------------------------------------------------//
	public void CloseClickEvent ()
	{
		ModeManager.GoBack ();
	}
}

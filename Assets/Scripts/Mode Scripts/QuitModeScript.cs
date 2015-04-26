using UnityEngine;
using System.Collections;

public class QuitModeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//--------------------------------------------------------------------------//
	//	YesClickEvent
	//--------------------------------------------------------------------------//
	public void YesClickEvent ()
	{
		Application.Quit ();
	}
	//--------------------------------------------------------------------------//
	//	NoClickEvent
	//--------------------------------------------------------------------------//
	public void NoClickEvent ()
	{
		ModeManager.GoBack ();
	}
}

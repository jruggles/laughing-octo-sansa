using UnityEngine;
using System.Collections;

public class RestartModeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//--------------------------------------------------------------------------//
	//	NewGameClickEvent
	//--------------------------------------------------------------------------//
	public void NewGameClickEvent ()
	{
		Application.Quit ();
	}
	//--------------------------------------------------------------------------//
	//	ContinueClickEvent
	//--------------------------------------------------------------------------//
	public void ContinueClickEvent ()
	{
		ModeManager.GoBack ();
	}
	//--------------------------------------------------------------------------//
	//	QuitClickEvent
	//--------------------------------------------------------------------------//
	public void QuitClickEvent ()
	{
		ModeManager.GoBack ();
	}
}

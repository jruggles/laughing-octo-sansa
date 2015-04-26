using UnityEngine;
using System.Collections;

public class TrackModeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//--------------------------------------------------------------------------//
	//	BackClickEvent
	//--------------------------------------------------------------------------//
	public void BackClickEvent ()
	{
		ModeManager.GoBack ();
	}
	//--------------------------------------------------------------------------//
	//	OKClickEvent
	//--------------------------------------------------------------------------//
	public void OKClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.Character);
	}
}

using UnityEngine;
using System.Collections;

public class GameOverModeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//--------------------------------------------------------------------------//
	//	PlayAgainClickEvent
	//--------------------------------------------------------------------------//
	public void PlayAgainClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.Track);
	}
	//--------------------------------------------------------------------------//
	//	QuitClickEvent
	//--------------------------------------------------------------------------//
	public void QuitClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.Quit);
	}
}

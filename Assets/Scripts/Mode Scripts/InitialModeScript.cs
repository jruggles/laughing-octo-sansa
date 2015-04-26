using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InitialModeScript : MonoBehaviour
{
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	//--------------------------------------------------------------------------//
	//	PlayClickEvent
	//--------------------------------------------------------------------------//
	public void PlayClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.Track);
	}
	//--------------------------------------------------------------------------//
	//	AboutClickEvent
	//--------------------------------------------------------------------------//
	public void AboutClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.About);
	}
	//--------------------------------------------------------------------------//
	//	LearnClickEvent
	//--------------------------------------------------------------------------//
	public void LearnClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.Learn);
	}
	//--------------------------------------------------------------------------//
	//	OptionsClickEvent
	//--------------------------------------------------------------------------//
	public void OptionsClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.Options);
	}
	//--------------------------------------------------------------------------//
	//	QuitClickEvent
	//--------------------------------------------------------------------------//
	public void QuitClickEvent ()
	{
		ModeManager.ChangeTo (ModeManager.Mode.Quit);
	}

}

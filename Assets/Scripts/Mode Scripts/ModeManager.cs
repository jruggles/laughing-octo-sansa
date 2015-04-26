using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModeManager : MonoBehaviour
{
	//////////////////////////////////////////////////////////////////////////////
	//	THESE TYPES MAY BE MOVED TO ANOTHER CLASS IF APPROPRIATE.
	//////////////////////////////////////////////////////////////////////////////

	//==========================================================================//
	//	Track enumerations
	//==========================================================================//
	public enum Track
	{
		Cloud,
		Forest,
		Wooden
	};

	//==========================================================================//
	//	Avatar enumerations
	//==========================================================================//
	public enum Avatar
	{
		Moe,
		Larry,
		Curly
	};

	//==========================================================================//
	//	PlayerChoices enumerations - game play parameters
	//==========================================================================//
	public struct PlayerChoices
	{
		Track	track;
		Avatar 	avatar;
	};
	
	//==========================================================================//
	//	Settings - audio volumes, etc/.
	//==========================================================================//
	public struct Settings
	{
		float 	musicVol;
		bool	isMusicMuted;
		float 	effectsVol;
		bool 	areEffectsMuted;
	};

	public static PlayerChoices	playerChoices;
	public static Settings			settings;
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////


	public enum Mode
	{
		Initial,
		About,
		Learn,
		Options,
		Track,
		Character,
		Play,
		GameOver,
		Restart,
		Quit
	}
	
	static Stack<Mode>	hist = new Stack<Mode>();

	//--------------------------------------------------------------------------//
	//	Start
	//
	//	Loads Initial Mode scene.
	//--------------------------------------------------------------------------//
	void Start ()
	{
		DontDestroyOnLoad (this.gameObject);

		//	Set defaults on playerChoices and settings here

		ChangeTo (Mode.Initial);
	}

	//--------------------------------------------------------------------------//
	//	GetSceneName
	//
	//	Returns the scene name corresponding to the mode enumeration.
	//--------------------------------------------------------------------------//
	static private	string GetSceneName(Mode mode)
	{
		switch (mode)
		{
			case		Mode.Initial:	return	"Initial Mode";
			case		Mode.About:		return	"About Mode";
			case		Mode.Learn:		return	"Learn Mode";
			case		Mode.Options:	return	"Options Mode";
			case		Mode.Track:		return	"Track Mode";
			case		Mode.Character:	return	"Character Mode";
			case		Mode.Play:		return	"Play Mode";
			case		Mode.GameOver:	return	"Game Over Mode";
			case		Mode.Restart:	return	"Restart Mode";
			case		Mode.Quit:		return	"Quit Mode";
		}
		return "";
	}

	//--------------------------------------------------------------------------//
	//	ChangeTo
	//
	//	Changes to the scene for the specified new mode.
	//--------------------------------------------------------------------------//
	static public void ChangeTo(Mode newMode)
	{
		if (newMode == Mode.Play)
		{
			//	Clear mode history so it doesn't grow infinitely
			//	There's no going back here anyway
			hist.Clear ();
			hist.Push (newMode);

			//	For Play mode, scene needs to be chosen by track
			//	Need to do LoadLevel here for correct track
		}
		else
		{
			hist.Push (newMode);
			Application.LoadLevel (GetSceneName (newMode));
		}
	}

	//--------------------------------------------------------------------------//
	//	GoBack
	//
	//	Changes to the scene for the mode you came from.
	//--------------------------------------------------------------------------//
	static public void GoBack()
	{
		hist.Pop ();
		Application.LoadLevel(GetSceneName (hist.Peek ()));
	}

}

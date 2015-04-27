using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TrackModeScript : MonoBehaviour
{
	Toggle	cloudTrackToggle;
	Toggle	forestTrackToggle;
	Toggle	woodenTrackToggle;

	//--------------------------------------------------------------------------//
	//	Start
	//--------------------------------------------------------------------------//
	void Start ()
	{
		cloudTrackToggle	=	GameObject.Find
								("CloudTrackToggle").GetComponent<Toggle>	();
		
		forestTrackToggle	=	GameObject.Find
								("ForestTrackToggle").GetComponent<Toggle>	();
		
		woodenTrackToggle	=	GameObject.Find
								("WoodenTrackToggle").GetComponent<Toggle>	();

		switch (ModeManager.playerChoices.track)
		{
			case	ModeManager.Track.Cloud:
				cloudTrackToggle.isOn	=	true;
				forestTrackToggle.isOn	= false;
				woodenTrackToggle.isOn	= false;
				break;
			case	ModeManager.Track.Forest:
				forestTrackToggle.isOn	=	true;
				cloudTrackToggle.isOn	= false;
				woodenTrackToggle.isOn	= false;
				break;
			case	ModeManager.Track.Wooden:
				woodenTrackToggle.isOn	=	true;
				forestTrackToggle.isOn	= false;
				woodenTrackToggle.isOn	= false;
				break;
		}
	}
	
	//--------------------------------------------------------------------------//
	//	CloudToggleChanged
	//--------------------------------------------------------------------------//
	public void CloudToggleChanged	(bool isOn)
	{
		if (isOn)	ModeManager.playerChoices.track	=	ModeManager.Track.Cloud;
	}
	//--------------------------------------------------------------------------//
	//	ForestToggleChanged
	//--------------------------------------------------------------------------//
	public void ForestToggleChanged (bool isOn)
	{
		if (isOn)	ModeManager.playerChoices.track = ModeManager.Track.Forest;
	}
	//--------------------------------------------------------------------------//
	//	WoodenToggleChanged
	//--------------------------------------------------------------------------//
	public void WoodenToggleChanged (bool isOn)
	{
		if (isOn)	ModeManager.playerChoices.track = ModeManager.Track.Wooden;
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

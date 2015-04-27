using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterModeScript : MonoBehaviour
{
	Toggle	moeToggle;
	Toggle	larryToggle;
	Toggle	curlyToggle;
	
	//--------------------------------------------------------------------------//
	//	Start
	//--------------------------------------------------------------------------//
	void Start ()
	{
		moeToggle	=	GameObject.Find
						("MoeToggle").GetComponent<Toggle>		();
		
		larryToggle	=	GameObject.Find
						("LarryToggle").GetComponent<Toggle>	();
		
		curlyToggle	=	GameObject.Find
						("CurlyToggle").GetComponent<Toggle>	();
		
		switch (ModeManager.playerChoices.avatar)
		{
			case	ModeManager.Avatar.Moe:
				moeToggle.isOn		=	true;
				larryToggle.isOn	= false;
				curlyToggle.isOn	= false;
				break;
			case	ModeManager.Avatar.Larry:
				larryToggle.isOn	=	true;
				moeToggle.isOn		= false;
				curlyToggle.isOn	= false;
				break;
			case	ModeManager.Avatar.Curly:
				moeToggle.isOn		= false;
				larryToggle.isOn	= false;
				curlyToggle.isOn	=	true;
				break;
		}
	}	
	//--------------------------------------------------------------------------//
	//	MoeToggleChanged
	//--------------------------------------------------------------------------//
	public void MoeToggleChanged	(bool isOn)
	{
		if (isOn)	ModeManager.playerChoices.avatar	= ModeManager.Avatar.Moe;
	}
	//--------------------------------------------------------------------------//
	//	LarryToggleChanged
	//--------------------------------------------------------------------------//
	public void LarryToggleChanged (bool isOn)
	{
		if (isOn)	ModeManager.playerChoices.avatar	= ModeManager.Avatar.Larry;
	}
	//--------------------------------------------------------------------------//
	//	CurlyToggleChanged
	//--------------------------------------------------------------------------//
	public void CurlyToggleChanged (bool isOn)
	{
		if (isOn)	ModeManager.playerChoices.avatar	= ModeManager.Avatar.Curly;
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
		ModeManager.ChangeTo (ModeManager.Mode.Play);
	}
}

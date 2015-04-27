using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterModeScript : MonoBehaviour
{
	Toggle[,]	tog = new Toggle[3,3];

	//--------------------------------------------------------------------------//
	//	Start
	//--------------------------------------------------------------------------//
	void Start ()
	{
		string togName;

		ModeManager.playerChoices.avatar = ModeManager.Avatar.Kart1Player1;

		for (int k = 1; k <= 3; k++)
			for(int p = 1; p <= 3; p++)
			{
				togName	=	"K" + k + "P" + p + "Toggle";
				tog[k-1,p-1] = GameObject.Find(togName).GetComponent<Toggle>();
			}

		//	Initialize toggles

		switch (ModeManager.playerChoices.avatar)
		{
		case	ModeManager.Avatar.Kart1Player1:
			tog[0,0].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart1Player2:
			tog[0,1].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart1Player3:
			tog[0,2].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart2Player1:
			tog[1,0].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart2Player2:
			tog[1,1].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart2Player3:
			tog[1,2].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart3Player1:
			tog[2,0].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart3Player2:
			tog[2,1].isOn		=	true;
			break;
		case	ModeManager.Avatar.Kart3Player3:
			tog[2,2].isOn		=	true;
			break;
		}
	}	
	//--------------------------------------------------------------------------//
	//	K1P1ToggleChanged
	//--------------------------------------------------------------------------//
	public void K1P1ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart1Player1;
	}
	//--------------------------------------------------------------------------//
	//	K1P2ToggleChanged
	//--------------------------------------------------------------------------//
	public void K1P2ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart1Player2;
	}
	//--------------------------------------------------------------------------//
	//	K1P3ToggleChanged
	//--------------------------------------------------------------------------//
	public void K1P3ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart1Player3;
	}

	//--------------------------------------------------------------------------//
	//	K2P1ToggleChanged
	//--------------------------------------------------------------------------//
	public void K2P1ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart2Player1;
	}
	//--------------------------------------------------------------------------//
	//	K2P2ToggleChanged
	//--------------------------------------------------------------------------//
	public void K2P2ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart2Player2;
	}
	//--------------------------------------------------------------------------//
	//	K2P3ToggleChanged
	//--------------------------------------------------------------------------//
	public void K2P3ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart2Player3;
	}
	//--------------------------------------------------------------------------//
	//	K3P1ToggleChanged
	//--------------------------------------------------------------------------//
	public void K3P1ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart3Player1;
	}
	//--------------------------------------------------------------------------//
	//	K3P2ToggleChanged
	//--------------------------------------------------------------------------//
	public void K3P2ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart3Player2;
	}
	//--------------------------------------------------------------------------//
	//	K3P3ToggleChanged
	//--------------------------------------------------------------------------//
	public void K3P3ToggleChanged	(bool isOn)
	{
		if (isOn)
			ModeManager.playerChoices.avatar	= ModeManager.Avatar.Kart3Player3;
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

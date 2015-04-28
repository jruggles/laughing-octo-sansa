using UnityEngine;
using System.Collections;

public class TrackScript : MonoBehaviour
{
	static private	GameObject 	cartPrefab;
	static public	GameObject	cart;
	static public	GameObject	aiCart1;
	static public	GameObject	aiCart2;

	//--------------------------------------------------------------------------//
	//	Start
	//
	//	Loads Initial Mode scene.
	//--------------------------------------------------------------------------//
	void Start ()
	{
		//	Find the correct prefab based on ModeManager.playerChoices.avatar

		switch (ModeManager.playerChoices.avatar)
		{
			case	ModeManager.Avatar.Kart1Player1:
				cartPrefab = (GameObject)	Resources.Load
					("kart1Player1", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart1Player2:
				cartPrefab = (GameObject)	Resources.Load
					("kart1Player2", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart1Player3:
				cartPrefab = (GameObject)	Resources.Load
					("kart1Player3", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart2Player1:
				cartPrefab = (GameObject)	Resources.Load
					("kart2Player1", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart2Player2:
				cartPrefab = (GameObject)	Resources.Load
					("kart2Player2", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart2Player3:
				cartPrefab = (GameObject)	Resources.Load
					("kart2Player3", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart3Player1:
				cartPrefab = (GameObject)	Resources.Load
					("kart3Player1", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart3Player2:
				cartPrefab = (GameObject)	Resources.Load
					("kart3Player2", typeof(GameObject));
				break;
			case	ModeManager.Avatar.Kart3Player3:
				cartPrefab = (GameObject)	Resources.Load
					("kart3Player3", typeof(GameObject));
				break;
		}

		//	Create the cart

		cart = (GameObject) Instantiate (cartPrefab);

		//	Set location and orientation

		Transform trans = cart.GetComponent<Transform> ();

		switch(ModeManager.playerChoices.track)
		{
			case 	ModeManager.Track.Cloud:
				trans.position = new Vector3(63.6F, 0.7F, 0F);
				trans.rotation = Quaternion.Euler (0, 90, 0);
				break;
			case 	ModeManager.Track.Forest:
				trans.position = new Vector3(370F, 1.0F, 77.7F);
				trans.rotation = Quaternion.Euler (0, 180, 0);
				break;
			case 	ModeManager.Track.Wooden:
				trans.position = new Vector3(-19F, 3.92F, 33.28F);
				trans.rotation = Quaternion.Euler (0, 90, 0);
				break;
		}

		//	Turn off AI script & turn on firstPersonController script

		cart.GetComponent<AIController> ().enabled = false;
		cart.GetComponent<firstPersonController> ().enabled = true;

		//	Set audio volume for effects
		
		AudioSource audio = cart.GetComponent<AudioSource> ();
		
		if (ModeManager.volSettings.areEffectsMuted)
			audio.volume = 0.0f;
		else
			audio.volume = ModeManager.volSettings.effectsVol / 100.0F;
		
		//	Turn on camera

		Camera cam = cart.GetComponentInChildren<Camera> ();
		cam.enabled = true;

		//	Set audio volume for music

		audio = cam.GetComponent<AudioSource> ();

		if (ModeManager.volSettings.isMusicMuted)
			audio.volume = 0.0f;
		else
			audio.volume = ModeManager.volSettings.musicVol / 100.0F;

		//	Make ai carts

		string prefabName1 = "";
		string prefabName2 = "";

		switch (ModeManager.playerChoices.avatar)
		{
			case	ModeManager.Avatar.Kart1Player1:
				prefabName1 = "Kart2Player2";
				prefabName2 = "Kart3Player3";
				break;
			case	ModeManager.Avatar.Kart1Player2:
				prefabName1 = "Kart2Player1";
				prefabName2 = "Kart3Player3";
				break;
			case	ModeManager.Avatar.Kart1Player3:
				prefabName1 = "Kart2Player2";
				prefabName2 = "Kart3Player1";
				break;
			case	ModeManager.Avatar.Kart2Player1:
				prefabName1 = "Kart1Player2";
				prefabName2 = "Kart3Player3";
				break;
			case	ModeManager.Avatar.Kart2Player2:
				prefabName1 = "Kart1Player1";
				prefabName2 = "Kart3Player3";
				break;
			case	ModeManager.Avatar.Kart2Player3:
				prefabName1 = "Kart1Player2";
				prefabName2 = "Kart3Player1";
				break;
			case	ModeManager.Avatar.Kart3Player1:
				prefabName1 = "Kart2Player2";
				prefabName2 = "Kart1Player3";
				break;
			case	ModeManager.Avatar.Kart3Player2:
				prefabName1 = "Kart2Player1";
				prefabName2 = "Kart1Player3";
				break;
			case	ModeManager.Avatar.Kart3Player3:
				prefabName1 = "Kart2Player2";
				prefabName2 = "Kart1Player1";
				break;
		}

		//	Create AI 1
		
		cartPrefab = (GameObject)	Resources.Load
			(prefabName1, typeof(GameObject));
		
		aiCart1	=	(GameObject) Instantiate (cartPrefab);
		
		//	Set transform AI 1
		
		trans = aiCart1.GetComponent<Transform> ();
		
		switch(ModeManager.playerChoices.track)
		{
			case 	ModeManager.Track.Cloud:
				trans.position = new Vector3(63.6F, 0.7F, 8.3F);
				trans.rotation = Quaternion.Euler (0, 90, 0);
				break;
			case 	ModeManager.Track.Forest:
				trans.position = new Vector3(377F, 1.0F, 77.7F);
				trans.rotation = Quaternion.Euler (0, 180, 0);
				break;
			case 	ModeManager.Track.Wooden:
				trans.position = new Vector3(-19F, 3.92F, 41.97F);
				trans.rotation = Quaternion.Euler (0, 90, 0);
				break;
		}
		
		//	Turn on AI script & turn off firstPersonController script
		
		aiCart1.GetComponent<AIController> ().enabled = true;
		aiCart1.GetComponent<firstPersonController> ().enabled = false;

		aiCart1.GetComponent<AudioSource> ().enabled = false;

		//	Turn off AudioListener and camera

		cam = aiCart1.GetComponentInChildren<Camera> ();
		cam.GetComponent<AudioListener>().enabled = false;
		cam.GetComponent<AudioSource> ().enabled = false;
		cam.enabled = false;
		
		//	Create AI 2
		
		cartPrefab = (GameObject)	Resources.Load
			(prefabName2, typeof(GameObject));
		
		aiCart2	=	(GameObject) Instantiate (cartPrefab);
		
		//	Set transform AI 2
		
		trans = aiCart2.GetComponent<Transform> ();
		
		switch(ModeManager.playerChoices.track)
		{
			case 	ModeManager.Track.Cloud:
				trans.position = new Vector3(63.6F, 0.7F, -8.3F);
				trans.rotation = Quaternion.Euler (0, 90, 0);
				break;
			case 	ModeManager.Track.Forest:
				trans.position = new Vector3(363F, 1.0F, 77.7F);
				trans.rotation = Quaternion.Euler (0, 180, 0);
				break;
			case 	ModeManager.Track.Wooden:
				trans.position = new Vector3(-19F, 3.92F, 24.87F);
				trans.rotation = Quaternion.Euler (0, 90, 0);
				break;
		}		

		//	Turn on AI script & turn off firstPersonController script
		
		aiCart2.GetComponent<AIController> ().enabled = true;
		aiCart2.GetComponent<firstPersonController> ().enabled = false;
		
		aiCart2.GetComponent<AudioSource> ().enabled = false;
		
		//	Turn off AudioListener and camera
		
		cam = aiCart2.GetComponentInChildren<Camera> ();
		cam.GetComponent<AudioListener>().enabled = false;
		cam.GetComponent<AudioSource> ().enabled = false;
		cam.enabled = false;

	}	//	Start

}

using UnityEngine;
using System.Collections;

public class TrackScript : MonoBehaviour
{
	static private GameObject cartPrefab;
	static public GameObject	cart;

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
				trans.position = new Vector3(370F, 1.04F, 77.7F);
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

	}
}

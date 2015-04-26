using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public Canvas HUD;
	public GameObject finishLine;
	public Text raceTimeHUD;
	public Text lapTimeHUD;
	public Text lapNumberHUD;
	
	private int lap = 0;
	private float lapTime = 0;

	void Start () {
		lapTimeHUD.text = "Previous Lap: " + (lapTime.ToString());
		lapNumberHUD.text = "Lap: " + (lap.ToString());
	}

	// Update is called once per frame
	void Update () {
		//print (Time.time);
		raceTimeHUD.text = (Time.time.ToString());
	}

	void OnCollisionEnter(Collision coll){
		//if (coll.gameObject.tag == "Player"){
			Debug.Log("Hit");
			lap++;
			lapTime = Time.time;
			lapTimeHUD.text = "Previous Lap: " + (lapTime.ToString());
			lapNumberHUD.text = "Lap: " + (lap.ToString());
		//}
	}

}

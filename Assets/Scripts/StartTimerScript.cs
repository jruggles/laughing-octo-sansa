using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartTimerScript : MonoBehaviour {

	public Canvas TimerCanvas;
	public Canvas HUD;
	public Text TimerText;

	// Use this for initialization
	void Start () {
		//Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

	
		if (Time.deltaTime < 1) {
			TimerText.text = ("3");
		} else if (Time.deltaTime < 2 && Time.deltaTime > 1) {
			TimerText.text = ("2");
		}else{
			TimerText.text = ("1");
		}
	

		if (Time.deltaTime == 3) {
			TimerCanvas.enabled = false;
			HUD.enabled = true;
			Time.timeScale = 1;
		}
	}
}

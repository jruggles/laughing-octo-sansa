using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartTimerScript : MonoBehaviour {

	public Canvas TimerCanvas;
	public Canvas HUD;
	public Text TimerText;

	void Start ()
	{
		Time.timeScale = 0;
		StartCoroutine ("CountDown");
	}

	public static IEnumerator WaitForRealTime(float delay)
	{
		while(true)
		{
			float pauseEndTime = Time.realtimeSinceStartup + delay;
			while (Time.realtimeSinceStartup < pauseEndTime)
			{
				yield return 0;
			}
			break;
		}
	}

	IEnumerator CountDown()
	{
		for (int i = 3; i > 0; i--)
		{
			TimerText.text	=	i.ToString ();
			yield return StartCoroutine(WaitForRealTime(1));
		}
		TimerText.text = "";
		Time.timeScale = 1;
	}

}

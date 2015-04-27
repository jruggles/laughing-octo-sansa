using UnityEngine;
using System.Collections;

public class PauseCanvasScript : MonoBehaviour {

	public Canvas PauseCanvas;
	public Canvas QuitCanvas;

	private bool toggle = false;
	private int count = 0;
	private int play = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = (play++ % 2);
			toggle = !toggle;
			PauseCanvas.enabled = toggle;
		}
	}

	public void loadLevel()
	{
		Application.LoadLevel(2);
		Time.timeScale = (play++ % 2);
	}
	
	public void quit()
	{
		toggle = !toggle;
		PauseCanvas.enabled = toggle;
		QuitCanvas.enabled = !toggle;
	}

	public void quitConfirm()
	{
		Application.Quit();
		Debug.Log("you quit");
	}

	public void continueGame()
	{
		Time.timeScale = (play++ % 2);
		toggle = !toggle;
		PauseCanvas.enabled = toggle;
	}
}

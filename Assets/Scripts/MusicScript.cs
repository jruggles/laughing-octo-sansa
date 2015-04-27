using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	private bool paused = false;
	public AudioSource music;
	public AudioSource carSound;

	// Use this for initialization
	void Start () {
		music.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused) 
		{
			music.Pause ();
			paused = true;
		} 
		else if (Input.GetKeyDown (KeyCode.Escape) && paused) {
			music.UnPause ();
			paused = false;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && !paused) 
		{
			if(!carSound.isPlaying)
			{
				carSound.Play ();
			}
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) && !paused) 
		{
			if (carSound.isPlaying) 
			{
				carSound.Stop ();
			}
		}
	
	}
}

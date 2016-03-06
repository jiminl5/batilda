using UnityEngine;
using System.Collections;

public class MainMenuFadeOut : MonoBehaviour {


	private static float fade_song_speed = .95f;


	// Use this for initialization
	void Start () {
		OpenSignAnim.fadeMainMenuSongOut = false;
	}

	// Update is called once per frame
	void Update () {
		if (OpenSignAnim.fadeMainMenuSongOut) {
			this.gameObject.GetComponent<AudioSource>().volume -= fade_song_speed * Time.deltaTime;
			if(this.gameObject.GetComponent<AudioSource>().volume <= 0)
			{
				OpenSignAnim.fadeMainMenuSongOut = false;
				Destroy(this.gameObject);
			}
		}
	}
}

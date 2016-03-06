using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {
	private static bool new_level_loaded = false;
	private static int songs_level;
	private static AudioClip song_for_level;

	private static float fade_song_speed = .95f;

	private static MusicSingleton instance = null;

	public static MusicSingleton Instance
	{
		get { return instance; }
	}

	void Start()
	{
		songs_level = Application.loadedLevel;
		song_for_level = this.gameObject.GetComponent<AudioSource> ().clip;
	}

	void Awake()
	{
		if (instance != null && instance != this)
		{
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	void OnLevelWasLoaded(int level)
	{
		if (level != songs_level)
		{
			new_level_loaded = true;
		}
	}
	
	void Update()
	{
		if (new_level_loaded && song_for_level != this.gameObject.GetComponent<AudioSource>().clip)
		{
			this.gameObject.GetComponent<AudioSource>().volume -= fade_song_speed * Time.deltaTime;
			if(this.gameObject.GetComponent<AudioSource>().volume <= 0)
			{
				new_level_loaded = false;
				Destroy(this.gameObject);
			}
		}
	}


	
}
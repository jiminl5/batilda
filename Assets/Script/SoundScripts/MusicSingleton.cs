using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {
    private static bool new_level_loaded = false;
    private static float fade_song_speed = .35f;

    private static int scene_level_num;
    private AudioClip this_levels_audio_clip;
    private AudioClip level_loaded_audio_clip;

    private static MusicSingleton instance = null;

    public static MusicSingleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        int scene_level_num = Application.loadedLevel;
        this_levels_audio_clip = this.gameObject.GetComponent<AudioSource>().clip;
        print(this_levels_audio_clip.name);
        if (instance != null && instance != this)
        {
            level_loaded_audio_clip = this.gameObject.GetComponent<AudioSource>().clip;
            print(level_loaded_audio_clip.name);
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
        if (level != scene_level_num)
        {
            new_level_loaded = true;
        }
    }

    void Update()
    {
        if (new_level_loaded && this_levels_audio_clip != level_loaded_audio_clip)
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

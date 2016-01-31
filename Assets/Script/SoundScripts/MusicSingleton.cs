using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {


    private static MusicSingleton instance = null;

    public static MusicSingleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        float curr_time = Time.timeSinceLevelLoad;
        float target_time = curr_time + 5f;
        if (level == 1)
        {
            while (curr_time < target_time)
            {
                this.gameObject.GetComponent<AudioSource>().volume -= Time.deltaTime;
                curr_time += Time.deltaTime;
            }
        }

        if (level == 2)
        {
            while ((this.gameObject.GetComponent<AudioSource>().volume > .1f))
            {
                this.gameObject.GetComponent<AudioSource>().volume -= .001f;

            }

        }

        if (level == 3)
        {
            while ((this.gameObject.GetComponent<AudioSource>().volume > .1f))
            {
                this.gameObject.GetComponent<AudioSource>().volume -= .001f;
          
            }

        }

    }



}

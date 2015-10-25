using UnityEngine;
using System.Collections;

public class StopWatch : MonoBehaviour {

    private float startTime;
    private float restSeconds;
    private float roundedRestSeconds;
    private float displaySeconds;
    private float displayMinutes;
    public float countDownSeconds;

	// Use this for initialization
	void Awake () {
        startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void OnGUI() {
        float guiTime = Time.time - startTime;
        restSeconds = countDownSeconds - guiTime;

        if(restSeconds == 60)
        {
            print("one min left");
        }
        if(restSeconds == 0)
        {
            print("times up");
        }

        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60;
        displayMinutes = roundedRestSeconds / 60;
        string text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
        GUI.Label(new Rect(400, 25, 100, 30), text);
	}
}

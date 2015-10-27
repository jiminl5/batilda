using UnityEngine;
using System.Collections;

public class StopWatch : MonoBehaviour {

    private float startTime = 90;
    private float timeInSeconds;
    private int roundedTimeSeconds;
    private float displaySeconds;
    private float displayMinutes;

	// Use this for initialization
	void Awake () {
        timeInSeconds = startTime;
	}

    void Update()
    {
        timeInSeconds -= Time.deltaTime;
        if (timeInSeconds == 60)
        {
            print("one min left");
        }
        if (timeInSeconds == 0)
        {
            print("times up");
        }
    }
	
	// Update is called once per frame
	void OnGUI() {
        //float guiTime = startTime - Time.time;
        //timeInSeconds = guiTime;

        roundedTimeSeconds = (int)(timeInSeconds);
        displayMinutes = roundedTimeSeconds / 60;
        displaySeconds = roundedTimeSeconds % 60;
        string text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
        GUI.Box(new Rect(400, 25, 100, 30), text);
	}
}

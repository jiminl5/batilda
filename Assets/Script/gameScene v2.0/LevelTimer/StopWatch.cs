using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour {

    private float startTime = 120;
    private float timeInSeconds;
    private int roundedTimeSeconds;
    private float displaySeconds;
    private float displayMinutes;

	public bool finished = false;

	public Image circleTimerIndicator;

	// Use this for initialization
	void Awake () {
        timeInSeconds = startTime;
	}

    void Update()
    {
		if (!finished) {
			timeInSeconds -= Time.deltaTime;
			circleTimerIndicator.fillAmount -= 1 / startTime * Time.deltaTime;
			if (timeInSeconds == 60) {
				print ("one min left");
			}
			if (timeInSeconds <= 0) {
				print ("times up");
				finished = true;

			}
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
        GUI.Label(new Rect(30, 45, 50, 30), text);
	}
}

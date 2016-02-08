using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour {

    public float startTime = 120;
    public float timeInSeconds;
    private int roundedTimeSeconds;
    private float displaySeconds;
    private float displayMinutes;

	public bool finished = false;

	public Image circleTimerIndicator;

	// Use this for initialization
/*	void Awake () {
        timeInSeconds = startTime;
        Debug.Log(startTime);
	}*/

    void Start()
    {
        timeInSeconds = startTime;
        Debug.Log(startTime);
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
                //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().storeCoin();
            }
		}
        if (finished)
        {
            if (GameObject.Find("close") == null)
                Application.LoadLevel("gameResult");
        }
    }
	
	// Update is called once per frame
	void OnGUI() {
        //float guiTime = startTime - Time.time;
        //timeInSeconds = guiTime;
		GUIStyle textStyle = new GUIStyle ();
		textStyle.fontSize = Screen.width/20;
		textStyle.normal.textColor = Color.white;

        roundedTimeSeconds = (int)(timeInSeconds);
        displayMinutes = roundedTimeSeconds / 60;
        displaySeconds = roundedTimeSeconds % 60;
        string text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
		//GUIStyle centeredStyle = GUIStyle(GUI.skin.GetStyle ("Label"));
		textStyle.alignment = TextAnchor.UpperCenter;


		GUIText gtext;
		GUI.TextArea(new Rect(Screen.width/2 - 20, 0, 50, 30), text.Substring(1), textStyle);
	}
}

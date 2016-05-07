using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopWatch : MonoBehaviour {

    public float startTime;
    public float timeInSeconds;
    private int roundedTimeSeconds;
    private float displaySeconds;
    private float displayMinutes;
	public Font oldaniaADFStd;

	public bool finished = false;

    // Use this for initialization
    /*	void Awake () {
            timeInSeconds = startTime;
            Debug.Log(startTime);
        }*/

    private bool setTimer;
    void Start()
    {
        setTimer = true;
        //startTime = GameObject.Find("levelHandler").GetComponent<levelHandler>().levelTime;
        //timeInSeconds = startTime;
        Debug.Log(startTime);
    }

    void setTime()
    {
        startTime = levelHandler.levelTime_;
        timeInSeconds = startTime;
        setTimer = false;
    }

    void Update()
    {
        if (GameObject.Find("levelHandler").GetComponent<levelHandler>().levelTime != 0 && setTimer)
        {
            setTime();
        }
		if (!finished) {
			timeInSeconds -= Time.deltaTime;
			if (timeInSeconds == 60) {
				print ("one min left");
			}
			if (timeInSeconds <= 0) {
                LevelSelectionModal.ConfirmGameStart = false; //Added By Jimmy 2016-04-23
                print ("times up");
                CloseSignAnim.close_child = 0;
				finished = true;
                //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().storeCoin();
            }
		}
        if (finished)
        {
            ResetVariables();
            Destroy(GameObject.Find("Tiles")); //Added By Jimmy 2016-04-23
            PlayerPrefs.SetInt("temp_coin", GameObject.Find("levelHandler").GetComponent<levelHandler>().customersServed);
            if (GameObject.Find("CloseSign") == null)
                SceneManager.LoadScene("gameResult");
                //Application.LoadLevel("gameResult");
        }
    }

    void ResetVariables()
    {
        Waitress.obj_queue1.Clear();
        Chef.obj_queue.Clear();
        MoveableTile.check_Queue.Clear();
        MoveableTile.check_Queue_1.Clear();
        Unit.unit_queue.Clear();
        Unit1.unit_queue1.Clear();
    }

	// Update is called once per frame
	void OnGUI() {
        //float guiTime = startTime - Time.time;
        //timeInSeconds = guiTime;
        if (!LevelSelectionModal.PauseActive)
        {
            GUIStyle textStyle = new GUIStyle();
            textStyle.fontSize = Screen.width / 20;
            textStyle.normal.textColor = Color.white;
            textStyle.font = oldaniaADFStd;

            roundedTimeSeconds = (int)(timeInSeconds);
            displayMinutes = roundedTimeSeconds / 60;
            displaySeconds = roundedTimeSeconds % 60;
            string text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);
            //GUIStyle centeredStyle = GUIStyle(GUI.skin.GetStyle ("Label"));
            textStyle.alignment = TextAnchor.UpperCenter;


            GUIText gtext;
            if (!AndroidViewPort.default_ratio)
            {
                if (displayMinutes > 0)
                {
                    GUI.TextArea(new Rect(Screen.width / 2 - 20, 0, 50, 30), text.Substring(1), textStyle);
                }
                else if (displaySeconds < 10)
                {
                    GUI.TextArea(new Rect(Screen.width / 2 - 20, 0, 50, 30), text.Substring(4), textStyle);
                }
                else {
                    GUI.TextArea(new Rect(Screen.width / 2 - 20, 0, 50, 30), text.Substring(3), textStyle);
                }
            }
            else {
                if (displayMinutes > 0)
                {
                    GUI.TextArea(new Rect(Screen.width / 2 - 20, Screen.height / 28, 50, 30), text.Substring(1), textStyle); //2^4
                }
                else if (displaySeconds < 10)
                {
                    GUI.TextArea(new Rect(Screen.width / 2 - 20, Screen.height / 28, 50, 30), text.Substring(4), textStyle);
                }
                else {
                    GUI.TextArea(new Rect(Screen.width / 2 - 20, Screen.height / 28, 50, 30), text.Substring(3), textStyle);
                }
            }
        }
	}
}

using UnityEngine;
using System.Collections;

public class CloseSignAnim : MonoBehaviour {

    public bool close_sign_trigger = false;

    bool turn = false;
    bool slide = false;

    private float slide_speed = 30.0f;
    private float center_x = 7.5f;
    private float rotate_y_speed = 4.0f;
    private float end_time;
    private float timer;

	public AudioSource source;
	public AudioClip victoryFanfare2;
	public AudioClip coinsVictory;


	private bool playedSoundSetOne = false;
	private bool playedSoundSetTwo = false;

    int turn_count;

    public static int close_child;
	// Use this for initialization
	void Start () {
        turn_count = 0;
        close_sign_trigger = false;
        turn = false;
        slide = false;
        end_time = GameObject.Find("Main Camera").GetComponent<StopWatch>().timeInSeconds;
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("Main Camera").GetComponent<StopWatch>().finished) {
            this.gameObject.transform.GetChild(close_child).GetComponent<SpriteRenderer>().enabled = true;
            if (!turn && !slide)
            {	
				if (!playedSoundSetOne) {
					source.PlayOneShot (coinsVictory);

					playedSoundSetOne = true;
				}
                this.gameObject.transform.GetChild(close_child).Translate(Vector2.right * slide_speed * Time.deltaTime);
                if (this.gameObject.transform.GetChild(close_child).position.x >= 7.5f)
                {
                    this.gameObject.transform.GetChild(close_child).position = new Vector2(7.5f, this.gameObject.transform.GetChild(close_child).position.y);
                    turn = true;
                    turn_count++;
                }
            }
            if (this.gameObject.transform.GetChild(close_child).position.x >= 7.5f && turn)
            {
				if (!playedSoundSetTwo) {
					source.PlayOneShot (victoryFanfare2);
					source.PlayOneShot (coinsVictory);
					playedSoundSetTwo = true;
				}
                this.gameObject.transform.GetChild(close_child).Rotate(new Vector3(0, 45, 0) * rotate_y_speed * Time.deltaTime);
                if (this.gameObject.transform.GetChild(close_child).rotation.eulerAngles.y >= 350.0f)
                {
                    turn_count++;
                }
                if(turn_count == 2)
                {
                    turn = false;
                    slide = true;
                }
            }
            if (slide)//((3.5f + end_time) <= Time.timeSinceLevelLoad) ) //|| GameObject.Find("levelHandler").GetComponent<levelHandler>().finished)
            {
                timer += Time.deltaTime;
                if (timer > 2.5f)
                {
                    this.gameObject.transform.GetChild(close_child).Translate(Vector2.right * slide_speed * Time.deltaTime);
                    if (this.gameObject.transform.GetChild(close_child).position.x >= 20)
                    {
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().storeCoin(); // Store coin to Database
                        PlayerPrefs.SetString("tutorial", "no");
                        CustomerAI.seatCount = 0;
                        CustomerAI.seat_taken_1 = false;
                        CustomerAI.seat_taken_2 = false;
                        CustomerAI.seat_taken_3 = false;
                        CustomerAI.seat_taken_4 = false;
                        CustomerAI.seat_taken_5 = false;
                        CustomerAI.customerSat1 = false;
                        CustomerAI.customerSat2 = false;
                        CustomerAI.customerSat3 = false;
                        CustomerAI.customerSat4 = false;
                        CustomerAI.customerSat5 = false;
                        Destroy(this.gameObject);
                    }
                }
            }
        }
	}

}

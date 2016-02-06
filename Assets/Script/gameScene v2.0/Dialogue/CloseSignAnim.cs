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

	// Use this for initialization
	void Start () {
        close_sign_trigger = false;
        turn = false;
        slide = false;
        end_time = GameObject.Find("Main Camera").GetComponent<StopWatch>().timeInSeconds;
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("Main Camera").GetComponent<StopWatch>().finished) { 
            if (!turn && !slide)
            {
                this.gameObject.transform.Translate(Vector2.right * slide_speed * Time.deltaTime);
                if (this.gameObject.transform.position.x >= 7.5f)
                {
                    turn = true;
                }
            }
            if (this.gameObject.transform.position.x >= 7.5f && turn)
            {
                this.gameObject.transform.Rotate(new Vector3(0, 45, 0) * rotate_y_speed * Time.deltaTime);
                if (this.gameObject.transform.rotation.eulerAngles.y >= 355.0f)
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
                    this.gameObject.transform.Translate(Vector2.right * slide_speed * Time.deltaTime);
                    if (this.gameObject.transform.position.x >= 20)
                        Destroy(this.gameObject);
                }
            }
        }
	}
}

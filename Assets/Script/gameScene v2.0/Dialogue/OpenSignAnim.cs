using UnityEngine;
using System.Collections;

public class OpenSignAnim : MonoBehaviour {

    private bool start = false;
    private float count = 1.0f;
    private bool up = false;
    private float bounce_h = 7.5f;
    private float drop_speed = 10.0f;
    private float depth = 4.215f;
    private float pause_time = 0.0001f;
    private float unpause_time = 10000f;
    private float pauseTimer;
	// Use this for initialization
	void Start () {
        //start = true;
        pauseTimer = 0.0f;
        Time.timeScale = pause_time;
	}
	
	// Update is called once per frame
	void Update () {
	    if (this.gameObject.transform.position.y > depth && count < 4.0f && !up) //drop
        {
            this.transform.Translate(Vector2.down * drop_speed * (Time.deltaTime * unpause_time));
            if (this.gameObject.transform.position.y < depth)
                up = true;
        }
        if (up) //bounce up
        {
            this.transform.Translate(Vector2.up * drop_speed * (Time.deltaTime * unpause_time));
            if (this.gameObject.transform.position.y > (bounce_h - count))
            {
                up = false;
                count++;
            }
        }
        if (count == 4.0f && (pauseTimer + 2.5f <= Time.time * unpause_time))
        {
            this.transform.Rotate(new Vector3(0, 0, 45) * (Time.deltaTime * unpause_time));
            this.transform.Translate(Vector2.right * drop_speed * (Time.deltaTime * unpause_time));
            if (this.gameObject.transform.position.x >= 17.0f)
            {
                Time.timeScale = 1.0f;
                Destroy(this.gameObject);
            }
        }
	}
}

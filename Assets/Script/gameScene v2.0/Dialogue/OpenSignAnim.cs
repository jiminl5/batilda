using UnityEngine;
using System.Collections;

public class OpenSignAnim : MonoBehaviour {

    private int count;
    bool up = false;
    private float bounce_h = 5.5f;
    private float drop_speed = 10.0f;
    private float depth = 4.0f;
    private float pause_time = 0.0001f;
    private float unpause_time = 10000f;

	public AudioSource source;
	public AudioClip wooshSymbolPaperAway;
	bool soundPlayed = false;
	public static bool fadeMainMenuSongOut = false;

    bool tutorial_start = false;
    public static bool confirm_tutorial_start = false;
	// Use this for initialization
	void Start () {
        //start = true;
        up = false;
        count = 0;
        Time.timeScale = pause_time;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.y < 0.0f) //Somehow position y has weird negative number?? (bug)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 11.0f,0.0f);
        }
	    if (this.gameObject.transform.position.y >= depth && count < 4 && !up) //drop
        {
            this.transform.Translate(Vector2.down * drop_speed * (Time.deltaTime * unpause_time));
            if (this.gameObject.transform.position.y < depth && !(this.gameObject.transform.position.y < 0.0f))
                up = true;
        }
        if (up) //bounce up
        {
            this.transform.Translate(Vector2.up * drop_speed * (Time.deltaTime * unpause_time));
            if (this.gameObject.transform.position.y > (bounce_h - count) )
            {
                up = false;
                count++;
            }
        }
        if (count == 4 && (2.5f <= Time.timeSinceLevelLoad * unpause_time) && !tutorial_start)
        {
			if(!soundPlayed){
				source.PlayOneShot (wooshSymbolPaperAway);
				soundPlayed = true;
			}
			
            this.transform.Rotate(new Vector3(0, 0, 45) * (Time.deltaTime * unpause_time));
            this.transform.Translate(Vector2.right * drop_speed * (Time.deltaTime * unpause_time));
            if (this.gameObject.transform.position.x >= 19.0f)
            {
				fadeMainMenuSongOut = true;
                //Tutorial if tutorial level is selected run this function
                Time.timeScale = 1.0f;
                if (PlayerPrefs.GetString("tutorial") == "yes")
                {
                    //WAITRESS - tile
                    GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapData();
                    GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathfindingGraph();
                    GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapVisual();
                    tutorial_start = true;
                }
                else {
                    GameObject.Find("Main Camera").GetComponent<Tutorial>().enabled = false;
                    //Destroy Unnecessary tutorial assets
                    Destroy(GameObject.Find("bg_trans"));
                    Destroy(GameObject.Find("speechBubble"));
                    Destroy(GameObject.Find("speechBubble_1"));
                    //CHEF - tile
                    GameObject.Find("Map").GetComponent<TileMap>().GenerateMapData();
                    GameObject.Find("Map").GetComponent<TileMap>().GeneratePathfindingGraph();
                    GameObject.Find("Map").GetComponent<TileMap>().GenerateMapVisual();
                    //WAITRESS - tile
                    GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapData();
                    GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathfindingGraph();
                    GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapVisual();
                    Destroy(this.gameObject);
                }
            }
        }
        if (tutorial_start)
        {
            if (confirm_tutorial_start)
            {

                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                Destroy(this.gameObject);
            }
        }
	}
}

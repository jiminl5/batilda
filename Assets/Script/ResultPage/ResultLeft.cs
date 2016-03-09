using UnityEngine;
using System.Collections;

public class ResultLeft : MonoBehaviour {

    //Expected Position X = -4.5, Y = 0.5
    //Initial Postion X = -13.5, Y = 0.5

    //Animation Value
    private float expect_X = -4.5f;
    private float speed = 10.0f;

    //Trigger
    public bool Left_Set = false;

    //Canvas
    public GameObject left_canvas;

	void Start () {
        Left_Set = false;
		OpenSignAnim.fadeMainMenuSongOut = false;
		Chef.firstTimeFoxannaClick = false;
		Waitress.firstTimeBatildaClick = false;
	}
	
	void Update () {
        if (!Left_Set)
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (this.gameObject.transform.position.x >= expect_X)
        {
            Left_Set = true;
            this.gameObject.transform.position = new Vector2(expect_X, this.gameObject.transform.position.y);
        }
        if (Left_Set)
        {
            left_canvas.SetActive(true);
            if (GameObject.Find("CheckBox").transform.localScale.x < 1.0f && GameObject.Find("CheckBox").transform.localScale.y < 1.0f)
            {
                GameObject.Find("CheckBox").transform.localScale += new Vector3(0.05f, 0.05f, 0);
            }
            if (GameObject.Find("Main Camera").GetComponent<ResultPageDataHandler>().count >= PlayerPrefs.GetInt("tempCustomer"))  //Check Mark initial size X = 12, Y = 10
            {
                GameObject.Find("/CheckBox/test_checkBox/checkmark").GetComponent<SpriteRenderer>().enabled = true;
                if (GameObject.Find("/CheckBox/test_checkBox/checkmark").transform.localScale.x > 12.0f
                && GameObject.Find("/CheckBox/test_checkBox/checkmark").transform.localScale.y > 10.0f)
                    GameObject.Find("/CheckBox/test_checkBox/checkmark").transform.localScale -= new Vector3(50.0f, 50.0f,0);
            }
        }
	}
}

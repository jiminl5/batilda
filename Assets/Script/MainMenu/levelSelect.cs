using UnityEngine;
using System.Collections;

public class levelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //for testing purposes
        PlayerPrefs.SetInt("grill", 4);
        PlayerPrefs.SetInt("oven", 1);
        PlayerPrefs.SetInt("stove", 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void sendLevel(int level)
    {
        PlayerPrefs.SetInt("level", level);
    }


}

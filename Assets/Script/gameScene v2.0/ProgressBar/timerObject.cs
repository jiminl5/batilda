using UnityEngine;
using System.Collections;

public class timerObject : MonoBehaviour {

	public GameObject[] timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // z - 0 = grills, 1 = ovens, 2 = cutting board, 3 = dough maker
	public void GenerateTimerAt(float x, float y, float runTime, int z, string asset)
	{
        float newX = x * 0.5f;
        //timerBar.cookingTime = runTime;
        if (z < 4)
        {
            timer[z].GetComponentInChildren<timerBar>().cookingTime = runTime;
            timer[z].GetComponentInChildren<timerBar>().identify_tool = z;
        }
        else {
            timer[z].GetComponentInChildren<burnBar>().burnTime = runTime;
            timer[z].GetComponentInChildren<burnBar>().identify_tool = z;
            timer[z].GetComponentInChildren<burnBar>().asset_name = asset;
        }
        Instantiate(timer[z], new Vector2((float)x + newX, (float)y + 0.5f), Quaternion.identity);
    }

	public void genTimerAtUpper(float x, float y, float runTime, int z, string asset)
    {
        float newX = x * 0.5f + .1f;
        //timerBar.cookingTime = runTime;
        if (z < 4)
        {
            timer[z].GetComponentInChildren<timerBar>().cookingTime = runTime;
            timer[z].GetComponentInChildren<timerBar>().identify_tool = z;
        }
        else {
            timer[z].GetComponentInChildren<burnBar>().burnTime = runTime;
            timer[z].GetComponentInChildren<burnBar>().identify_tool = z;
            timer[z].GetComponentInChildren<burnBar>().asset_name = asset;
        }
        Instantiate(timer[z], new Vector2((float)x + newX, (float)y + 0.5f), Quaternion.identity);
    }

	public void genTimerAtLower(float x, float y, float runTime, int z, string asset)
    {
        float newX = x * 0.5f + .1f;
        //timerBar.cookingTime = runTime;
        if (z < 4)
        {
            timer[z].GetComponentInChildren<timerBar>().cookingTime = runTime;
            timer[z].GetComponentInChildren<timerBar>().identify_tool = z;
        }
        else {
            timer[z].GetComponentInChildren<burnBar>().burnTime = runTime;
            timer[z].GetComponentInChildren<burnBar>().identify_tool = z;
            timer[z].GetComponentInChildren<burnBar>().asset_name = asset;
        }
        Instantiate(timer[z], new Vector2((float)x + newX, (float)y - 0.5f), Quaternion.identity);
    }
    /*
	public void genTimerVertical(float x, float y, float runtime, int z)
    {
	}
    */
}

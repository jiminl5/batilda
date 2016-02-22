using UnityEngine;
using System.Collections;

public class timerObject : MonoBehaviour {

	public GameObject timer;
	private GameObject _timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateTimerAt(float x, float y, int runTime)
	{
        float newX = x * 0.5f;
        Instantiate(timer, new Vector2((float)x + newX, (float)y + 0.5f), Quaternion.identity);
    }

	public void genTimerAtUpper(float x, float y, int runTime){
		float newX = x * 0.5f + .1f;
        Instantiate(timer, new Vector2((float)x + newX, (float)y + 0.5f), Quaternion.identity);
	}

	public void genTimerAtLower(float x, float y, int runTime){
		float newX = x * 0.5f + .1f;
		GameObject go = (GameObject)Instantiate(timer, new Vector2((float)x + newX, (float)y - 0.5f), Quaternion.identity);
		//Destroy (go);
	}

	public void genTimerVertical(float x, float y, int runtime){
	}

}

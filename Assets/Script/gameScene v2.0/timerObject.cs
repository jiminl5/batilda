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

	public void GenerateTimerAt(int x, int y, int runTime)
	{
		float newX = x * 0.5f;
		Instantiate(timer, new Vector2((float)x + newX, (float)y + 0.5f), Quaternion.identity);
	}



}

using UnityEngine;
using System.Collections;

public class Furnace : MonoBehaviour {
	public bool isOn = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ExecuteAfterDelay(float delay)
	{
		isOn = true;
		//update sprite;
		yield return new WaitForSeconds(delay);
		isOn = false;
		//update sprite;
	}
}

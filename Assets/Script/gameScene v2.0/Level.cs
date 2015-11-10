using UnityEngine;
using System.Collections;


public class Level : MonoBehaviour {

	public GameObject c1;
	public GameObject c2;

	bool waitingForC1 = false;
	bool waitingForC2 = false;

	GameObject _c1;
	GameObject _c2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (c1.GetComponent<Customer> ().alive);
		//if (c1) {
		if ((!_c1 || !_c2)) {
			int test = Random.Range (5, 10);
			//Debug.Log ("THIS IS RANDOM RANGE::::: " + test);
			if (!_c1) {
				waitingForC1 = false;
			}
			else {
				waitingForC2 = false;
			}
			StartCoroutine(ExecuteAfterDelay (test));//Random.Range (0, 10)));
		}


	}

	IEnumerator ExecuteAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		if (!_c1) {
			_c1 = Instantiate (c1);
			//_c1.GetComponent<Customer>().alive = true;
			waitingForC1 = true;
		} else if (!_c2) {
			_c2 = Instantiate (c2);
			//_c2.GetComponent<Customer>().alive = true;
			waitingForC2 = true;
		}
				
	}

}

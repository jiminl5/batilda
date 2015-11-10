using UnityEngine;
using System.Collections;


public class Level : MonoBehaviour {

	public GameObject c1;
	public GameObject c2;

	bool waitingForC1 = false;
	bool waitingForC2 = false;

	GameObject _c1;
	GameObject _c2;

	private bool finished = false;

	private int customersServed;

	// Use this for initialization
	void Start () {
		//finished = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StopWatch>().finished;
	}

	void Spawn() {
		if (!waitingForC1) {
			_c1 = Instantiate (c1);
			waitingForC1 = true;
		}
		if (!waitingForC2) {
			_c2 = Instantiate (c2);
			waitingForC2 = true;
		}
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (c1.GetComponent<Customer> ().alive);
		//if (c1) {

		if (!finished) {
			finished = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StopWatch>().finished;
			if (!waitingForC1 || !waitingForC2) {
				int test = Random.Range (5, 10);
				//Debug.Log ("THIS IS RANDOM RANGE::::: " + test);
				Invoke("Spawn", test);
			}
			else {
				if (!_c1) {
					customersServed++;
					waitingForC1 = false;
				}
				if (!_c2) {
					customersServed++;
					waitingForC2 = false;
				}
			}

		} 
		else if (finished) {
			if (_c1) {
				Destroy(_c1);
			}
			if (_c2) {
				Destroy (_c2);
			}

			print ("Finsihed! Customers served: " + customersServed);
		}


	}

	IEnumerator ExecuteAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		if (!_c1) {
			_c1 = Instantiate (c1);
			customersServed++;
			//_c1.GetComponent<Customer>().alive = true;
			waitingForC1 = true;
		} else if (!_c2) {
			_c2 = Instantiate (c2);
			customersServed++;
			//_c2.GetComponent<Customer>().alive = true;
			waitingForC2 = true;
		}
				
	}

}

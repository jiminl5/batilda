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
	private string text;
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
                    //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;

                    //Link to Result page 2016-02-01
                    PlayerPrefs.SetInt("temp_coin", customersServed + 1);

                    waitingForC1 = false;
				}
				if (!_c2) {
					customersServed++;
                    //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;

                    //Link to Result page 2016-02-01
                    PlayerPrefs.SetInt("temp_coin", customersServed + 1);

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


//			if (string.IsNullOrEmpty(text)) {
//				gameObject.SetActive(true)
//			}
		}


	}


	void OnGUI() {
		GUIStyle textStyle = new GUIStyle ();
		textStyle.fontSize = Screen.width/25;
		textStyle.normal.textColor = Color.white;
		text = string.Format(customersServed.ToString());
		GUI.Label(new Rect(5, 5, 100, 100), text, textStyle);
	}


	IEnumerator ExecuteAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		if (!_c1) {
			_c1 = Instantiate (c1);
			customersServed++;
            //_c1.GetComponent<Customer>().alive = true;
            //Added by Jimmy 2016/01/10
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;

            waitingForC1 = true;
		} else if (!_c2) {
			_c2 = Instantiate (c2);
			customersServed++;
            //_c2.GetComponent<Customer>().alive = true;
            //Added by Jimmy 2016/01/10
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;

            waitingForC2 = true;
        }
				
	}

}

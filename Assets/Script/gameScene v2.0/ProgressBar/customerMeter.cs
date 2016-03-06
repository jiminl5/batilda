using UnityEngine;
using System.Collections;

public class customerMeter : MonoBehaviour {

	public static float customersServed;
	private float customerBarFillSpeed = .01f;
	public UnityEngine.UI.Image imageBar;
	private bool customerTotalReceived = false;
	private float totalCustomers;

	// Use this for initialization
	void Start () {
		customersServed = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!customerTotalReceived) {
			if (levelHandler.totalCustomersInLevel > 0) {
				totalCustomers = levelHandler.totalCustomersInLevel;
				customerTotalReceived = true;
			}
		}
		if ( customerTotalReceived && imageBar.fillAmount < (customersServed/totalCustomers) ) {
			imageBar.fillAmount += customerBarFillSpeed;
		}

	}
}

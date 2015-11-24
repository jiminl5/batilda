using UnityEngine;
using System.Collections;

public class doughPickUp : MonoBehaviour {
	public int numberofDough;
	// Use this for initialization
	void Start () {
		numberofDough = this.gameObject.GetComponentInParent<doughObject>().numberOfDough;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

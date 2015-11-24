using UnityEngine;
using System.Collections;

public class doughPickUp : MonoBehaviour {
	public int numberofDough;

	private GameObject foodSprite;
	// Use this for initialization
	void Start () {
		numberofDough = this.gameObject.GetComponentInParent<doughObject>().numberOfDough;
	}
	
	// Update is called once per frame
	void Update () {
		doughSprite ();
	}

	void doughSprite() {
		if (numberofDough > 0 && !foodSprite) {
			foodSprite = Instantiate (this.GetComponent<nameAndPosition> ().go, transform.position + Vector3.up / 2, transform.rotation) as GameObject;
		} else if (numberofDough < 1) {
			Destroy(foodSprite);
		}
	}
}

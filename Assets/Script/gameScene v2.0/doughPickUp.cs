using UnityEngine;
using System.Collections;

public class doughPickUp : MonoBehaviour {
	public int numberofDough;
	private GameObject foodSprite;
    public Sprite dough0;
    public Sprite dough1;
    public Sprite dough2;
    public Sprite dough3;
    public Sprite dough4;
    //string dough = "dough";
    // Use this for initialization
    void Start () {
		numberofDough = this.gameObject.GetComponentInParent<doughObject>().numberOfDough;
	}
	// Update is called once per frame
	void Update () {
		doughSprite ();
	}
	void doughSprite()
    {

        if (numberofDough == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dough0;
        }
        else if (numberofDough == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dough1;
        }
        else if (numberofDough == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dough2;
        }
        else if (numberofDough == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dough3;
        }




        /*if (numberofDough > 0 && !foodSprite) {
			foodSprite = Instantiate (this.GetComponent<nameAndPosition> ().go, transform.position + Vector3.up / 2, transform.rotation) as GameObject;
		} else if (numberofDough < 1) {
			Destroy(foodSprite);
		}*/
    }
}

using UnityEngine;
using System.Collections;

public class drinkObject : MonoBehaviour {
	public int numberOfDrinks;
	public string name;

	public int maxDrinks;

	private bool waitingOnDrink = false;
    public int timeToMakeDrink;

    public Sprite drink1;
    public Sprite drink2;
    public Sprite drink3;
    public Sprite drink4;


    //public Color c;
    // Use this for initialization


    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		checkDrinks ();

        if (numberOfDrinks > 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (numberOfDrinks == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = drink1;
        }
        else if (numberOfDrinks == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = drink2;
        }
        else if (numberOfDrinks == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = drink3;
        }
        else if (numberOfDrinks == 4)
        {
            this.GetComponent<SpriteRenderer>().sprite = drink4;
        }
    }
	

	void checkDrinks() {
		if (!waitingOnDrink && numberOfDrinks < maxDrinks) {
			//this.GetComponent<SpriteRenderer> ().color = Color.red;
			Invoke("addDrink", timeToMakeDrink);
			waitingOnDrink = true;
		}
	}

	void addDrink() {
		numberOfDrinks += 1;
		waitingOnDrink = false;
		//this.GetComponent<SpriteRenderer> ().color = Color.white;
	}

}

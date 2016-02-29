using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waitress : MonoBehaviour {
	public string one_h;
	public string two_h;
	public GameObject temp_plate;
	public string at_current_name;
	//public GameObject Player;
	public GameObject go_1h;
	public GameObject go_2h;

    public AudioClip pickUpLogSFX;
	public AudioClip[] plateSFX;
	public AudioClip[] coinSFX;
	public AudioClip trashSFX;
	public AudioClip drink;
    private AudioSource source;
	
	public int mtX;
	public int mtY;
	public bool atPosition = true;
	public static bool clicked = false;
	
	private Animator animator;

    private recipeRepository rr;
    private ArrayList recipes;

    public static Queue<GameObject> obj_queue1 = new Queue<GameObject>();
    // Use this for initialization
    void Awake()
    {
        this.gameObject.AddComponent<recipeRepository>();
        rr = GetComponent<recipeRepository>();
        rr.cookingObjectName = "all"; //override for cookingObjectName to get all recipes instead of specific ones
    }


    void Start () {
		animator = this.GetComponent<Animator>();
		atPosition = true;
        source = GetComponent<AudioSource>();

        recipes = rr.recipes;
    }
	
	// Update is called once per frame
	void Update () {
        if (obj_queue1.Count > 0) {
			if (obj_queue1.Peek ()) {
				if ((atPosition && obj_queue1.Peek ().GetComponent<drinkObject> ())
				    || (atPosition && GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot && obj_queue1.Peek ().GetComponent<drinkObject> ())) {
					drinkAction (obj_queue1.Peek ());
					obj_queue1.Dequeue ();
					//Check Mark - 2016-02-13
					if (MoveableTile.check_Queue_1.Peek ().name != "Null_Object")
						Destroy (MoveableTile.check_Queue_1.Peek ());
					MoveableTile.check_Queue_1.Dequeue ();
					GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot = false;
					atPosition = false;
				} else if ((atPosition && obj_queue1.Peek ().GetComponent<Furnace> ())
				           || (atPosition && GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot && obj_queue1.Peek ().GetComponent<Furnace> ())) {
					furnaceAction (obj_queue1.Peek ());
					obj_queue1.Dequeue ();
					//Check Mark - 2016-02-13
					if (MoveableTile.check_Queue_1.Peek ().name != "Null_Object")
						Destroy (MoveableTile.check_Queue_1.Peek ());
					MoveableTile.check_Queue_1.Dequeue ();
					GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot = false;
					atPosition = false;    
				} else if ((atPosition && obj_queue1.Peek ().GetComponent<dropOffPoint> ())
				           || (atPosition && GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot && obj_queue1.Peek ().GetComponent<dropOffPoint> ())) {
					dropOffPointAction (obj_queue1.Peek ());
					obj_queue1.Dequeue ();
					//Check Mark - 2016-02-13
					if (MoveableTile.check_Queue_1.Peek ().name != "Null_Object")
						Destroy (MoveableTile.check_Queue_1.Peek ());
					MoveableTile.check_Queue_1.Dequeue ();
					GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot = false;
					atPosition = false;
				} else if ((atPosition && obj_queue1.Peek ().GetComponent<ingredientObject> ())
				           || (atPosition && GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot && obj_queue1.Peek ().GetComponent<ingredientObject> ())) {
					ingredientAction (obj_queue1.Peek ());
					obj_queue1.Dequeue ();
					//Check Mark - 2016-02-13
					if (MoveableTile.check_Queue_1.Peek ().name != "Null_Object")
						Destroy (MoveableTile.check_Queue_1.Peek ());
					MoveableTile.check_Queue_1.Dequeue ();
					GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot = false;
					atPosition = false;
				} else if ((atPosition && obj_queue1.Peek ().GetComponent<Customer> ())
				           || (atPosition && GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot && obj_queue1.Peek ().GetComponent<Customer> ())) {
					customerAction (obj_queue1.Peek ());
					obj_queue1.Dequeue ();
					//Check Mark - 2016-02-13
					if (MoveableTile.check_Queue_1.Peek ().name != "Null_Object")
						Destroy (MoveableTile.check_Queue_1.Peek ());
					MoveableTile.check_Queue_1.Dequeue ();
					GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot = false;
					atPosition = false;
				} else if ((atPosition && obj_queue1.Peek ().name == "Null_Object")
				           || (atPosition && GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot && obj_queue1.Peek ().name == "Null_Object")) {
					obj_queue1.Dequeue ();
					//Check Mark - 2016-02-13
					if (MoveableTile.check_Queue_1.Peek ().name != "Null_Object")
						Destroy (MoveableTile.check_Queue_1.Peek ());
					MoveableTile.check_Queue_1.Dequeue ();
					GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot = false;
					atPosition = false;
				} else if ((atPosition && obj_queue1.Peek ().GetComponent<nameAndPosition> ().name == "trash")
				           || (atPosition && GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot && obj_queue1.Peek ().GetComponent<nameAndPosition> ().name == "trash")) {
					trashAction (obj_queue1.Peek ());
					obj_queue1.Dequeue ();
					//Check Mark - 2016-02-13
					if (MoveableTile.check_Queue_1.Peek ().name != "Null_Object")
						Destroy (MoveableTile.check_Queue_1.Peek ());
					MoveableTile.check_Queue_1.Dequeue ();
					GameObject.Find ("Map").GetComponent<TileMap1> ().same_spot = false;
					atPosition = false;
				}
			} 
			else if (!obj_queue1.Peek ()) 
			{
				obj_queue1.Dequeue ();
				Destroy (MoveableTile.check_Queue_1.Peek ());
				MoveableTile.check_Queue_1.Dequeue();
			}
            //else {
            //Debug.Log("didn't work!");
            //Debug.Log(gameObject.tag);
            //	clicked = true;
            //}


            //When 1H = empty and 2H has food.
            if (!string.IsNullOrEmpty(two_h) && string.IsNullOrEmpty(one_h)) {
				one_h = two_h;
				go_1h = Instantiate (go_2h, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
				go_1h.transform.SetParent (gameObject.transform);
				//------------------
				Destroy (go_2h);
				two_h = "";
			}
				
			//}
		}
		
	}

    void drinkAction(GameObject go)
    {
        if (string.IsNullOrEmpty(one_h) && go.GetComponent<drinkObject>().numberOfDrinks > 0)
        {
            //Debug.Log ("test");
            one_h = go.GetComponent<drinkObject>().name;
            //create go_1h
            //go_1h = temp_plate;
            go.GetComponent<drinkObject>().numberOfDrinks -= 1;
            go_1h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
            go_1h.transform.SetParent(gameObject.transform);
            //go_1h.gameObject.layer = 5;
            Debug.Log(one_h);

        }
        else if (string.IsNullOrEmpty(two_h) && go.GetComponent<drinkObject>().numberOfDrinks > 0)
        {
            two_h = go.GetComponent<drinkObject>().name;
            //create go_2h
            //go_2h = temp_plate;
            go.GetComponent<drinkObject>().numberOfDrinks -= 1;
            go_2h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2 / 3 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
            //go_2h.gameObject.layer = 5;
            go_2h.transform.SetParent(gameObject.transform);

        }

    }

    void furnaceAction(GameObject go)
    {
        if (one_h == "firewood")
        {
            one_h = "";
            go.GetComponent<Furnace>().hasFirewood = true;
            Destroy(go_1h);
        }
        else if (two_h == "firewood")
        {
            two_h = "";
            go.GetComponent<Furnace>().hasFirewood = true;
            Destroy(go_2h);
        }
    }

    void customerAction(GameObject go)
    {
        Customer customer = go.GetComponent<Customer>();
        //Debug.Log ("HEllO");

        if (customer.needsToOrder)
        {
            customer.needsToOrder = false;
        }

        else if (!customer.needsToOrder)
        {
            if (hand_with_Food(go.GetComponent<Customer>().foodWaitingOn) == "one_h" && string.IsNullOrEmpty(go.GetComponent<Customer>().food_given))
            {
                //update dropoffpoint food name
                go.GetComponent<Customer>().food_given = one_h;
                //add sprite of food
                //delete 1h
                //Destroy (go_1h);
                //one_h = "";
            }
            else if (hand_with_Food(go.GetComponent<Customer>().foodWaitingOn) == "two_h" && string.IsNullOrEmpty(go.GetComponent<Customer>().food_given))
            {
                //update dropoffpoint food name
                go.GetComponent<Customer>().food_given = two_h;
                //delete 2h
                //Destroy (go_2h);
                //two_h = "";

            }
            else if (customer.moneyOn)
            {
				source.PlayOneShot(coinSFX[Random.Range (0,4)]);
                customer.moneyPickedUp = true;
            }
            else
            {
                Debug.Log("NOT ANYTHING");
                go.GetComponent<Customer>().food_given = "not my food";
            }
        }

    }

    void dropOffPointAction(GameObject go)
    {
        if (string.IsNullOrEmpty(one_h))
        {
            //update dropoffpoint food name
            if (!string.IsNullOrEmpty(go.GetComponent<dropOffPoint>().food_name))
            {
				source.PlayOneShot(plateSFX[Random.Range (0,7)]);				
                one_h = go.GetComponent<dropOffPoint>().food_name;
                go_1h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                go_1h.transform.SetParent(gameObject.transform);
                go.transform.GetChild(0).tag = "empty_plate";
                GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().plates = null;
                GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().food_plates = null;
                GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().Setup_Tile();
                //add sprite of food
                //delete 1h
                go.GetComponentInChildren<SpriteRenderer>().sprite = go.GetComponentInChildren<go_emptyDish>().emptyDish.GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<dropOffPoint>().food_name = "";
                Destroy(go.GetComponent<nameAndPosition>().go);
            }
        }
        else if (string.IsNullOrEmpty(two_h))
        {
            //update dropoffpoint food name
            if (!string.IsNullOrEmpty(go.GetComponent<dropOffPoint>().food_name))
            {
				source.PlayOneShot(plateSFX[Random.Range (0,7)]);				
                two_h = go.GetComponent<dropOffPoint>().food_name;
                go_2h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2 / 3 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                go_2h.transform.SetParent(gameObject.transform);
                go.transform.GetChild(0).tag = "empty_plate";
                GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().plates = null;
                GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().food_plates = null;
                GameObject.FindGameObjectWithTag("tile_red").GetComponent<MoveableTile>().Setup_Tile();
                //add sprite of food
                //delete 1h
                go.GetComponentInChildren<SpriteRenderer>().sprite = go.GetComponentInChildren<go_emptyDish>().emptyDish.GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<dropOffPoint>().food_name = "";
                Destroy(go.GetComponent<nameAndPosition>().go);

            }
        }
    }

    void ingredientAction(GameObject go)
    {
        Debug.Log("this is two_h: " + string.IsNullOrEmpty(two_h));
        //SoundEffects - W
        if(go.GetComponent<ingredientObject>().name == "firewood")
        {
            source.PlayOneShot(pickUpLogSFX);
        }
        //EndSoundEffects -W
        if (string.IsNullOrEmpty(one_h))
        {
            //Debug.Log ("test");
            one_h = go.GetComponent<ingredientObject>().name;
            //create go_1h
            //go_1h = temp_plate;
            go_1h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
            go_1h.transform.SetParent(gameObject.transform);
            //go_1h.gameObject.layer = 5;
            Debug.Log(one_h);

        }
        else if (string.IsNullOrEmpty(two_h))
        {
            //Debug.Log ("HELLO?????????????");
            two_h = go.GetComponent<ingredientObject>().name;
            //create go_2h
            //go_2h = temp_plate;

            go_2h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2 / 3 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
            //go_2h.gameObject.layer = 5;
            go_2h.transform.SetParent(gameObject.transform);

        }
    }

    void trashAction(GameObject go)
    {
        if (!string.IsNullOrEmpty(two_h))
        {
			source.PlayOneShot(trashSFX);
            two_h = "";
            Destroy(go_2h);
            go.GetComponent<Animator>().SetTrigger("trash_on");
        }
        else if (!string.IsNullOrEmpty(one_h))
        {
			source.PlayOneShot(trashSFX);
            one_h = "";
            Destroy(go_1h);
            go.GetComponent<Animator>().SetTrigger("trash_on");
        }
    }

    bool handsEmpty() {
		if (string.IsNullOrEmpty(one_h) && string.IsNullOrEmpty(two_h))
			return true;
		else
			return false;
	}

    public string hand_with_Food(string food)
    {
        foreach (Recipie r in recipes)
        {
            if (one_h == r.name && r.name == food)
            {
                return "one_h";
            }
        }
        foreach (Recipie r in recipes)
        {
            if (two_h == r.name && r.name == food)
            {
                return "two_h";
            }
        }
        return "";
        /*
		if (!string.IsNullOrEmpty(one_h) && one_h.Contains("food")) {
			return "one_h";
		} else if (!string.IsNullOrEmpty(two_h) && two_h.Contains ("food")) {
			return "two_h";
		} return "";*/
        //		if (one_h.Contains ("food")) {
        //			return "one_h";
        //		} else if (two_h.Contains ("food")) {
        //			return "two_h";
        //		}
        //			return "";
    }


    public GameObject findGameObjectAtClickedPosition() {
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("test")) {
			try{
			if (go.GetComponent<nameAndPosition> ().x == mtX
			    && go.GetComponent<nameAndPosition> ().y == mtY) {
				return go;
			}
			}
			catch(System.NullReferenceException )
			{
				Debug.Log (go.name);
				Debug.Log (go.GetComponent<nameAndPosition>().x);
			}
		}
		return null;
	}
}

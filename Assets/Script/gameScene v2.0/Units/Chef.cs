﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chef : MonoBehaviour {
	public string one_h;
	public string two_h;
	public GameObject temp_plate;
	public string at_current_name;
	//public GameObject Player;
	GameObject go_1h;
	GameObject go_2h;

    private AudioSource source;
	public AudioClip[] plateSFX;
    public AudioClip[] pickUpPlateSFX;
    public AudioClip[] dropOffPlateSFX;
	public AudioClip cuttingZuchinni;
	public AudioClip cuttingCarrot;
	public AudioClip grillDropOff;
	public AudioClip stoveDropOff;
	public AudioClip ovenDropOff;
	public AudioClip trashSFX;
	public AudioClip bubblingSFX;
	public AudioClip doughWooshSFX;

	public int mtX;
	public int mtY;
	public bool atPosition = true;
	public static bool clicked = false;

	public static bool firstTimeFoxannaClick = false;

	private Animator animator;

    private recipeRepository rr;
    private ArrayList recipes;
    //public GameObject go;
    
    public static Queue<GameObject> obj_queue = new Queue<GameObject>();
	// Use this for initialization
    void Awake ()
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
		if (obj_queue.Count > 0)
        {
            if (obj_queue.Peek())
            {
                if ((atPosition && obj_queue.Peek().GetComponent<cookingObject>())
            || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<cookingObject>()))
                {
                    cookingAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().GetComponent<ingredientObject>())
                || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<ingredientObject>()))
                {
                    string ingredient_obj = obj_queue.Peek().GetComponent<ingredientObject>().name;
                    if (xorHandsEmpty())
                    {
                        source.PlayOneShot(plateSFX[Random.Range(0, 7)]);
                    }
                    ingredientAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().GetComponent<doughObject>())
                || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<doughObject>()))
                {
                    //this.GetComponent<timerObject>().genTimerAtLower(5, 1.9f, 35);
                    doughCreateAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().GetComponent<doughPickUp>())
                || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<doughPickUp>()))
                {
                    //source.PlayOneShot(pickUpPlateSFX);
                    doughPickUpAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().GetComponent<cuttingObject>())
              || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<cuttingObject>()))
                {
                    cuttingAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().GetComponent<cuttingPickUp>())
              || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<cuttingPickUp>()))
                {
                    cuttingPickUpAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().GetComponent<dropOffPoint>())
              || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<dropOffPoint>()))
                {
                    dropOffPointAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().GetComponent<Customer>())
              || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<Customer>()))
                {
                    customerAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                else if ((atPosition && obj_queue.Peek().name == "Null_Object")
                || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().name == "Null_Object"))
                {
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
                //======================================================================
                //NOTE: BELOW IS THE TRASH OBEJCT.
                //======================================================================
                else if ((atPosition && obj_queue.Peek().GetComponent<nameAndPosition>().name == "trash")
                || (atPosition && GameObject.Find("Map").GetComponent<TileMap>().same_spot && obj_queue.Peek().GetComponent<nameAndPosition>().name == "trash"))
                {
                    trashAction(obj_queue.Peek());
                    obj_queue.Dequeue();
                    //Check Mark - 2016-02-13
                    if (MoveableTile.check_Queue.Peek().name != "Null_Object")
                        Destroy(MoveableTile.check_Queue.Peek());
                    MoveableTile.check_Queue.Dequeue();
                    GameObject.Find("Map").GetComponent<TileMap>().same_spot = false;
                    atPosition = false;
                }
            }
            else if (!obj_queue.Peek())
            {
                obj_queue.Dequeue();
                Destroy(MoveableTile.check_Queue_1.Peek());
                MoveableTile.check_Queue_1.Dequeue();
            }
            //else {
            //Debug.Log("didn't work!");
            //Debug.Log(gameObject.tag);
            //clicked = true;
            //}

            if (!string.IsNullOrEmpty (two_h) && string.IsNullOrEmpty (one_h)) {
			    one_h = two_h;
			    go_1h = Instantiate (go_2h, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
			    go_1h.transform.SetParent (gameObject.transform);
			    //------------------
			    Destroy (go_2h);
			    two_h = "";
		    }
		    animator.SetBool ("1_h", !string.IsNullOrEmpty (one_h));
		    animator.SetBool ("2_h", !string.IsNullOrEmpty (two_h));

		    //}
		    //}
		}

	}

	bool handsEmpty() {
		if (string.IsNullOrEmpty(one_h) && string.IsNullOrEmpty(two_h))
			return true;
		else
			return false;
	}

	bool xorHandsEmpty(){
		if (string.IsNullOrEmpty(one_h) || string.IsNullOrEmpty(two_h))
			return true;
		else
			return false;
	}

	string hand_with_Food() {
        foreach (Recipie r in recipes)
        {
            if (one_h == r.name)
            {
                return "one_h";
            }
            else if (two_h == r.name)
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
		if (!firstTimeFoxannaClick && !Waitress.firstTimeBatildaClick) {
			levelHandler.selectedSoundtrack.SetActive(true);
			Waitress.firstTimeBatildaClick = true;
			firstTimeFoxannaClick = true;
		}
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("test")) {
			if (go.GetComponent<nameAndPosition> ().x == mtX
				&& go.GetComponent<nameAndPosition> ().y == mtY) {
				return go;
			}
		}
		return null;
	}

	void cookingAction(GameObject go) {
        //Debug.Log(gameObject);
        //Debug.Log ("hello");
        //Debug.Log(go.GetComponent<cookingObject> ().canCook (one_h));
        if (go.GetComponent<cookingObject>().canCook(one_h) &&
            go.GetComponent<cookingObject>().food_ready == false &&
            !go.GetComponent<cookingObject>().isCooking) {
            Debug.Log("cooking...");
			Debug.Log (go.GetComponent<cookingObject>().name);
                Debug.Log("cooking... at" + go.GetComponent<cookingObject>());
                go.GetComponent<cookingObject>().cookReady = true;
                go.GetComponent<cookingObject>().chef_1h = one_h;
                Destroy(go_1h);
                //MoveableTile.ResetMidTiles();
                one_h = "";
            

        }
        else if (go.GetComponent<cookingObject>().canCook(two_h) &&
                 go.GetComponent<cookingObject>().food_ready == false &&
                 !go.GetComponent<cookingObject>().isCooking) {
                Debug.Log("cooking...");
                go.GetComponent<cookingObject>().cookReady = true;
                go.GetComponent<cookingObject>().chef_1h = two_h;
                Destroy(go_2h);
                two_h = "";
            
        }

        else if (go.GetComponent<cookingObject>().food_ready) {
            string temp_ingredient = "";

                if (go.GetComponent<cookingObject>().canCook(one_h) &&
                        !go.GetComponent<cookingObject>().isCooking)
                {
                    Debug.Log("cooking...");
                    Debug.Log(go.GetComponent<cookingObject>().name);
                    Debug.Log("cooking... at" + go.GetComponent<cookingObject>());
                    //go.GetComponent<cookingObject>().cookReady = true;
                    temp_ingredient = one_h;
                    Destroy(go_1h);
                    one_h = "";

                    one_h = go.GetComponent<cookingObject>().current_recipie.name;
                    go_1h = Instantiate(go.GetComponent<cookingObject>().current_recipie.go, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                    go_1h.transform.SetParent(gameObject.transform);
                    source.PlayOneShot(plateSFX[Random.Range(0, 7)]);
                    Debug.Log("picking up food...");
                    Debug.Log(go.GetComponent<cookingObject>().food_cooking_name);
                    go.GetComponent<cookingObject>().food_ready = false;
                    go.GetComponent<cookingObject>().chef_1h = "";

                    go.GetComponent<cookingObject>().cookReady = true;
                    go.GetComponent<cookingObject>().chef_1h = temp_ingredient;
                }
                //

                else if (string.IsNullOrEmpty(one_h))
                {
                    one_h = go.GetComponent<cookingObject>().current_recipie.name;
                    go_1h = Instantiate(go.GetComponent<cookingObject>().current_recipie.go, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                    go_1h.transform.SetParent(gameObject.transform);
                    source.PlayOneShot(plateSFX[Random.Range(0, 7)]);
                    Debug.Log("picking up food...");
                    Debug.Log(go.GetComponent<cookingObject>().food_cooking_name);
                    go.GetComponent<cookingObject>().food_ready = false;
                    go.GetComponent<cookingObject>().chef_1h = "";
                }
                //

                else if (go.GetComponent<cookingObject>().canCook(two_h) &&
                        !go.GetComponent<cookingObject>().isCooking)
                {
                    Debug.Log("cooking...");
                    Debug.Log(go.GetComponent<cookingObject>().name);
                    Debug.Log("cooking... at" + go.GetComponent<cookingObject>());
                    //go.GetComponent<cookingObject>().cookReady = true;
                    temp_ingredient = two_h;
                    Destroy(go_2h);
                    two_h = "";

                    two_h = go.GetComponent<cookingObject>().current_recipie.name;
                    go_2h = Instantiate(go.GetComponent<cookingObject>().current_recipie.go, transform.position + Vector3.left * 2 / 3 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                    go_2h.transform.SetParent(gameObject.transform);
                    source.PlayOneShot(plateSFX[Random.Range(0, 7)]);
                    Debug.Log("TWO_H: " + two_h);
                    Debug.Log("picking up food...");
                    Debug.Log(go.GetComponent<cookingObject>().food_cooking_name);
                    go.GetComponent<cookingObject>().food_ready = false;
                    go.GetComponent<cookingObject>().chef_1h = "";
                Debug.Log("THIS IS TEMP INGREDIENT: " + temp_ingredient);
                    go.GetComponent<cookingObject>().cookReady = true;
                    go.GetComponent<cookingObject>().chef_1h = temp_ingredient;
                }

                else if (string.IsNullOrEmpty(two_h))
                {
                    two_h = go.GetComponent<cookingObject>().current_recipie.name;
                    go_2h = Instantiate(go.GetComponent<cookingObject>().current_recipie.go, transform.position + Vector3.left * 2 / 3 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                    go_2h.transform.SetParent(gameObject.transform);
                    source.PlayOneShot(plateSFX[Random.Range(0, 7)]);
                    Debug.Log("picking up food...");
                    Debug.Log(go.GetComponent<cookingObject>().food_cooking_name);
                    go.GetComponent<cookingObject>().food_ready = false;
                    go.GetComponent<cookingObject>().chef_1h = "";
                }
            
        }
        }
	
	void ingredientAction(GameObject go) {
		Debug.Log ("this is two_h: " + string.IsNullOrEmpty(two_h));
		if (string.IsNullOrEmpty(one_h)) {
			//Debug.Log ("test");
			one_h = go.GetComponent<ingredientObject> ().name;
			//create go_1h
			//go_1h = temp_plate;
			go_1h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
			go_1h.transform.SetParent (gameObject.transform);
			//go_1h.gameObject.layer = 5;
			Debug.Log (one_h);
			
		} else if (string.IsNullOrEmpty(two_h)) {
			//Debug.Log ("HELLO?????????????");
			two_h = go.GetComponent<ingredientObject> ().name;
			//create go_2h
			//go_2h = temp_plate;
			
			go_2h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2/3 + Vector3.down *1/2, transform.rotation) as GameObject;
			//go_2h.gameObject.layer = 5;
			go_2h.transform.SetParent (gameObject.transform);
			
		}
	}
	
	void doughCreateAction(GameObject go) {
		if (one_h == "wheat" && go.GetComponent<doughObject>().numberofWheat < go.GetComponent<doughObject>().maxWheat) {
			source.PlayOneShot (doughWooshSFX, .45f);
			go.GetComponent<doughObject>().numberofWheat += 1;
			one_h = "";
			Destroy (go_1h);
		}
		else if (two_h == "wheat" && go.GetComponent<doughObject>().numberofWheat < go.GetComponent<doughObject>().maxWheat) {
			source.PlayOneShot (doughWooshSFX, .45f);
			go.GetComponent<doughObject>().numberofWheat += 1;
			two_h = "";
			Destroy (go_2h);
		}
	}
	void doughPickUpAction(GameObject go) {
		if (go.GetComponent<doughPickUp>().numberofDough > 0) {
			if (string.IsNullOrEmpty(one_h)) {
				one_h = "dough";
				go_1h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right/2 + Vector3.down *1/2, transform.rotation) as GameObject;
				go_1h.transform.SetParent (gameObject.transform);
				go.GetComponentInParent<doughObject> ().numberOfDough -= 1;
				go.GetComponent<doughPickUp> ().numberofDough -= 1;
			}
			else if (string.IsNullOrEmpty(two_h)) {
				two_h = "dough";
				go_2h = Instantiate (go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2/3 + Vector3.down *1/2, transform.rotation) as GameObject;
				go_2h.transform.SetParent (gameObject.transform);
				go.GetComponentInParent<doughObject> ().numberOfDough -= 1;
				go.GetComponent<doughPickUp> ().numberofDough -= 1;
			}
		}
	}
	
	void dropOffPointAction(GameObject go) {
		//Debug.Log ("HELLO!");
		//Debug.Log (hand_with_Food());
		if (hand_with_Food () == "one_h") {
			
			//update dropoffpoint food name
			if (string.IsNullOrEmpty (go.GetComponent<dropOffPoint> ().food_name)) {
				go.GetComponent<dropOffPoint> ().food_name = one_h;
				go.GetComponent<nameAndPosition>().go = Instantiate(go_1h);
                go.GetComponent<nameAndPosition>().go.transform.parent = go.transform;
                go.GetComponent<nameAndPosition>().go.transform.localPosition = new Vector3(0, 0, 0);
                //go.GetComponentInChildren<SpriteRenderer>().sprite = go_1h.GetComponent<SpriteRenderer>().sprite;
                go.transform.GetChild(0).tag = "not_empty_plate";
				GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().plates = null;
				GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().food_plates = null;
				GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().Setup_Tile();
				//add sprite of food
				//delete 1h
				one_h = "";
				source.PlayOneShot(plateSFX[Random.Range (0,7)]);
				Destroy (go_1h);
			}
		} else if (hand_with_Food () == "two_h") {
			//update dropoffpoint food name
			if (string.IsNullOrEmpty (go.GetComponent<dropOffPoint> ().food_name)) {
				go.GetComponent<dropOffPoint> ().food_name = two_h;
				go.GetComponent<nameAndPosition>().go = Instantiate(go_2h);
                go.GetComponent<nameAndPosition>().go.transform.parent = go.transform;
                go.GetComponent<nameAndPosition>().go.transform.localPosition = new Vector3(0, 0, 0);
                //go.GetComponentInChildren<SpriteRenderer>().sprite = go_2h.GetComponent<SpriteRenderer>().sprite;
                go.transform.GetChild(0).tag = "not_empty_plate";
				GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().plates = null;
				GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().food_plates = null;
				GameObject.FindGameObjectWithTag("tile_blk").GetComponent<MoveableTile>().Setup_Tile();
				//add sprite of food
				//delete 1h
				two_h = "";
				source.PlayOneShot(plateSFX[Random.Range (0,7)]);
				Destroy (go_2h);
			}
		}
	}

    void cuttingAction(GameObject go)
    {
        cuttingObject obj = go.GetComponent<cuttingObject>();
        if (!obj.full && !obj.is_on)
        {
            if ((one_h == "carrot" || one_h == "onion" || one_h == "cheese"))
            {
				source.PlayOneShot (cuttingZuchinni);
				source.PlayOneShot (cuttingCarrot);
                go.GetComponent<cuttingObject>().cutting = one_h;
                go.GetComponent<cuttingObject>().is_cutting = true;
                one_h = "";
				//this.GetComponent<timerObject>().genTimerAtLower(4, 0, 35);
                Destroy(go_1h);
            }
            else if ((two_h == "carrot" || two_h == "onion" || two_h == "cheese"))
            {
				source.PlayOneShot (cuttingZuchinni);
				source.PlayOneShot (cuttingCarrot);
                go.GetComponent<cuttingObject>().cutting = two_h;
                go.GetComponent<cuttingObject>().is_cutting = true;
                two_h = "";
				//this.GetComponent<timerObject>().genTimerAtLower(4, 0, 35);
                Destroy(go_2h);
            }
        }
        else if (!string.IsNullOrEmpty(obj.stored) && !obj.is_on)
        {
            if (string.IsNullOrEmpty(one_h))
            {
                one_h = obj.stored;
                obj.stored = "";
                obj.full = false;
                go_1h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                go_1h.transform.SetParent(gameObject.transform);
                go.GetComponent<SpriteRenderer>().sprite = go.GetComponentInParent<cuttingObject>().c_empty;
            }
            else if (string.IsNullOrEmpty(two_h))
            {
                two_h = obj.stored;
                obj.stored = "";
                obj.full = false;
                go_2h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2 / 3 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                go_2h.transform.SetParent(gameObject.transform);
                go.GetComponent<SpriteRenderer>().sprite = go.GetComponentInParent<cuttingObject>().c_empty;
            }
        }
    }

    void cuttingPickUpAction(GameObject go)
    {
        if (!string.IsNullOrEmpty(go.GetComponent<cuttingPickUp>().stored))
        {
            if (string.IsNullOrEmpty(one_h))
            {
                one_h = go.GetComponent<cuttingPickUp>().stored;
                go.GetComponent<cuttingPickUp>().stored = "";
                go.GetComponent<cuttingPickUp>().full = false;
                go_1h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.right / 2 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                go_1h.transform.SetParent(gameObject.transform);
                go.GetComponent<SpriteRenderer>().sprite =  go.GetComponentInParent<cuttingObject>().c_empty;

                go.GetComponentInParent<cuttingObject>().fullContainers -= 1;

            }
            else if (string.IsNullOrEmpty(two_h))
            {
                two_h = go.GetComponent<cuttingPickUp>().stored;
                go.GetComponent<cuttingPickUp>().stored = "";
                go.GetComponent<cuttingPickUp>().full = false;
                go_2h = Instantiate(go.GetComponent<nameAndPosition>().go, transform.position + Vector3.left * 2 / 3 + Vector3.down * 1 / 2, transform.rotation) as GameObject;
                go_2h.transform.SetParent(gameObject.transform);
                go.GetComponent<SpriteRenderer>().sprite = go.GetComponentInParent<cuttingObject>().c_empty;

                go.GetComponentInParent<cuttingObject>().fullContainers -= 1;

            }
        }
    }

    void customerAction(GameObject go) {
		//Debug.Log ("HEllO");
		if (hand_with_Food () == "one_h") {
			//update dropoffpoint food name
			
			if (string.IsNullOrEmpty (go.GetComponent<Customer> ().food_given)) {
				go.GetComponent<Customer> ().food_given = one_h;
				//add sprite of food
				//delete 1h
				Destroy (go_1h);
				one_h = "";
			}
		} else if (hand_with_Food () == "two_h") {
			//update dropoffpoint food name
			if (string.IsNullOrEmpty (go.GetComponent<Customer> ().food_given)) {
				go.GetComponent<Customer> ().food_given = two_h;
				//add sprite of food
				//delete 2h
				Destroy (go_2h);
				two_h = "";
			}
		}
	}

	void trashAction(GameObject go) {
		if (!string.IsNullOrEmpty (two_h)) {
			two_h = "";
			Destroy (go_2h);
			source.PlayOneShot(trashSFX);
			go.GetComponent<Animator>().SetTrigger("trash_on");
		} else if (!string.IsNullOrEmpty (one_h)) {
			one_h = "";
			Destroy (go_1h);
			source.PlayOneShot(trashSFX);
			go.GetComponent<Animator>().SetTrigger("trash_on");
		} 
	}
}


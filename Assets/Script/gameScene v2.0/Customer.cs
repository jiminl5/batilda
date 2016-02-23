using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Customer : MonoBehaviour {
	bool hasFood = false;
	bool waitingOnFood = false;
	public string foodWaitingOn = "none";
	public Recipie current_food;
	public string food_given;
	private GameObject foodSprite;
    public Queue<string> peasantFoodQueue;
	// Use this for initialization
	void Start () {
        /*peasantFoodQueue = new Queue<string>();
        string[] peasantFoodList = PlayerPrefs.GetString("peasantFoodList").Split(';');
        foreach (string food in peasantFoodList)
        {
            peasantFoodQueue.Enqueue(food);
        }
        findRecipe(peasantFoodQueue.Peek());*/
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (hasFood);
		//Debug.Log (waitingOnFood);
		if (!hasFood) {
			if (!waitingOnFood) {
                //StartCoroutine(ExecuteAfterDelay(Random.Range (0,5)));
                //Debug.Log(peasantFoodQueue.Peek());
                //current_food = findRecipe(peasantFoodQueue.Dequeue());
                foodWaitingOn = current_food.name;
                Debug.Log("waiting on: " + foodWaitingOn);
                foodSprite = Instantiate(current_food.go, transform.position + Vector3.up / 2, transform.rotation) as GameObject;
                foodSprite.transform.parent = transform;
                waitingOnFood = true;

                waitingOnFood = true;
			}
            else if (food_given == foodWaitingOn)
            {
				if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().hand_with_Food(foodWaitingOn) == "one_h")
				{
					GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().one_h = "";
					Destroy (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().go_1h);
				}
				else if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().two_h == foodWaitingOn)
				{
					GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().two_h = "";
					Destroy (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().go_2h);
				}
				waitingOnFood = false;
				foodWaitingOn = "none";
				food_given = "";
				//given correct food!
				Debug.Log ("yum!");
                CustomerExit();
                GameObject.Find("levelHandler").GetComponent<levelHandler>().customersServed++;
                Destroy (this.gameObject);
				Destroy (foodSprite);
                GameObject.Find("levelHandler").GetComponent<levelHandler>().updateBools = true;

            }
            else if (food_given != foodWaitingOn && !string.IsNullOrEmpty(food_given))
            {
				Debug.Log ("this isn't my order!");
				food_given = "";
			}
		}
	}

    void CustomerExit()
    {
        this.transform.parent.eulerAngles = new Vector3(0, 180, 0);
        this.GetComponentInParent<CustomerAI>().direction = 6;
    }

	IEnumerator ExecuteAfterDelay(float delay)
	{
		Debug.Log (delay);
		yield return new WaitForSeconds(delay);
		current_food = randomRecipe();
		foodWaitingOn = current_food.name;
		Debug.Log ("waiting on: " + foodWaitingOn);
		foodSprite = Instantiate (current_food.go, transform.position + Vector3.up / 2, transform.rotation) as GameObject;
		foodSprite.transform.parent = transform;
		waitingOnFood = true;
		//food_ready = true;
		//update sprite;
	}

	Recipie randomRecipe() {
		GameObject[] food_list = GameObject.FindGameObjectsWithTag ("food");
		Debug.Log (food_list [Random.Range (0, food_list.Length)].GetComponent<Recipie> ());
		return food_list[Random.Range(0, food_list.Length)].GetComponent<Recipie>();
	}

    Recipie findRecipe (string food)
    {
        Debug.Log("Recipies/Food_Recipes/" + food);
        //Object load = Resources.Load(food);
        //GameObject load = AssetDatabase.LoadAssetAtPath("Assets/Resources/" + food, typeof(GameObject)) as GameObject;

        GameObject load = Resources.Load("Recipies/Food_Recipes/" + food) as GameObject;
        Debug.Log(load.name);
        if (load == null)
            Debug.Log("load not found");
        //return load.GetComponent<Recipie>();
        //Recipie testr = new Recipie();
        return load.GetComponent<Recipie>();
    }
}

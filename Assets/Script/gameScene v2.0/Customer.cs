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


    public bool needsToOrder = true;
    public bool tempObjInstantiated = false;
    public GameObject tempObj;

    public bool moneyPickedUp = false;
    public bool moneyOn = false;
    private GameObject moneySprite;


	// Use this for initialization
	void Start () {
        /*peasantFoodQueue = new Queue<string>();
        string[] peasantFoodList = PlayerPrefs.GetString("peasantFoodList").Split(';');
        foreach (string food in peasantFoodList)
        {
            peasantFoodQueue.Enqueue(food);
        }
        findRecipe(peasantFoodQueue.Peek());*/
        tempObj = Resources.Load("Exclamation_Point") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (hasFood);
		//Debug.Log (waitingOnFood);
        if (needsToOrder)
        {
            //play anim of waving hand


            //temporary instantiation.
            if (!tempObjInstantiated)
            {
                tempObj = Instantiate(tempObj, transform.position + Vector3.up / 2, transform.rotation) as GameObject;
                tempObj.transform.parent = transform;
                tempObjInstantiated = true;
            }
        }
        else if (!needsToOrder && tempObj)
        {
            Destroy(tempObj);
        }
		if (!hasFood && !needsToOrder) {
			if (!waitingOnFood) {
                //StartCoroutine(ExecuteAfterDelay(Random.Range (0,5)));
                //Debug.Log(peasantFoodQueue.Peek());
                //current_food = findRecipe(peasantFoodQueue.Dequeue());
                foodWaitingOn = current_food.name;
                Debug.Log("waiting on: " + foodWaitingOn);
                foodSprite = Instantiate(current_food.go, transform.position + Vector3.up / 2, transform.rotation) as GameObject;
                foodSprite.transform.parent = transform;
                StartCoroutine(ScaleOverTime(0.5f));
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

                moneySprite = Instantiate(Resources.Load("Money/money_2") as GameObject); //temp money sprite
                moneySprite.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                moneyOn = true;

                //GameObject.Find("levelHandler").GetComponent<levelHandler>().customersServed++;
                //Destroy (this.gameObject);
				//Destroy (foodSprite);
                //GameObject.Find("levelHandler").GetComponent<levelHandler>().updateBools = true;

            }
            else if (food_given != foodWaitingOn && !string.IsNullOrEmpty(food_given))
            {
				Debug.Log ("this isn't my order!");
				food_given = "";
			}
            if (moneyPickedUp)
            {
                GameObject.Find("levelHandler").GetComponent<levelHandler>().customersServed++;
                GameObject.Find("levelHandler").GetComponent<levelHandler>().updateBools = true;
                this.GetComponentInParent<CustomerAI>().confirmExit(moneyPickedUp);
                Destroy(moneySprite);
                //Destroy(foodSprite);
                Destroy(this.gameObject);
            }
		}
	}

    void CustomerExit()
    {
        this.transform.parent.eulerAngles = new Vector3(0, 180, 0);
        this.GetComponentInParent<CustomerAI>().direction = 6;
        Destroy(foodSprite);
    }


    //test
    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = foodSprite.transform.localScale;
        Vector3 startScale = new Vector3(0.01f, 0.01f, 0.01f);
        Debug.Log("SCALING..");
        float currentTime = 0.0f;
        do
        {
            foodSprite.transform.localScale = Vector3.Lerp(startScale, originalScale, Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, (currentTime / time)) ) );
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
//test





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

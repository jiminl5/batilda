using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Customer : MonoBehaviour {
	bool hasFood = false;
	bool waitingOnFood = false;
	public string foodWaitingOn = "none";
	public Recipie current_food;
	public string food_given;
	private GameObject foodSprite;
    public Queue<string> peasantFoodQueue;

    public Queue<string> foodQueue; //= GameObject.Find("levelHandler").GetComponent<levelHandler>().customerQueue.Peek().foodQueue;

    public bool needsToOrder = true;
    public bool tempObjInstantiated = false;
    public GameObject tempObj;

    public bool moneyPickedUp = false;
    public bool moneyOn = false;
    private GameObject moneySprite;
    private GameObject moneyParticle;
    private GameObject moodSprite;

    public GameObject speechBubble;

    public bool angryLeave; // CUSTOMER Leaving with Anger

    //Animation
    private int _PeasantState = Animator.StringToHash("Peasant_State");
    private Animator _Panimator;
    private bool eatingState;
    public bool eatingStateTutorial = false;
    private GameObject tutArrow;
    private int tutArrowCount;
	
	//TODO: simplify money sprite/amount/structure in customer.
	struct money
	{
		public int amount;

	}


    // Use this for initialization
    void Start () {
        eatingState = false;
        angryLeave = false;
        foodQueue = GameObject.Find("levelHandler").GetComponent<levelHandler>().current_customer.foodQueue;
        //Animation
        _Panimator = this.transform.GetComponentInParent<Animator>();
        /*peasantFoodQueue = new Queue<string>();
        string[] peasantFoodList = PlayerPrefs.GetString("peasantFoodList").Split(';');
        foreach (string food in peasantFoodList)
        {
            peasantFoodQueue.Enqueue(food);
        }
        findRecipe(peasantFoodQueue.Peek());*/
        //tempObj = Resources.Load("exclamation_point") as GameObject;
        //speechBubble = Resources.Load("speech_bubble") as GameObject;
        if (PlayerPrefs.GetString("tutorial") == "yes")
        {
            tutArrow = Resources.Load("Touch") as GameObject;
        }
        else
        {
            Destroy(tutArrow);
        }

            //moneyParticle = Instantiate(Resources.Load("Coins"), transform.position, Quaternion.identity) as GameObject;
            //moneyParticle.GetComponent<ParticleSystem>().collision.SetPlane(1, GameObject.Find("counter_invis_plane").transform);
        }

	// Update is called once per frame
	void Update () {
        //Added by Jimmy 2016-04-24
        if (LevelSelectionModal.PauseActive && this.transform.childCount != 0 && PlayerPrefs.GetString("tutorial") != "yes")
        {
            if (this.transform.GetChild(0).GetComponent<BoxCollider2D>())
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            else if (this.transform.GetChild(1).GetComponent<BoxCollider2D>())
                this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (!LevelSelectionModal.PauseActive && this.transform.childCount != 0 && PlayerPrefs.GetString("tutorial") != "yes")
        {
            if (this.transform.GetChild(0).GetComponent<BoxCollider2D>())
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            else if (this.transform.GetChild(1).GetComponent<BoxCollider2D>())
                this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
        }
        //Tutorial
        if (LevelSelectionModal.PauseActive && this.transform.childCount != 0 && PlayerPrefs.GetString("tutorial") == "yes")
        {
            if (this.transform.GetChild(0).GetComponent<BoxCollider2D>())
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            else if (this.transform.GetChild(1).GetComponent<BoxCollider2D>())
                this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (!LevelSelectionModal.PauseActive && this.transform.childCount != 0 && PlayerPrefs.GetString("tutorial") == "yes")
        {
            if (this.transform.GetChild(0).GetComponent<BoxCollider2D>() && !GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled)
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            else if (this.transform.GetChild(1).GetComponent<BoxCollider2D>() && !GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled)
                this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
            else if (this.transform.GetChild(0).GetComponent<BoxCollider2D>() && GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled)
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            else if (this.transform.GetChild(1).GetComponent<BoxCollider2D>() && GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled)
                this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        }
            
        //Debug.Log (hasFood);
        //Debug.Log (waitingOnFood);
        if (needsToOrder)
        {
            //play anim of waving hand


            //temporary instantiation.
            if (!tempObjInstantiated)
            {

                speechBubble = Instantiate(speechBubble, new Vector2(this.transform.parent.position.x, this.transform.parent.position.y + 3.0f), Quaternion.identity) as GameObject;
                speechBubble.transform.parent = transform;

				tempObj = Instantiate(tempObj, new Vector2(this.transform.parent.position.x, this.transform.parent.position.y + 3.0f), Quaternion.identity) as GameObject;
                tempObj.transform.parent = speechBubble.transform;
                tempObjInstantiated = true;

                if (PlayerPrefs.GetString("tutorial") == "yes" && tutArrowCount != 1)
                {
                    Instantiate(tutArrow, new Vector2(speechBubble.transform.position.x - 2.3f, speechBubble.transform.parent.position.y + 0.5f), Quaternion.identity);
                }
            }
        }
        else if (!needsToOrder && tempObj)
        {
            if (PlayerPrefs.GetString("tutorial") == "yes")
            {
                tutArrowCount = 1;
                CircleHighLight.customerCame = true;
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
            }
            //OpenSignAnim.confirm_tutorial_start = true;
            else
                CircleHighLight.customerCame = false;
            //OpenSignAnim.confirm_tutorial_start = false;
            _Panimator.SetInteger(_PeasantState, 3);
            Destroy(GameObject.Find("Touch(Clone)"));
            Destroy(tempObj);
        }
		if (!hasFood && !needsToOrder && !eatingState) {
			if (!waitingOnFood && !moneyOn) {
                //StartCoroutine(ExecuteAfterDelay(Random.Range (0,5)));
                //Debug.Log(peasantFoodQueue.Peek());
                //current_food = findRecipe(peasantFoodQueue.Dequeue());
                Debug.Log("foodqueue in customer:" + foodQueue.Peek());
                current_food = findRecipe(foodQueue.Peek());
                foodWaitingOn = foodQueue.Dequeue();
                Debug.Log("waiting on: " + foodWaitingOn);
                foodSprite = Instantiate(current_food.go, new Vector2(this.transform.parent.position.x, this.transform.parent.position.y + 3.2f), Quaternion.identity) as GameObject;
                foodSprite.transform.parent = speechBubble.transform;
                StartCoroutine(ScaleOverTime(0.5f, foodSprite));
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
                Destroy(foodSprite);
                /**
                    EATING ANIMATION & DELAY - Jimmy 06/23/2016
                **/
                this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false; //Speech Bubble
                //this.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().enabled = false; //Patience Meter
                eatingState = true;
                _Panimator.SetInteger(_PeasantState, 5);
                Invoke("EatingDelay", 2.8f); // 2.8f fixed delay

                //Moved to EatingDelay function
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

                moneyParticle = Instantiate(Resources.Load("Coins"), moneySprite.transform.position, Quaternion.identity) as GameObject;
                moneyParticle.GetComponent<ParticleSystem>().collision.SetPlane(1, GameObject.Find("counter_invis_plane").transform);

                if (this.transform.parent.gameObject.name.Contains("Peasant"))
				{
                    moneyParticle.GetComponent<ParticleSystem>().maxParticles = 1;
					PlayerPrefs.SetInt("temp_coin", PlayerPrefs.GetInt("temp_coin") + 1);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
				}
                else if (this.transform.parent.gameObject.name.Contains("Artisan"))
				{
                    moneyParticle.GetComponent<ParticleSystem>().maxParticles = 2;
					PlayerPrefs.SetInt("temp_coin", PlayerPrefs.GetInt("temp_coin") + 2);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins+= 2;
				}
                else if (this.transform.parent.gameObject.name.Contains("Middle Class"))
				{
                    moneyParticle.GetComponent<ParticleSystem>().maxParticles = 5;
					PlayerPrefs.SetInt("temp_coin", PlayerPrefs.GetInt("temp_coin") + 5);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins += 5;
				}
                else if (this.transform.parent.gameObject.name.Contains("Noble"))
				{
                    moneyParticle.GetComponent<ParticleSystem>().maxParticles = 8;
					PlayerPrefs.SetInt("temp_coin", PlayerPrefs.GetInt("temp_coin") + 8);
					GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins += 8;
				}

                moneyParticle.GetComponent<ParticleSystem>().Play();
                levelHandler.customersLeft -= 1;
                Destroy(moneySprite);
                //Destroy(foodSprite);
                Destroy(this.gameObject);
            }
		}
	}

    void EatingDelay()
    {
        eatingState = false;
        if (PlayerPrefs.GetString("tutorial") == "yes")
        {
            eatingStateTutorial = true;
        }
        if (this.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<patienceMeter>().timeBar.GetComponent<Image>().fillAmount < 0.45f
        && this.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<patienceMeter>().timeBar.GetComponent<Image>().fillAmount > 0f)
            _Panimator.SetInteger(_PeasantState, 4);
        else
            _Panimator.SetInteger(_PeasantState, 3);

        if (foodQueue.Count == 0 && !angryLeave) //Added boolean - angryLeave
        {
            CustomerExit();
            if (this.gameObject.transform.parent.gameObject.name.Contains("Peasant"))
            {
                moneySprite = Instantiate(Resources.Load("Money/money_0") as GameObject);
            }
            if (this.gameObject.transform.parent.gameObject.name.Contains("Artisan"))
            {
                moneySprite = Instantiate(Resources.Load("Money/money_1") as GameObject);
            }
            if (this.gameObject.transform.parent.gameObject.name.Contains("Middle Class"))
            {
                moneySprite = Instantiate(Resources.Load("Money/money_2") as GameObject);
            }
            if (this.gameObject.transform.parent.gameObject.name.Contains("Noble"))
            {
                moneySprite = Instantiate(Resources.Load("Money/money_3") as GameObject);
            }
            //moneySprite = Instantiate(Resources.Load("Money/money_2") as GameObject); //temp money sprite
            moneySprite.GetComponent<SpriteRenderer>().sortingOrder = 3;
            moneySprite.transform.position = new Vector2(this.transform.parent.position.x, this.transform.parent.position.y + 2.5f);
            moneyOn = true;
            moodSprite = Instantiate(Resources.Load("smile"), new Vector2(this.transform.parent.position.x, this.transform.parent.position.y + 2.8f), Quaternion.identity) as GameObject;
            moodSprite.transform.parent = transform.parent;
            StartCoroutine(ScaleOverTime(0.5f, moodSprite));
        }
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        //this.gameObject.transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
    }

    public void CustomerExit()
    {
        this.transform.parent.eulerAngles = new Vector3(0, 180, 0);
        this.GetComponentInParent<CustomerAI>().direction = 6;
        Destroy(this.transform.parent.GetChild(0).gameObject); //Destroy PatienceBar
        //Destroy(foodSprite);
        Destroy(speechBubble);
    }
    public void DestroyFoodSprite()
    {
        this.GetComponentInParent<CustomerAI>().confirmExit(true);
        if (tempObj != null)
        {
            GameObject.Find("levelHandler").GetComponent<levelHandler>().DequeueCustomerQ();
            levelHandler.customersLeft -= 1;
            Destroy(tempObj);
            //foodQueue.Dequeue(); // Not sure when food is assigned to the customers, after exclamation mark destroyed??? or before??
        }
        else
        {
            GameObject.Find("levelHandler").GetComponent<levelHandler>().DequeueCustomerQ();
            levelHandler.customersLeft -= 1;
            Destroy(foodSprite);
        }
    }

    //test
    IEnumerator ScaleOverTime(float time, GameObject go)
    {
        Vector3 originalScale = go.transform.localScale;
        Vector3 startScale = new Vector3(0.01f, 0.01f, 0.01f);
        //Debug.Log("SCALING..");
        float currentTime = 0.0f;
        do
        {
            go.transform.localScale = Vector3.Lerp(startScale, originalScale, Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, (currentTime / time)) ) );
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time && go);
    }
//test





IEnumerator ExecuteAfterDelay(float delay)
	{
		Debug.Log (delay);
		yield return new WaitForSeconds(delay);
		current_food = randomRecipe();
		foodWaitingOn = current_food.name;
		Debug.Log ("waiting on: " + foodWaitingOn);
		foodSprite = Instantiate (current_food.go, new Vector2(this.transform.parent.position.x, this.transform.parent.position.y + 2.8f), Quaternion.identity) as GameObject;
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
        //Debug.Log("Recipies/Food_Recipes/" + food);
        //Object load = Resources.Load(food);
        //GameObject load = AssetDatabase.LoadAssetAtPath("Assets/Resources/" + food, typeof(GameObject)) as GameObject;

        //GameObject load = Resources.Load("Recipies/Food_Recipes/" + food) as GameObject;
        //Debug.Log(load.name);
        //if (load == null)
        //Debug.Log("load not found");
        //return load.GetComponent<Recipie>();
        //Recipie testr = new Recipie();
        //return load.GetComponent<Recipie>();
        //GameObject load = Resources.Load("Recipies/Food_Recipes/" + food) as GameObject;
        //Recipie recipe = load.GetComponent<Recipie>();
        print(food);

        Recipie recipe = GameObject.Find(food + "(Clone)").GetComponent<Recipie>();
        return recipe;
    }

    //ADDED BY JIMMY 2016-04-14
    public void SetAnger()
    {
        angryLeave = true;
    }
    public bool CheckAnger()
    {
        return angryLeave;
    }
}

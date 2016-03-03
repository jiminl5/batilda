using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelHandler : MonoBehaviour {

	public AudioSource source;
	public GameObject[] GameplaySoundtracks;

	public Font oldaniaADFStd;

    //customers
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;


    //old
    public bool waitingForC1 = false;
    public bool waitingForC2 = false;
    //old

    public bool customer1 = false;
    public bool customer2 = false;
    public bool customer3 = false;
    public bool customer4 = false;
    public bool customer5 = false;

    /// <summary>
    public bool customer1spawned = false;
    public bool customer2spawned = false;
    public bool customer3spawned = false;
    public bool customer4spawned = false;
    public bool customer5spawned = false;
    /// </summary>


    public ArrayList emptyCustomers;

    private int randomCustomer;
    private Queue<int> randomCustomerIndexes;
    public static List<string> cus_digit = new List<string>();

    GameObject _c1;
    GameObject _c2;

    //public ArrayList customerList;
    public GameObject[] customerList;

    public bool finished = false;
    private string text;
    public int customersServed;
    private static Random rng = new Random();
    public bool updateBools;

    //cooking objects
    public int maxGrillCount;
    public int maxOvenCount;
    public int maxStoveCount;
    public int maxWarmingPlateCount;

    public int grillCount;
    public int ovenCount;
    public int stoveCount;
    public int warmingPlateCount;
    //ingredients
    public bool wheatOn;
    public bool cheeseOn;
    public bool carrotOn;
    public bool onionOn;
    public bool fishOn;
    public bool meatOn;

    //other objects
    public bool cuttingBoardOn;
    public bool rollingPinOn;
    public bool appleOn;
    public bool grapeOn;
    public bool honeyOn;
    public bool sauceOn;


    //food lists
    public string peasantFoodList; //initalized with ";" as breakers. ex: "bread;carrot soup;grilled fish"
    public Queue<string> peasantFoodQueue;
    public int customersWaiting;

    //time for level
    public float levelTime;

    void Awake()
    {
        customerList = new GameObject[5];
        emptyCustomers = new ArrayList();
        randomCustomerIndexes = new Queue<int>();
    }

    // Use this for initialization
    void Start () {
        customersServed = 0;
        /*
        grillCount = grill;
        ovenCount = oven;
        stoveCount = stove;

        wheatOn = wheat;
        cheeseOn = cheese;
        carrotOn = carrot;
        onionOn = onion;
        fishOn = fish;
        meatOn = meat;

        cuttingBoardOn = cuttingBoard;
        rollingPinOn = rollingPin;
        appleOn = apple;
        grapeOn = grape;
        honeyOn = honey;
        sauceOn = sauce;

        peasantFoodList = peasant;
        */
        peasantFoodQueue = new Queue<string>();
        //set what player has first
        grillCount = PlayerPrefs.GetInt("grill");
        ovenCount = PlayerPrefs.GetInt("oven");
        stoveCount = PlayerPrefs.GetInt("stove");
        warmingPlateCount = PlayerPrefs.GetInt("warmingPlate");

        if (PlayerPrefs.GetInt("level") == 0) //test_level_Everything_on
        {
            maxGrillCount = 4;
            maxOvenCount = 4;
            maxStoveCount = 4;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 4;
            if (ovenCount > maxOvenCount)
                ovenCount = 4;
            if (stoveCount > maxStoveCount)
                stoveCount = 4;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = true;
            cheeseOn = true;
            carrotOn = true;
            onionOn = true;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = true;
            rollingPinOn = true;

            appleOn = true;
            grapeOn = true;
            honeyOn = true;
            sauceOn = true;

            peasantFoodList = "apple cider;apple cider;apple cider;apple cider";
                //"grilledMeat;grilledMeat;bread;bread;bread;grilled fish;grilled fish;grilled fish";

            levelTime = 120;
			GameplaySoundtracks[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("level") == 1 && PlayerPrefs.GetString("tutorial") == "yes") //tutorial level (level one)
        {
            maxGrillCount = 1;
            maxOvenCount = 0;
            maxStoveCount = 0;
            maxWarmingPlateCount = 1;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 1;

            wheatOn = false;
            cheeseOn = false;
            carrotOn = false;
            onionOn = false;
            fishOn = false;
            meatOn = true;

            cuttingBoardOn = false;
            rollingPinOn = false;
            appleOn = false;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            rollingPinOn = false;
            cuttingBoardOn = false;

            peasantFoodList = "grilledMeat;grilledMeat";

            levelTime = 60;
			GameplaySoundtracks[0].SetActive(true);
			//GameObject.Find("MainMenuSoundtrack").SetActive(false);
			
        }



            if (PlayerPrefs.GetInt("level") == 2) //level two
        {
            maxGrillCount = 1;
            maxOvenCount = 0;
            maxStoveCount = 0;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = false;
            cheeseOn = false;
            carrotOn = false;
            onionOn = false;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = false;
            rollingPinOn = false;
            appleOn = false;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            rollingPinOn = false;
            cuttingBoardOn = false;

            peasantFoodList = "grilledMeat;grilled fish;grilled fish;grilled fish";

            levelTime = 90;
			GameplaySoundtracks[0].SetActive(true);
        }

        if (PlayerPrefs.GetInt("level") == 3) //level three
        {
            maxGrillCount = 1;
            maxOvenCount = 0;
            maxStoveCount = 0;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = false;
            cheeseOn = false;
            carrotOn = false;
            onionOn = false;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = false;
            rollingPinOn = false;

            appleOn = false;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            peasantFoodList = "grilledMeat;grilledMeat;grilled fish;grilled fish;grilled fish;grilled fish";

            levelTime = 90;
        }

        if (PlayerPrefs.GetInt("level") == 4) //level four
        {
            maxGrillCount = 2;
            maxOvenCount = 1;
            maxStoveCount = 0;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = true;
            cheeseOn = false;
            carrotOn = false;
            onionOn = false;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = false;
            rollingPinOn = true;

            appleOn = false;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            peasantFoodList = "grilledMeat;grilledMeat;bread;bread;bread;grilled fish;grilled fish;grilled fish";

            levelTime = 120;
			GameplaySoundtracks[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("level") == 5) //level five
        {
            maxGrillCount = 2;
            maxOvenCount = 1;
            maxStoveCount = 0;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = true;
            cheeseOn = false;
            carrotOn = false;
            onionOn = false;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = false;
            rollingPinOn = true;

            appleOn = true;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            peasantFoodList = "grilledMeat;grilledMeat;bread;bread;bread;grilled fish;grilled fish;apple cider;apple cider;apple cider";

            levelTime = 120;
			GameplaySoundtracks[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("level") == 8) //level eight
        {
            maxGrillCount = 2;
            maxOvenCount = 1;
            maxStoveCount = 0;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = true;
            cheeseOn = false;
            carrotOn = false;
            onionOn = true;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = true;
            rollingPinOn = true;

            appleOn = true;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            peasantFoodList = "grilledMeat;grilledMeat;bread;bread;apple cider;apple cider;apple cider;grilled onion;grilled onion;grilled onion";

            levelTime = 150;
        }

        if (PlayerPrefs.GetInt("level") == 9) //level nine
        {
            maxGrillCount = 2;
            maxOvenCount = 1;
            maxStoveCount = 0;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = true;
            cheeseOn = false;
            carrotOn = false;
            onionOn = true;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = true;
            rollingPinOn = true;

            appleOn = true;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            peasantFoodList = "grilledMeat;grilledMeat;grilledMeat;bread;bread;bread;bread;apple cider;apple cider;grilled onion;grilled onion;grilled fish";

            levelTime = 150;
        }

        if (PlayerPrefs.GetInt("level") == 10) //level ten
        {
            maxGrillCount = 2;
            maxOvenCount = 1;
            maxStoveCount = 0;
            maxWarmingPlateCount = 4;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;
            if (warmingPlateCount > maxWarmingPlateCount)
                warmingPlateCount = 4;

            wheatOn = true;
            cheeseOn = false;
            carrotOn = true;
            onionOn = true;
            fishOn = true;
            meatOn = true;

            cuttingBoardOn = true;
            rollingPinOn = true;

            appleOn = true;
            grapeOn = false;
            honeyOn = false;
            sauceOn = false;

            peasantFoodList = "bread;bread;apple cider;apple cider;grilled carrot;grilled carrot;grilled carrot;grilled carrot;grilled onion;grilled onion;grilled fish;grilled fish";

            levelTime = 160;
        }


        string[] peasantFoodShuffle = peasantFoodList.Split(';');
        shuffle(peasantFoodShuffle);
        foreach (string food in peasantFoodShuffle)
        {
            peasantFoodQueue.Enqueue(food);
        }
        customersWaiting = peasantFoodQueue.Count;
        //max - how many cooking objects you have (to iterate later)
        grillCount = 4 - maxGrillCount;
        ovenCount = 4 - maxOvenCount;
        stoveCount = 4 - maxStoveCount;
        warmingPlateCount = 4 - maxWarmingPlateCount;
        Debug.Log("warming plate count: " + warmingPlateCount);
        //find stuff
        GameObject grills = GameObject.Find("grills");
        GameObject ovens = GameObject.Find("ovens");
        GameObject stoves = GameObject.Find("stoves");
        GameObject warmingPlates = GameObject.Find("warmingPlates");

        GameObject wheat = GameObject.Find("wheat");
        GameObject cheese = GameObject.Find("cheese");
        GameObject carrot = GameObject.Find("carrot");
        GameObject onion = GameObject.Find("onion");
        GameObject fish = GameObject.Find("fish");
        GameObject meat = GameObject.Find("meat");

        GameObject appleCider = GameObject.Find("apple cider");
        GameObject grapeCider = GameObject.Find("grape cider");
        GameObject honeyCider = GameObject.Find("honey cider");

        GameObject cuttingBoard = GameObject.Find("cuttingBoard");
        GameObject rollingPin = GameObject.Find("rollingPin");

        GameObject Sauce = GameObject.Find("sauce");

        //set stuff on or off
        foreach (Transform grill in grills.transform)
        {
            if (grillCount > 0)
            {
                grill.gameObject.SetActive(false);
            }
            else if(grillCount <= 0)
            {
                break;
            }
            grillCount -= 1;
        }

        foreach (Transform oven in ovens.transform)
        {
            if (ovenCount > 0)
            {
                oven.gameObject.SetActive(false);
            }
            else if(ovenCount <= 0)
            {
                break;
            }
            ovenCount -= 1;
        }

        foreach (Transform stove in stoves.transform)
        {
            if (stoveCount > 0)
            {
                stove.gameObject.SetActive(false);
            }
            else if(stoveCount <= 0)
            {
                break;
            }
            stoveCount -= 1;
        }


        foreach (Transform warmingPlate in warmingPlates.transform)
        {
            if (warmingPlateCount > 0)
            {
                warmingPlate.gameObject.SetActive(false);
            }
            else if (warmingPlateCount <= 0)
            {
                break;
            }
            warmingPlateCount -= 1;

        }

        if (!wheatOn)
            wheat.SetActive(false);
        if (!cheeseOn)
            cheese.SetActive(false);
        if (!carrotOn)
            carrot.SetActive(false);
        if (!onionOn)
            onion.SetActive(false);
        if (!fishOn)
            fish.SetActive(false);
        if (!meatOn)
            meat.SetActive(false);
        if (!appleOn)
            appleCider.SetActive(false);
        if (!grapeOn)
            grapeCider.SetActive(false);
        if (!honeyOn)
            honeyCider.SetActive(false);
        if (!sauceOn)
            Sauce.SetActive(false);
            
            

        if (!rollingPinOn)
            rollingPin.SetActive(false);
        if (!cuttingBoardOn)
            cuttingBoard.SetActive(false);


        //set level time
        GameObject.Find("Main Camera").GetComponent<StopWatch>().startTime = levelTime;
    }
    bool checkifNoCustomers()
    {
        foreach (GameObject customer in customerList)
        {
            if (customer != null)
            {
                return false;
            }
        }
        return true;
    }

    public void updateCustomerBools()
    {
        for (int i=0; i < 5; i++)
        {
            if (!customerList[i])
            {
                if (i == 0)
                {
                    customer1 = false;
                }
                else if (i == 1)
                {
                    customer2 = false;
                }
                else if (i == 2)
                {
                    customer3 = false;
                }
                else if (i == 3)
                {
                    customer4 = false;
                }
                else if (i == 4)
                {
                    customer5 = false;
                }
            }
        }
    }

    /*
    int getRandomCustomer()
    {
        ArrayList emptyCustomers = getEmptyCustomerIndexes();
        //first, remove any customers that are trying to spawn
        if (customer1 == true)
        {
            if (emptyCustomers.Contains(0))
            {
                //Debug.Log("IT HAS 0");
            }
            emptyCustomers.Remove(0);
        }
        if (customer2 == true)
        {
            if (emptyCustomers.Contains(1))
            {
                //Debug.Log("IT HAS 1");
            }
            emptyCustomers.Remove(1);
        }
        if (customer3 == true)
        {
            if (emptyCustomers.Contains(2))
            {
                //Debug.Log("IT HAS 2");
            }
            emptyCustomers.Remove(2);
        }
        if (customer4 == true)
        {
            if (emptyCustomers.Contains(3))
            {
                //Debug.Log("IT HAS 3");
            }
            emptyCustomers.Remove(3);
        }
        if (customer5 == true)
        {
            if (emptyCustomers.Contains(4))
            {
                //Debug.Log("IT HAS 4");
            }
            emptyCustomers.Remove(4);
        }
        Debug.Log(emptyCustomers.Count);
        // Debug.Log("customer1: " + customer1);
        //Debug.Log("customer2: " + customer2);
        //Debug.Log("customer3: " + customer3);
        //Debug.Log("customer4: " + customer4);
        //Debug.Log("customer5: " + customer5);
        //Debug.Log("THIS IS EMPTY CUSTOMER COUNT: " + emptyCustomers.Count);
        int r = Random.Range(0, emptyCustomers.Count);
        randomCustomer = (int)emptyCustomers[r];
       // Debug.Log("this is random customer:" +randomCustomer);
        if (randomCustomer == 0)
        {
            customer1 = true;
        }
        else if (randomCustomer == 1)
        {
            customer2 = true;
        }
        else if (randomCustomer == 2)
        {
            customer3 = true;
        }
        else if (randomCustomer == 3)
        {
            customer4 = true;
        }
        else if (randomCustomer == 4)
        {
            customer5 = true;
        }
        return randomCustomer;
    }
    */
    // Update is called once per frame
    void Update()
    {
        //test
        if (!finished)
        {
            if (updateBools)
            {
                updateCustomerBools();
                updateBools = false;
            }
            finished = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StopWatch>().finished;
            /*
            if ( ( (!customer1 && CustomerAI.customerSat1) || (!customer2 && CustomerAI.customerSat2) || (!customer3 && CustomerAI.customerSat3) || (!customer4 && CustomerAI.customerSat4) || 
                (!customer5 && CustomerAI.customerSat5) ) && customersWaiting > 0)
            {
                randomCustomerIndexes.Enqueue(getRandomCustomer());
                int spawnTime = Random.Range(5, 10);
                //Debug.Log("THIS IS SPAWN TIME:" + spawnTime);
                Spawn();
                customersWaiting--;
                if (CustomerAI.customerSat1 && !customer1)
                {
                    customer1 = true;
                }
                if (CustomerAI.customerSat2 && !customer2)
                {
                    customer2 = true;
                }
                if (CustomerAI.customerSat3 && !customer3)
                {
                    customer3 = true;
                }
                if (CustomerAI.customerSat4 && !customer4)
                {
                    customer4 = true;
                }
                if (CustomerAI.customerSat5 && !customer5)
                {
                    customer5 = true;
                }
            }
            */
            if (customersServed == customersWaiting)//peasantFoodQueue.Count <= 0 && checkifNoCustomers())
            {
                finished = true;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StopWatch>().finished = true;
                PlayerPrefs.SetInt("temp_coin", customersServed);
            }
        }

    }
    
    void OnGUI()
    {
		GUIStyle textStyle = new GUIStyle ();
		textStyle.fontSize = Screen.width/25;
		textStyle.normal.textColor = Color.white;
		textStyle.font = oldaniaADFStd;
        text = string.Format(customersServed.ToString());
        GUI.Label(new Rect(10, 5, 100, 100), text, textStyle);
    }
    
    /*
    ArrayList getEmptyCustomerIndexes()
    { 
        ArrayList ec = new ArrayList();
        for (int i=0; i < 5; i++)
        {
            if (!customerList[i])
            {
                ec.Add(i);
            }
        }
        return ec;
    }*/

    public GameObject Spawn(string customerName)
    {
        //ArrayList emptyCustomers = getEmptyCustomerIndexes();

        //int i = randomCustomerIndexes.Dequeue();


        GameObject tempcustomer = Resources.Load("Customers/Peasants/customer") as GameObject;
        tempcustomer.GetComponent<Customer>().current_food = findRecipe(peasantFoodQueue.Dequeue());


        if (CustomerAI.customerSat1 && customerName == "cus_1")// && emptyCustomers.Contains(0))
        {
            tempcustomer.GetComponent<nameAndPosition>().x = 6;
            tempcustomer.GetComponent<nameAndPosition>().y = 2;
            tempcustomer.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.0f);
            //tempcustomer.transform.position = new Vector3(9, 2, 0);
            customer1 = true;
        }
        else if (CustomerAI.customerSat2 && customerName == "cus_2")// && emptyCustomers.Contains(1))
        {
            tempcustomer.GetComponent<nameAndPosition>().x = 7;
            tempcustomer.GetComponent<nameAndPosition>().y = 2;
            tempcustomer.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.0f);
            //tempcustomer.transform.position = new Vector3(10.5f, 2, 0);
            customer2 = true;
        }
        else if (CustomerAI.customerSat3 && customerName == "cus_3")// && emptyCustomers.Contains(2))
        {
            tempcustomer.GetComponent<nameAndPosition>().x = 8;
            tempcustomer.GetComponent<nameAndPosition>().y = 2;
            tempcustomer.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.0f);
            //tempcustomer.transform.position = new Vector3(12, 2, 0);
            customer3 = true;
        }
        else if (CustomerAI.customerSat4 && customerName == "cus_4")// && emptyCustomers.Contains(3))
        {
            tempcustomer.GetComponent<nameAndPosition>().x = 9;
            tempcustomer.GetComponent<nameAndPosition>().y = 2;
            tempcustomer.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.0f);
            //tempcustomer.transform.position = new Vector3(13.5f, 2, 0);
            customer4 = true;
        }
        else if (CustomerAI.customerSat5 && customerName == "cus_5")// && emptyCustomers.Contains(4))
        {
            tempcustomer.GetComponent<nameAndPosition>().x = 10;
            tempcustomer.GetComponent<nameAndPosition>().y = 2;
            tempcustomer.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.0f);
            //tempcustomer.transform.position = new Vector3(15, 2, 0);
            customer5 = true;
        }

        return Instantiate(tempcustomer);



        /*
        for (int i = 0; i < 5; i++)
        {
            if (!customerList[i] && peasantFoodQueue.Count > 0)
            {
                //spawn
                GameObject tempcustomer = Resources.Load("Customers/Peasants/customer") as GameObject;

                tempcustomer.GetComponent<Customer>().current_food = findRecipe(peasantFoodQueue.Dequeue());
                if (i == 0)
                {
                    tempcustomer.GetComponent<nameAndPosition>().x = 6;
                    tempcustomer.GetComponent<nameAndPosition>().y = 2;
                    tempcustomer.transform.position = new Vector3(9, 2, 0);
                    customer1 = true;
                }
                else if (i == 1)
                {
                    tempcustomer.GetComponent<nameAndPosition>().x = 7;
                    tempcustomer.GetComponent<nameAndPosition>().y = 2;
                    tempcustomer.transform.position = new Vector3(10.5f, 2, 0);
                    customer2 = true;
                }
                else if (i == 2)
                {
                    tempcustomer.GetComponent<nameAndPosition>().x = 8;
                    tempcustomer.GetComponent<nameAndPosition>().y = 2;
                    tempcustomer.transform.position = new Vector3(12, 2, 0);
                    customer3 = true;
                }
                else if (i == 3)
                {
                    tempcustomer.GetComponent<nameAndPosition>().x = 9;
                    tempcustomer.GetComponent<nameAndPosition>().y = 2;
                    tempcustomer.transform.position = new Vector3(13.5f, 2, 0);
                    customer4 = true;
                }
                else if (i == 4)
                {
                    tempcustomer.GetComponent<nameAndPosition>().x = 10;
                    tempcustomer.GetComponent<nameAndPosition>().y = 2;
                    tempcustomer.transform.position = new Vector3(15, 2, 0);
                    customer5 = true;
                }
                customerList[i] = Instantiate(tempcustomer);
            }

        }
        */


        //OLD SPAWN
        /*
        if (!waitingForC1 && peasantFoodQueue.Count > 0)
        {
            _c1 = Instantiate(c1);
            _c1.GetComponent<Customer>().current_food = findRecipe(peasantFoodQueue.Dequeue());
            waitingForC1 = true;
        }
        if (!waitingForC2 && peasantFoodQueue.Count > 0)
        {
            _c2 = Instantiate(c2);
            _c2.GetComponent<Customer>().current_food = findRecipe(peasantFoodQueue.Dequeue());
            waitingForC2 = true;
        }*/
    }

    Recipie findRecipe(string food)
    {
        Debug.Log("Recipies/Food_Recipes/" + food);
        //Object load = Resources.Load(food);
        //GameObject load = AssetDatabase.LoadAssetAtPath("Assets/Resources/" + food, typeof(GameObject)) as GameObject;

        GameObject load = Resources.Load("Recipies/Food Recipes/" + food) as GameObject;
        if (load == null)
            Debug.Log("load not found");
        Debug.Log(load.name);
        //return load.GetComponent<Recipie>();
        //Recipie testr = new Recipie();
        return load.GetComponent<Recipie>();
    }

    void shuffle(string[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }





}

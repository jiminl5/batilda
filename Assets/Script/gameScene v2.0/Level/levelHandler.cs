using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class levelHandler : MonoBehaviour {

	public AudioSource source;
	public GameObject[] GameplaySoundtracks;
	public static GameObject selectedSoundtrack;

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

    public int numberofCustomers;

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

    //background
    public string wall;
    public string floor;
    public string counters;
    public string furnace;

    //food lists
    Queue<customer> peasantQueue;
    public string peasantFoodList; //initalized with ";" as breakers. ex: "bread;carrot soup;grilled fish"
    public Queue<string> peasantFoodQueue;
    public string foodList;
    Dictionary<string, string[]> artisanFoodList;

    Dictionary<string, string[]> middleFoodList;

    public Queue<customer> customerQueue;

    public customer current_customer;

    Queue<customer> artisanQueue;
    Queue<customer> middleQueue;
    public int numArtisans = 0;
    public int numMiddle = 0;

    public struct customer
    {
        public string type;
        public Queue<string> foodQueue;

        public customer(string Type, Queue<string> FoodQueue)
        {
            type = Type;
            foodQueue = FoodQueue;
        }
    };

    public static string Multiply(string source, int multiplier) //multiply strings
    {
        StringBuilder sb = new StringBuilder(multiplier * source.Length);
        for (int i = 0; i < multiplier; i++)
        {
            sb.Append(source);
        }

        return sb.ToString();
    }


    Queue<customer> createPeasants(string[] food)
    {
        Queue<customer> peasants = new Queue<customer>();
        Queue<string> foodQueue;

        shuffle(food);
        foreach (string s in food)
        {
            //print("THIS IS S: " + s);
            foodQueue = new Queue<string>();
            foodQueue.Enqueue(s);
            peasants.Enqueue(new customer("peasant", foodQueue));
        }
        return peasants;
    }

    Queue<customer> createArtisans(Dictionary<string,string[]> food, int count)
    {
        Queue<customer> artisans = new Queue<customer>();
        Queue<string> tmp_foodQueue;
        int r;
        shuffle(food["drinks"]);
        shuffle(food["entrees"]);

        Queue<string> drinkQueue = new Queue<string>();
        Queue<string> entreeQueue = new Queue<string>();
        print("DRINK QUEUE:::::");
        foreach (string d in food["drinks"])
        {
            drinkQueue.Enqueue(d);
            Debug.Log(d);
        }
        print("ENTREE QUEUE:::::");
        foreach (string e in food["entrees"])
        {
            entreeQueue.Enqueue(e);
            Debug.Log(e);
        }
        Debug.Log("ARTISAN QUEUE:----");
        for (int i = 0; i < count; i++)
        {
            Debug.Log("ARTISAN " + i + " FOOD QUEUE:");
			int currentOrder = 0;
			int currentDrinks = 0;
			int currentFood = 0;
            tmp_foodQueue = new Queue<string>();
            
			while (currentOrder < 2) {
    	        r = Random.Range(0, 2);

                //Debug.Log("drink queue count: " + drinkQueue.Count);
                //Debug.Log("entree queue countL: " + entreeQueue.Count);
				if (r == 0 && drinkQueue.Count > entreeQueue.Count && currentDrinks < 2 && currentOrder < 2) { //add drink
					tmp_foodQueue.Enqueue(drinkQueue.Dequeue());
					currentDrinks++;
					currentOrder++;
				}
				else if (r == 1 && currentFood < 1 && currentOrder < 1) { //add food
					tmp_foodQueue.Enqueue(entreeQueue.Dequeue());
					currentFood++;
					currentOrder++;
				}
                /*
                else
                {
                    Debug.Log("something went wrong! currentOrder = " + currentOrder);
                    break;
                }
                */
                //Debug.Log(tmp_foodQueue.Peek());

			}

            /*
            r = Random.Range(0, 1);
            
            if (r == 0 && food ["drinks"].Length > food ["entrees"].Length && currentDrinks < 2) { //2 drinks
				foodQueue.Enqueue(food["drinks"][i]);
				foodQueue.Enqueue (food ["drinks"] [i]);
				currentDrinks = 2;
			}
            else if (r == 0) //drink first
            {
                foodQueue.Enqueue(food["drinks"][i]);
                foodQueue.Enqueue(food["entrees"][i]);
            }
            else if (r == 1) //entree first
            {
                foodQueue.Enqueue(food["entrees"][i]);
                foodQueue.Enqueue(food["drinks"][i]);
            }*/
            artisans.Enqueue(new customer("artisan", tmp_foodQueue));

        }
        
        return artisans;
    }

	Queue<customer> createMiddle(Dictionary<string,string[]> food, int count)
	{
		Queue<customer> middle = new Queue<customer>();
		Queue<string> tmp_foodQueue;
        string[] tmp_foodArray = new string[3];
		int r;

        Queue<string> drinkQueue = new Queue<string>();
        Queue<string> entreeQueue = new Queue<string>();
        Queue<string> sideQueue = new Queue<string>();
        foreach (string d in food["drinks"])
        {
            drinkQueue.Enqueue(d);
        }
        foreach (string e in food["entrees"])
        {
            entreeQueue.Enqueue(e);
        }
        foreach (string s in food["sides"])
        {
            sideQueue.Enqueue(s);
        }

        shuffle(food["drinks"]);
		shuffle(food["entrees"]);
		shuffle (food ["sides"]);
        for (int i = 0; i < count; i++)
        {
            tmp_foodQueue = new Queue<string>();

            bool orderComplete = false;
            while (!orderComplete)
            {
                r = Random.Range(0, 2);
                if (r == 0 && drinkQueue.Count >= 2 && drinkQueue.Count > entreeQueue.Count + sideQueue.Count)
                { //1 side and 2 drinks
                    tmp_foodArray[0] = drinkQueue.Dequeue();
                    tmp_foodArray[1] = drinkQueue.Dequeue();
                    tmp_foodArray[2] = sideQueue.Dequeue();
                    orderComplete = true;
                }
                else if (r == 1 && entreeQueue.Count > 0)
                { //1 drink 1 entree 1 side
                    tmp_foodArray[0] = drinkQueue.Dequeue();
                    tmp_foodArray[1] = entreeQueue.Dequeue();
                    tmp_foodArray[2] = sideQueue.Dequeue();
                    orderComplete = true;
                }
            }
            /*
            while (currentOrder < 3)
            {
                r = Random.Range(0, 3);
                //Debug.Log("drink queue count: " + drinkQueue.Count);
                //Debug.Log("entree queue countL: " + entreeQueue.Count);
                //Debug.Log("side queue countL: " + sideQueue.Count);
                if (r == 0 && currentDrinks < 2 && drinkQueue.Count > 0 && (drinkQueue.Count > entreeQueue.Count || drinkQueue.Count > sideQueue.Count))
                { //add drink
                    tmp_foodQueue.Enqueue(drinkQueue.Dequeue());
                    currentDrinks++;
                    currentOrder++;
                }
                else if (r == 1 && currentFood < 1 && currentDrinks < 2 && entreeQueue.Count > sideQueue.Count)
                { //add food
                    tmp_foodQueue.Enqueue(entreeQueue.Dequeue());
                    currentFood++;
                    currentOrder++;
                }
                else if (r == 2 && currentSide < 1)
                { //add side
                    tmp_foodQueue.Enqueue(sideQueue.Dequeue());
                    currentSide++;
                    currentOrder++;
                }

            }
            */
            shuffle(tmp_foodArray);
            print("FOOD QUEUE:::::::SADJKASKLD");
            foreach (string s in tmp_foodArray)
            {
                print(s);
                tmp_foodQueue.Enqueue(s);
            }
            middle.Enqueue(new customer("middle", tmp_foodQueue));
        }

		

		return middle;
	}

    void createCustomerQueue()
    {
        customer[] customerArray = new customer[numberofCustomers];
        int i = 0;
        foreach (customer c in peasantQueue)
        {
            customerArray[i] = c;
            i++;
        }
        if (numArtisans > 0)
        {
            foreach (customer c in artisanQueue)
            {
                customerArray[i] = c;
                i++;
            }
        }
        if (numMiddle > 0)
        {
            foreach (customer c in middleQueue)
            {
                customerArray[i] = c;
                i++;
            }
        }
        //foreach customer in artisanqueue...etc
        shuffle_customers(customerArray);

        foreach (customer c in customerArray)
        {
            print("customer type: " + c.type);
            foreach (string s in c.foodQueue)
            {
                print("i want: " + s);
            }
            customerQueue.Enqueue(c);
        }

        GameObject.Find("Customer").GetComponent<CustomerList>().customerQ = new Queue<customer>(customerQueue); //clunky fix for sprites
    }


    public int customersWaiting;
	public static int customersLeft;
	public static int totalCustomersInLevel;

    //time for level
    public float levelTime;

    void Awake()
    {
        customerList = new GameObject[5];
        emptyCustomers = new ArrayList();
        randomCustomerIndexes = new Queue<int>();
        customerQueue = new Queue<customer>();

        artisanFoodList = new Dictionary<string, string[]>();
        middleFoodList = new Dictionary<string, string[]>();
    }

    // Use this for initialization
    void Start () {
        customersServed = 0;
		customersLeft = 0;
		totalCustomersInLevel = 0;
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

        foodList = peasant;
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

            wall = "fancy";
            floor = "fancy";
            counters = "fancy";
            furnace = "fancy";

            numberofCustomers = 8;
            //foodList = Multiply("apple cider;", 4);
            

            artisanFoodList.Add("drinks", "apple cider;apple cider;apple cider;apple cider".Split(';'));
            artisanFoodList.Add("entrees", "grilled fish;grilled fish".Split(';'));

            numArtisans = 3;

            middleFoodList.Add("drinks", "apple cider;apple cider;apple cider;apple cider".Split(';'));
            middleFoodList.Add("entrees", "grilled fish;grilled fish".Split(';'));
            middleFoodList.Add("sides", "grilled carrot;grilled carrot;grilled carrot".Split(';'));

            numMiddle = 3;

            foodList = "apple cider;apple cider";
            //"grilledMeat;grilledMeat;bread;bread;bread;grilled fish;grilled fish;grilled fish";

            levelTime = 121;
			selectedSoundtrack = GameplaySoundtracks [2];

        }

        else if (PlayerPrefs.GetInt("level") == 1 && PlayerPrefs.GetString("tutorial") == "yes") //tutorial level (level one)
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 2;
            foodList = "grilledMeat;grilledMeat";

            levelTime = 60;
			//sharpening the knife
			selectedSoundtrack = GameplaySoundtracks [3];
			//GameObject.Find("MainMenuSoundtrack").SetActive(false);
			
        }



        else if (PlayerPrefs.GetInt("level") == 2) //level two
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 4;
            foodList = "grilledMeat;grilled fish;grilled fish;grilled fish";

            levelTime = 90;
			selectedSoundtrack = GameplaySoundtracks [1];

        }

        else if (PlayerPrefs.GetInt("level") == 3) //level three
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 6;
            foodList = "grilledMeat;grilledMeat;grilled fish;grilled fish;grilled fish;grilled fish";

            levelTime = 100;
			selectedSoundtrack = GameplaySoundtracks [1];
        }

        else if (PlayerPrefs.GetInt("level") == 4) //level four
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 8;
            foodList = "grilledMeat;grilledMeat;bread;bread;bread;grilled fish;grilled fish;grilled fish";

            levelTime = 121;
			selectedSoundtrack = GameplaySoundtracks [0];

        }

        else if (PlayerPrefs.GetInt("level") == 5) //level five
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 10;
            foodList = "grilledMeat;grilledMeat;bread;bread;bread;grilled fish;grilled fish;apple cider;apple cider;apple cider";

            levelTime = 121;
			selectedSoundtrack = GameplaySoundtracks [2];
        }

        else if (PlayerPrefs.GetInt("level") == 6) //level 6
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 11;
            foodList = "apple cider;bread;bread;bread;grilled fish;grilled fish;grilled fish;grilledMeat;grilledMeat;grilledMeat;grilledMeat";

            levelTime = 121;
            selectedSoundtrack = GameplaySoundtracks[2];
        }

        else if (PlayerPrefs.GetInt("level") == 7) //level 7
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 12;
            foodList = "apple cider;apple cider;bread;bread;bread;bread;bread;grilled fish;grilled fish;grilled fish;grilledMeat;grilledMeat";

            levelTime = 121;
            selectedSoundtrack = GameplaySoundtracks[2];
        }

        else if (PlayerPrefs.GetInt("level") == 8) //level eight
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 10;
            foodList = "grilledMeat;grilledMeat;bread;bread;apple cider;apple cider;apple cider;grilled onion;grilled onion;grilled onion";

            levelTime = 150;
			selectedSoundtrack = GameplaySoundtracks [2];

        }

        else if (PlayerPrefs.GetInt("level") == 9) //level nine
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

            wall = "cheap";
            floor = "cheap";
            counters = "cheap";
            furnace = "cheap";

            numberofCustomers = 12;
            foodList = "grilledMeat;grilledMeat;grilledMeat;bread;bread;bread;bread;apple cider;apple cider;grilled onion;grilled onion;grilled fish";
			selectedSoundtrack = GameplaySoundtracks [2];

            levelTime = 150;
        }

        else if (PlayerPrefs.GetInt("level") == 10) //level ten
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

            wall = "fancy";
            floor = "fancy";
            counters = "fancy";
            furnace = "fancy";

            numberofCustomers = 14;
            foodList = "bread;bread;apple cider;apple cider;grilledMeat;grilled carrot;grilled carrot;grilled carrot;grilled onion;grilled onion;grilled fish;grilled fish";
			selectedSoundtrack = GameplaySoundtracks [2];

            levelTime = 160;
        }

        else if (PlayerPrefs.GetInt("level") == 11) //level 11
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

            wall = "fancy";
            floor = "fancy";
            counters = "fancy";
            furnace = "fancy";

            numberofCustomers = 15;
            foodList = "apple cider;apple cider;apple cider;apple cider;bread;bread;bread;grilled carrot;grilled carrot;grilledMeat;grilledMeat;grilledMeat;grilled fish;grilled fish;grilled onion";
            selectedSoundtrack = GameplaySoundtracks[2];

            levelTime = 170;
        }

        else if (PlayerPrefs.GetInt("level") == 12) //level 12 (boss level)
        {
            maxGrillCount = 3;
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

            wall = "fancy";
            floor = "fancy";
            counters = "fancy";
            furnace = "fancy";

            numberofCustomers = 19;
            foodList = "apple cider;apple cider;apple cider;apple cider;apple cider;bread;bread;bread;grilled carrot;grilled carrot;grilled carrot;grilled onion;grilledMeat;grilledMeat;grilledMeat;grilled fish;grilled fish;grilled fish;grilled fish";
            selectedSoundtrack = GameplaySoundtracks[2];

            levelTime = 170;
        }

        else if (PlayerPrefs.GetInt("level") == 13) //level 13 NOT IMPLEMENTED YET
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

            wall = "fancy";
            floor = "fancy";
            counters = "fancy";
            furnace = "fancy";

            numberofCustomers = 20;
            foodList = "apple cider;apple cider;apple cider;apple cider;bread;bread;bread;grilled carrot;grilled carrot;grilled onion;grilled onion;grilled onion;grilledMeat;grilledMeat;grilledMeat;grilled fish;grilled fish;grilled fish;grilled fish;grilled fish";
            selectedSoundtrack = GameplaySoundtracks[2];

            levelTime = 180;
        }

        else if (PlayerPrefs.GetInt("level") == 14) //level 14
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

            wall = "fancy";
            floor = "fancy";
            counters = "fancy";
            furnace = "fancy";

            numberofCustomers = 21;
            foodList = "apple cider;apple cider;apple cider;apple cider;apple cider;bread;bread;bread;bread;grilled carrot;grilled onion;grilled onion;grilled onion;grilled onion;grilledMeat;grilledMeat;grilledMeat;grilledMeat;grilled fish;grilled fish;grilled fish;grilled fish";
            selectedSoundtrack = GameplaySoundtracks[2];

            levelTime = 180;
        }

        else if (PlayerPrefs.GetInt("level") == 15) //level 15
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
            grapeOn = true;
            honeyOn = false;
            sauceOn = false;

            wall = "fancy";
            floor = "fancy";
            counters = "fancy";
            furnace = "fancy";

            numberofCustomers = 24;
            foodList = "wine;wine;wine;wine;apple cider;apple cider;apple cider;apple cider;grilledMeat;grilledMeat;grilledMeat;grilledMeat;grilled fish;grilled fish;grilled fish;grilled fish;grilled fish;bread;bread;bread;grilled carrot;grilled carrot;grilled carrot";
            
            selectedSoundtrack = GameplaySoundtracks[2];

            levelTime = 180;
        }
        
        peasantQueue = createPeasants(foodList.Split(';'));
        if (numArtisans > 0)
        {
            artisanQueue = createArtisans(artisanFoodList, numArtisans);
        }
        if (numMiddle > 0)
        {
            middleQueue = createMiddle(middleFoodList, numMiddle);
        }
        createCustomerQueue();

        string[] peasantFoodShuffle = foodList.Split(';');
        shuffle(peasantFoodShuffle);
        foreach (string food in peasantFoodShuffle)
        {
            peasantFoodQueue.Enqueue(food);
        }
        PlayerPrefs.SetInt("tempCustomer", peasantFoodQueue.Count);
        customersWaiting = customerQueue.Count;
		totalCustomersInLevel = numberofCustomers;
		customersLeft = customersWaiting;

        //max - how many cooking objects you have (to iterate later)
        grillCount = 4 - maxGrillCount;
        ovenCount = 4 - maxOvenCount;
        stoveCount = 4 - maxStoveCount;
        warmingPlateCount = 4 - maxWarmingPlateCount;
        //Debug.Log("warming plate count: " + warmingPlateCount);
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

        GameObject _wall = GameObject.Find("wall");
        GameObject _floor = GameObject.Find("floor");
        GameObject _counters = GameObject.Find("counters");
        GameObject _furnace = GameObject.Find("furnace_front");

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


        //set bg - Guideline for child BG gameObjects:
        //           0 = cheap, 1 = fancy

        //WALLS
        if (wall == "cheap")
            _wall.transform.GetChild(0).gameObject.SetActive(true);
        
        else if (wall == "fancy")
            _wall.transform.GetChild(1).gameObject.SetActive(true);
        //

        //COUNTERS
        if (counters == "cheap")
            _counters.transform.GetChild(0).gameObject.SetActive(true);

        else if (counters == "fancy")
            _counters.transform.GetChild(1).gameObject.SetActive(true);
        //

        //FLOOR
        if (floor == "cheap")
            _floor.transform.GetChild(0).gameObject.SetActive(true);
        
        else if (floor == "fancy")
            _floor.transform.GetChild(1).gameObject.SetActive(true);
        //

        //FURNACE
        if (furnace == "cheap")
            _furnace.transform.GetChild(0).gameObject.SetActive(true);

        else if (furnace == "fancy")
            _furnace.transform.GetChild(1).gameObject.SetActive(true);
        //

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
            if (customersServed == customersWaiting || customersLeft == 0)//peasantFoodQueue.Count <= 0 && checkifNoCustomers())
            {
                finished = true;
                CloseSignAnim.close_child = 1;
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
		text = string.Format(customersLeft.ToString());
        if (AndroidViewPort.default_ratio)
            GUI.Label(new Rect(8, Screen.height / 28, 100, 100), text, textStyle);
        else
            GUI.Label(new Rect(8, 0, 100, 100), text, textStyle);
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

    public GameObject Spawn(string customerName, CustomerAI cAI)
    {
        //ArrayList emptyCustomers = getEmptyCustomerIndexes();

        //int i = randomCustomerIndexes.Dequeue();

        current_customer = cAI.customer;
        print("FOOD QUEUE:::::" + cAI.customer.foodQueue.Count);
        GameObject tempcustomer = Resources.Load("Customers/Peasants/customer") as GameObject;

        if (current_customer.type == "peasant")
        {
            print("foodqueue: " + current_customer.foodQueue.Count);
            tempcustomer.GetComponent<Customer>().foodQueue = current_customer.foodQueue;
            //tempcustomer.GetComponent<Customer>().current_food = findRecipe(current_customer.foodQueue.Dequeue());
        }

        else if (current_customer.type == "artisan")
        {
            print("foodqueue: " + current_customer.foodQueue.Count);
            tempcustomer.GetComponent<Customer>().foodQueue = current_customer.foodQueue;
            //tempcustomer.GetComponent<Customer>().current_food = findRecipe(current_customer.foodQueue.Dequeue());
        }


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

    void shuffle_customers(customer[] c)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < c.Length; t++)
        {
            customer tmp = c[t];
            int r = Random.Range(t, c.Length);
            c[t] = c[r];
            c[r] = tmp;
        }
    }

    //Added By JiMMY 2016-04-14
    public void DequeueCustomerQ()
    {
        if (customerQueue.Count > 1)
            customerQueue.Dequeue();
    }



}

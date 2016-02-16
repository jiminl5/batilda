using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelHandler : MonoBehaviour {

	public AudioSource source;
	public GameObject[] GameplaySoundtracks;

    public GameObject c1;
    public GameObject c2;

    public bool waitingForC1 = false;
    public bool waitingForC2 = false;

    GameObject _c1;
    GameObject _c2;

    public ArrayList customerList;

    public bool finished = false;
    private string text;
    private int customersServed;
    private static Random rng = new Random();


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

    //time for level
    public float levelTime;

    void Awake()
    {
        customerList = new ArrayList();
    }

    // Use this for initialization
    void Start () {
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

            peasantFoodList = "apple cider;apple cider;apple cider";
                //"grilledMeat;grilledMeat;bread;bread;bread;grilled fish;grilled fish;grilled fish";

            levelTime = 120;
			GameplaySoundtracks[1].SetActive(true);
        }

        if (PlayerPrefs.GetInt("level") == 1) //tutorial level (level one)
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

        GameObject cuttingBoard = GameObject.Find("cuttingBoard");
        GameObject rollingPin = GameObject.Find("rollingPin");

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

        if (!rollingPinOn)
            rollingPin.SetActive(false);
        if (!cuttingBoardOn)
            cuttingBoard.SetActive(false);


        //set level time
        GameObject.Find("Main Camera").GetComponent<StopWatch>().startTime = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (!finished)
        {
            finished = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StopWatch>().finished;
            //print(peasantFoodQueue.Count);
            if ((!waitingForC1 || !waitingForC2) && peasantFoodQueue.Count > 0)
            {
                int spawnTime = Random.Range(5, 10);
                //Debug.Log ("THIS IS RANDOM RANGE::::: " + spawnTime);
                Invoke("Spawn", spawnTime);
            }
            else
            {
                {
                    if (!_c1 && waitingForC1)
                    {
                        customersServed++;
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;

                        //Link to Result page 2016-02-01
                        PlayerPrefs.SetInt("temp_coin", customersServed);

                        waitingForC1 = false;
                    }
                    if (!_c2 && waitingForC2)
                    {
                        customersServed++;
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;

                        //Link to Result page 2016-02-01
                        PlayerPrefs.SetInt("temp_coin", customersServed);

                        waitingForC2 = false;
                    }
                }
            }
            //Debug.Log(peasantFoodQueue.Count);
            //Debug.Log(!waitingForC1);
            //Debug.Log(!waitingForC2);
            if (peasantFoodQueue.Count <= 0 && !waitingForC1 && !waitingForC2)
            {
                finished = true;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StopWatch>().finished = true;
            }
        }

    }

    void OnGUI()
    {
		GUIStyle textStyle = new GUIStyle ();
		textStyle.fontSize = Screen.width/25;
		textStyle.normal.textColor = Color.white;
        text = string.Format(customersServed.ToString());
        GUI.Label(new Rect(5, 5, 100, 100), text, textStyle);
    }

    void Spawn()
    {
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
        }
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

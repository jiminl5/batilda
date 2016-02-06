using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelHandler : MonoBehaviour {

    public GameObject c1;
    public GameObject c2;

    public bool waitingForC1 = false;
    public bool waitingForC2 = false;

    GameObject _c1;
    GameObject _c2;

    public bool finished = false;
    private string text;
    private int customersServed;
    private static Random rng = new Random();


    //cooking objects
    public int maxGrillCount;
    public int maxOvenCount;
    public int maxStoveCount;

    public int grillCount;
    public int ovenCount;
    public int stoveCount;
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

        if (PlayerPrefs.GetInt("level") == 0) //tutorial level
        {
            maxGrillCount = 1;
            maxOvenCount = 0;
            maxStoveCount = 0;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;

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
            //PlayerPrefs.SetString("peasantFoodList", "grilledMeat;grilledMeat");
        }



            if (PlayerPrefs.GetInt("level") == 1) //level one
        {
            maxGrillCount = 1;
            maxOvenCount = 0;
            maxStoveCount = 0;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;

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
            //PlayerPrefs.SetString("peasantFoodList", "grilledMeat;grilledMeat");
            //Debug.Log(peasantFoodQueue.Count);
        }

        if (PlayerPrefs.GetInt("level") == 1) //level one
        {
            maxGrillCount = 1;
            maxOvenCount = 0;
            maxStoveCount = 0;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;

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

            peasantFoodList = "grilledMeat;grilledMeat";
            //PlayerPrefs.SetString("peasantFoodList", "grilledMeat;grilledMeat");
            //Debug.Log(peasantFoodQueue.Count);
        }

        if (PlayerPrefs.GetInt("level") == 2) //level two
        {
            maxGrillCount = 2;
            maxOvenCount = 1;
            maxStoveCount = 0;
            if (grillCount > maxGrillCount)
                grillCount = 1;
            if (ovenCount > maxOvenCount)
                ovenCount = 0;
            if (stoveCount > maxStoveCount)
                stoveCount = 0;

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

            peasantFoodList = "grilledMeat;grilledMeat;bread;grilled fish";
            //PlayerPrefs.SetString("peasantFoodList", "grilledMeat;grilledMeat");
            //Debug.Log(peasantFoodQueue.Count);
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
        //find stuff
        GameObject grills = GameObject.Find("grills");
        GameObject ovens = GameObject.Find("ovens");
        GameObject stoves = GameObject.Find("stoves");
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
            if (grillCount <= 0)
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
            if (ovenCount <= 0)
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
            if (stoveCount <= 0)
            {
                break;
            }
            grillCount -= 1;
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

    }

    // Update is called once per frame
    void Update()
    {
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

        text = string.Format("Customers served: " + customersServed);
        GUI.Label(new Rect(300, 275, 100, 100), text);


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

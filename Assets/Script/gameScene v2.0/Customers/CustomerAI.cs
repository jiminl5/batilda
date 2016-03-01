using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerAI : MonoBehaviour
{

    public Transform[] path = new Transform[6];
    int start_path = 0;

    public float walk_acc;

    public int direction = 0;

    bool pick_number;

    private static bool seat_taken_1;
    private static bool seat_taken_2;
    private static bool seat_taken_3;
    private static bool seat_taken_4;
    private static bool seat_taken_5;

    int check = 0;

    float timer;

    public static bool customerSat1;
    public static bool customerSat2;
    public static bool customerSat3;
    public static bool customerSat4;
    public static bool customerSat5;


    GameObject order;

    public static int seatCount = 0;

    float order_delay;

    public Customer customerAI;
    bool customerExit;
    bool customerConfirmedExit;

    private int customerSpotCount_1 = 0;
    private int customerSpotCount_2 = 0;
    private int customerSpotCount_3 = 0;
    private int customerSpotCount_4 = 0;
    private int customerSpotCount_5 = 0;

    private bool pickStart = false;
    private float temp_wait;
    public static string cus_Number;
    // Use this for initialization
    void Start()
    {
        order_delay = 2.0f;

        temp_wait = 0.0f;

        /*
        customerSat1 = false;
        customerSat2 = false;
        customerSat3 = false;
        customerSat4 = false;
        customerSat5 = false;
        */
        path[0] = GameObject.Find("CustomerPath_1").transform;
        path[1] = GameObject.Find("CustomerPath_2").transform;
        path[2] = GameObject.Find("CustomerPath_3").transform;
        path[3] = GameObject.Find("CustomerPath_4").transform;
        path[4] = GameObject.Find("CustomerPath_5").transform;
        path[5] = GameObject.Find("CustomerPath_6").transform;
        path[6] = GameObject.Find("CustomerExit").transform;

        customerExit = false;
        //order = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (seatCount <= 5)
        {
            walk();
        }

        if (pick_number)
        {
            if (PlayerPrefs.GetString("tutorial") == "yes")
                check = 3;
            else
                check = Random.Range(1, 6);
            if (!checkTaken(check))
            {
                direction = check;
                //seatTaken(direction);
                pick_number = false;
            }
        }
        if (customerConfirmedExit && customerExit)
        {
            if (check == 1)
                seat_taken_1 = false;
            if (check == 2)
                seat_taken_2 = false;
            if (check == 3)
                seat_taken_3 = false;
            if (check == 4)
                seat_taken_4 = false;
            if (check == 5)
                seat_taken_5 = false;
            seatCount--;
            Destroy(this.gameObject);
        }

        if (pickStart)
        {
            temp_wait += Time.deltaTime;
            if (temp_wait >= 3.0f)
            {
                pick_number = true;
                temp_wait = 0.0f;
                pickStart = false;
            }
        }
    }

    public void confirmExit(bool confirm)
    {
        customerConfirmedExit = confirm;
    }

    void walk()
    {
        float speed = walk_acc * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, path[direction].position, speed);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "WayPointStart" && direction != 6)
        {
            if (PlayerPrefs.GetString("tutorial") == "yes")
                pick_number = true;
            else
                pickStart = true;
        }

        if (coll.tag == "WayPoint1" && direction == 1)
        {
            customerSat1 = true;
            seat_taken_1 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_1");
            //seatCount++;
        }

        else if (coll.tag == "WayPoint2" && direction == 2)
        {
            customerSat2 = true;
            seat_taken_2 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_2");
            //seatCount++;
        }
        else if (coll.tag == "WayPoint3" && direction == 3)
        {
            customerSat3 = true;
            seat_taken_3 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_3");
            //seatCount++;
        }
        else if (coll.tag == "WayPoint4" && direction == 4)
        {
            customerSat4 = true;
            seat_taken_4 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_4");
            //seatCount++;
        }
        else if (coll.tag == "WayPoint5" && direction == 5)
        {
            customerSat5 = true;
            seat_taken_5 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_5");
            //seatCount++;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "WayPointExit" && direction == 6)
        {
            customerExit = true;
        }
    }

    void GiveOrderDelay()
    {
        if (customerSat1 && direction == 1)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_1");
        }
        if (customerSat2 && direction == 2)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_2");
        }
        if (customerSat3 && direction == 3)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_3");
        }
        if (customerSat4 && direction == 4)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_4");
        }
        if (customerSat5 && direction == 5)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_5");
        }

        if (order)
        {
            order.transform.SetParent(this.transform);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "WayPoint1" && check == 1)
        {
            customerSat1 = false;
            //seat_taken_1 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++; //Data Handler
            //seatCount--;
            customerSpotCount_1--;
        }

        if (coll.tag == "WayPoint2" && check == 2)
        {
            customerSat2 = false;
            //seat_taken_2 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            //seatCount--;
            customerSpotCount_2--;
        }
        if (coll.tag == "WayPoint3" && check == 3)
        {
            customerSat3 = false;
            //seat_taken_3 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            //seatCount--;
            customerSpotCount_3--;
        }
        if (coll.tag == "WayPoint4" && check == 4)
        {
            customerSat4 = false;
            //seat_taken_4 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            //seatCount--;
            customerSpotCount_4--;
        }
        if (coll.tag == "WayPoint5" && check == 5)
        {
            customerSat5 = false;
            //seat_taken_5 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            //seatCount--;
            customerSpotCount_5--;
        }
    }

    bool checkTaken(int check)
    {
        if (check == 1)
        {
            return seat_taken_1;
        }
        else if (check == 2)
        {
            return seat_taken_2;
        }
        else if (check == 3)
        {
            return seat_taken_3;
        }
        else if (check == 4)
        {
            return seat_taken_4;
        }
        else if (check == 5)
        {
            return seat_taken_5;
        }
        else
            return true;
    }
}

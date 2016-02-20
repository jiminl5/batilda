using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerAI : MonoBehaviour {

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

    public float order_delay;
    // Use this for initialization
    void Start () {
        customerSat1 = false;
        customerSat2 = false;
        customerSat3 = false;
        customerSat4 = false;
        customerSat5 = false;

        path[0] = GameObject.Find("CustomerPath_1").transform;
        path[1] = GameObject.Find("CustomerPath_2").transform;
        path[2] = GameObject.Find("CustomerPath_3").transform;
        path[3] = GameObject.Find("CustomerPath_4").transform;
        path[4] = GameObject.Find("CustomerPath_5").transform;
        path[5] = GameObject.Find("CustomerPath_6").transform;
        path[6] = GameObject.Find("CustomerExit").transform;

        //order = new GameObject();
    }
	
	// Update is called once per frame
	void Update () {
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
                seatTaken(direction);
                pick_number = false;
            }
        }
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
            pick_number = true;
        }

        if (coll.tag == "WayPoint1" && direction == 1)
        {
            customerSat1 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_1");
            //seatCount++;
        }

        if (coll.tag == "WayPoint2" && direction == 2)
        {
            customerSat2 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_2");
            //seatCount++;
        }
        if (coll.tag == "WayPoint3" && direction == 3)
        {
            customerSat3 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_3");
            //seatCount++;
        }
        if (coll.tag == "WayPoint4" && direction == 4)
        {
            customerSat4 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_4");
            //seatCount++;
        }
        if (coll.tag == "WayPoint5" && direction == 5)
        {
            customerSat5 = true;
            Invoke("GiveOrderDelay", order_delay);
            //order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_5");
            //seatCount++;
        }
        /*
        if (order)
        {
            order.transform.SetParent(this.transform);
        }
        */
        if (coll.tag == "WayPointExit" && direction == 6)
        {
            Destroy(this.gameObject);
        }
    }

    void GiveOrderDelay()
    {
        if (customerSat1)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_1");
            seatCount++;
        }
        else if (customerSat2)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_2");
            seatCount++;
        }
        else if (customerSat3)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_3");
            seatCount++;
        }
        else if (customerSat4)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_4");
            seatCount++;
        }
        else if (customerSat5)
        {
            order = GameObject.Find("levelHandler").GetComponent<levelHandler>().Spawn("cus_5");
            seatCount++;
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
            seat_taken_1 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++; //Data Handler
            seatCount--;
        }

        if (coll.tag == "WayPoint2" && check == 2)
        {
            customerSat2 = false;
            seat_taken_2 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            seatCount--;
        }
        if (coll.tag == "WayPoint3" && check == 3)
        {
            customerSat3 = false;
            seat_taken_3 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            seatCount--;
        }
        if (coll.tag == "WayPoint4" && check == 4)
        {
            customerSat4 = false;
            seat_taken_4 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            seatCount--;
        }
        if (coll.tag == "WayPoint5" && check == 5)
        {
            customerSat5 = false;
            seat_taken_5 = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<coinHandler>().Coins++;
            seatCount--;
        }
    }
    
    bool checkTaken(int check)
    {
        if (check == 1)
        {
            print(seat_taken_1);
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

    public static void seatTaken(int check)
    {
        if (check == 1)
        {
            seat_taken_1 = true;
        }
        else if (check == 2)
        {
            seat_taken_2 = true;
        }
        else if (check == 3)
        {
            seat_taken_3 = true;
        }
        else if (check == 4)
        {
            seat_taken_4 = true;
        }
        else if (check == 5)
        {
            seat_taken_5 = true;
        }
    }
}

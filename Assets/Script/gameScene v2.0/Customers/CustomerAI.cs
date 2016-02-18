using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerAI : MonoBehaviour {

    public Transform[] path = new Transform[6];
    int start_path = 0;

    public float walk_acc;

    int direction = 0;

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
    }
	
	// Update is called once per frame
	void Update () {
        if (CustomerList.customer_Q.Count <= 4)
        {
                walk();
        }

        if (pick_number)
        {
            check = Random.Range(1, 5);
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
        if (coll.tag == "WayPointStart")
        {
            pick_number = true;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "WayPoint1" && direction == 1)
        {
            customerSat1 = true;
        }
        
        if (coll.tag == "WayPoint2" && direction == 2)
        {
            customerSat2 = true;
        }
        if (coll.tag == "WayPoint3" && direction == 3)
        {
            customerSat3 = true;
        }
        if (coll.tag == "WayPoint4" && direction == 4)
        {
            customerSat4 = true;
        }
        if (coll.tag == "WayPoint5" && direction == 5)
        {
            customerSat5 = true;
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
            return false;
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerList : MonoBehaviour {

    public GameObject[] customers = new GameObject[1];

    private GameObject peasant;
    private float _delay;

    bool keep_track; // true when all seats (5) are taken, false if less

    public static List<GameObject> customer_Q = new List<GameObject>();
	// Use this for initialization
	void Start () {
        keep_track = false;
        customer_Q.Clear();
        peasant = customers[0]; // ADD more later
        if (PlayerPrefs.GetString("tutorial") == "yes")
        {
            Instantiate(peasant, new Vector2(GameObject.Find("CustomerPath_1").transform.position.x, GameObject.Find("CustomerPath_1").transform.position.y), Quaternion.identity);
            customer_Q.Add(peasant);
            _delay = 15;
            CustomerEnterDelay();
        }
        else
        {
            _delay = Random.Range(2, 3);
            CustomerEnterDelay();
        }
       //Instantiate(peasant, new Vector2(this.transform.position.x, this.transform.position.y),Quaternion.identity);
	}

    void CustomerEnterDelay()
    {
        Invoke("CreateCustomer", _delay);
        _delay = Random.Range(8, 10);
    }

    void CreateCustomer()
    {
        if ((customer_Q.Count < GameObject.Find("levelHandler").GetComponent<levelHandler>().customersWaiting) && CustomerAI.seatCount < 5) // # of Seats
        {
            Instantiate(peasant, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            customer_Q.Add(peasant);
            CustomerEnterDelay();
        }
        if (CustomerAI.seatCount == 5)
        {
            keep_track = true;
        }
    }

    void Update()
    {
        if (keep_track)
        {
            CustomerEnterDelay();
            keep_track = false;
        }
    }
}

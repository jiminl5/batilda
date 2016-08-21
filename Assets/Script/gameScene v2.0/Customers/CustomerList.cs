using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerList : MonoBehaviour {

    public GameObject[] customers = new GameObject[2];
	public GameObject[] peasants;

    private GameObject peasant;
    private GameObject artisan;
    private GameObject middle;
    private GameObject noble;
    private float _delay;

    public Queue<levelHandler.customer> customerQ;


    bool keep_track; // true when all seats (5) are taken, false if less

    public static List<GameObject> customer_Q = new List<GameObject>();
	// Use this for initialization
	void Start () {
      
        keep_track = false;
        customer_Q.Clear();
        peasant = customers[0]; // ADD more later
        artisan = customers[1];
        middle = customers[2];
        noble = customers[3];
        if (PlayerPrefs.GetString("tutorial") == "yes")
        {
            GameObject current_customer = new GameObject();
            CustomerAI.seatCount++;
            current_customer = Instantiate(peasant, new Vector2(GameObject.Find("CustomerPath_1").transform.position.x, GameObject.Find("CustomerPath_1").transform.position.y), Quaternion.identity) as GameObject;
            customer_Q.Add(peasant);
            _delay = 15;
            current_customer.GetComponent<CustomerAI>().customer = customerQ.Dequeue();
            CustomerEnterDelay();
            //current_customer.GetComponent<CustomerAI>().customer = customerQ.Dequeue();
        }
        else
        {
            _delay = Random.Range(2, 3);
            Invoke("CreateCustomer", _delay);
        }
        //Instantiate(peasant, new Vector2(this.transform.position.x, this.transform.position.y),Quaternion.identity);
    }

    void CustomerEnterDelay()
    {
        //_delay = Random.Range(8, 10);
        Invoke("CreateCustomer", _delay);
    }

    void CreateCustomer()
    {
        GameObject current_customer = new GameObject();
        if ((customer_Q.Count < GameObject.Find("levelHandler").GetComponent<levelHandler>().customersWaiting) && CustomerAI.seatCount < 5) // # of Seats
        {
            CustomerAI.seatCount++;
            
            
            print("TYPE::::::::::::::::::::" + customerQ.Peek().type);
            if (customerQ.Peek().type == "peasant")
            {
				GameObject newpeasant = peasants[Random.Range(0,2)];
                current_customer = Instantiate(newpeasant, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
                customer_Q.Add(newpeasant);
            }
            else if (customerQ.Peek().type == "artisan")
            {
                current_customer = Instantiate(artisan, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
                customer_Q.Add(artisan);
            }
            else if (customerQ.Peek().type == "middle")
            {
                current_customer = Instantiate(middle, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
                customer_Q.Add(middle);
            }
            
            else if (customerQ.Peek().type == "noble")
            {
                current_customer = Instantiate(noble, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity) as GameObject;
                customer_Q.Add(noble);
            }
            current_customer.GetComponent<CustomerAI>().customer = customerQ.Dequeue();
            //---------------
            _delay = Random.Range(6, 8);
            if (CustomerAI.seatCount != 5)
            {
                CustomerEnterDelay();
            }
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
            if (CustomerAI.seatCount <= 4)
            {
                _delay = Random.Range(6, 8);
                CustomerEnterDelay();
                keep_track = false;
            }
        }
    }
}

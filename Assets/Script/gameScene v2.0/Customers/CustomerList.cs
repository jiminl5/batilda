using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerList : MonoBehaviour {

    public GameObject[] customers = new GameObject[1];

    private GameObject peasant;
    private float _delay;

    public static Queue<GameObject> customer_Q = new Queue<GameObject>();
	// Use this for initialization
	void Start () {
        _delay = Random.Range(2,3);
        peasant = customers[0]; // ADD more later

        CustomerEnterDelay();
       //Instantiate(peasant, new Vector2(this.transform.position.x, this.transform.position.y),Quaternion.identity);
	}
	
    void CustomerEnterDelay()
    {
        Invoke("CreateCustomer", _delay);
        _delay = Random.Range(10, 15);
    }

    void CreateCustomer()
    {
        if (customer_Q.Count < 5) // # of Seats
        {
            Instantiate(peasant, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            customer_Q.Enqueue(peasant);
            CustomerEnterDelay();
        }
    }

}

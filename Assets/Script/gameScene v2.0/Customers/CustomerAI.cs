using UnityEngine;
using System.Collections;

public class CustomerAI : MonoBehaviour {

    public Transform[] path = new Transform[3];
    int start_path = 0;

    public float walk_acc;

    int direction = 0;

	// Use this for initialization
	void Start () {
        path[0] = GameObject.Find("CustomerPath_1").transform;
        path[1] = GameObject.Find("CustomerPath_2").transform;
        path[2] = GameObject.Find("CustomerPath_3").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (direction == 3)
        {
        }
        else
        {
            walk();
        }
	}

    void walk()
    {
        float speed = walk_acc * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, path[direction].position, speed);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "WayPoint")
            direction++;
    }
}

using UnityEngine;
using System.Collections;

public class CustomerAI : MonoBehaviour {

    public Transform[] path = new Transform[3];
    int start_path = 0;

    public float walk_acc = 1.8f;

	// Use this for initialization
	void Start () {
        path[0] = GameObject.Find("CustomerPath_1").transform;
        path[1] = GameObject.Find("CustomerPath_2").transform;
        path[2] = GameObject.Find("CustomerPath_3").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (start_path == 3)
        {
            Destroy(this.gameObject);
        }
        else
        {
            walk();
        }
	}

    void walk()
    {
        Vector2 direction = path[start_path].position - transform.position;
        float speed = Vector2.Dot(direction.normalized, transform.forward);
        float walk_speed = walk_acc * speed;
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "WayPoint")
            start_path++;
    }
}

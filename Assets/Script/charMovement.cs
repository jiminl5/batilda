using UnityEngine;
using System.Collections;

public class charMovement : MonoBehaviour {

	public bool move = false;

	Vector3 wayPointDirection;

	public Transform[] wayPoint = new Transform[10];
	int tmp_wayPoint = 1;
	int currentWayPoint;

	//Character
	float accelerate;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (move) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, wayPoint [currentWayPoint].transform.position, accelerate);
			if (this.transform.position == wayPoint[currentWayPoint].transform.position)
				currentWayPoint = 0;
		}

		if (this.transform.position == wayPoint[0].transform.position)
			move = false;

		//print (move);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "WayPoint")
			move = false;
	}

	void OnGUI()
	{
		float but = wayPoint [1].parent.transform.position.x;
		float button_x = wayPoint [1].transform.position.x;
		float button_y = wayPoint [1].transform.position.y;
		if (GUI.Button(new Rect(button_x + 170, button_y + 40, 40, 40), "1"))
		{
			move = true;
			currentWayPoint = 1;
			accelerate = 0.1f;
			print (but);
		}
		if (GUI.Button(new Rect(button_x + 170, button_y + 160, 40, 40), "2"))
		{
			move = true;
			currentWayPoint = 2;
			accelerate = 0.12f;
		}
		if (GUI.Button(new Rect(button_x + 170, button_y + 280, 40, 40), "3"))
		{
			move = true;
			currentWayPoint = 3;
			accelerate = 0.14f;
		}
	}
}

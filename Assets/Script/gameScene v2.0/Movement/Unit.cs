using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap map;

	float speed = 5f;
    float timeLeft = 10f;

	int tmp;

	//List
	public List<Node> currentPath = null;
    public static List<Node> temp_list = null;

    static int tmp_count;

    //public static bool mouseClicked = false;

    public GameObject g_object;

	public static Queue<List<Node>> unit_queue = new Queue<List<Node>>();

	void Start()
	{
        //temp_list = new List<Node>();
        g_object = GameObject.Find("Unit");
	}

	public void Update()
	{
		if (currentPath != null && unit_queue.Count != 0){//mouseClicked) {
            //temp_list = currentPath;
			//this.gameObject.GetComponentInChildren<Chef>().atPosition = false;
			MoveNextTile();
		}
	}

	public void QueueAction(List<Node> queue_list)
	{
		//Queue Action
		unit_queue.Enqueue (queue_list);
	}

    //Move to nextTile
	public void MoveNextTile()
	{
		//print ("HI: " + unit_queue.Count);
		this.gameObject.GetComponentInChildren<Chef>().atPosition = false;
        List<Node> temp_path = new List<Node>();
		temp_path = unit_queue.Peek ();//temp_list;
		if (currentPath == null && temp_path == null) {
			print ("null");
			return;
		}
		if (unit_queue.Count != 0){//mouseClicked){
            tileX = temp_path[1].x;
            tileY = temp_path[1].y;
            float real_tileX = tileX + (tileX * 0.5f);
            float real_tileY = tileY;

            //print("tileX: " + real_tileX + ", tileY: " + real_tileY);
            Vector2 currentWayPoint = new Vector2(real_tileX, real_tileY);
	        //transform.position = new Vector2(temp_path[0].x, temp_path[0].y);
	        //grab next first node and move
            if (g_object.transform.position.x != currentWayPoint.x || g_object.transform.position.y != currentWayPoint.y)
            {
                g_object.transform.position = Vector2.MoveTowards(g_object.transform.position, currentWayPoint, Time.deltaTime * speed); // move toward not lerp
            }
			if (g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y)
			{
				//temp_path.RemoveAt(0);
				unit_queue.Peek().RemoveAt(0);
			}
			if (temp_path.Count == 1)
			{
				this.gameObject.GetComponentInChildren<Chef>().atPosition = true;
				print("Succesfully at destination");
				unit_queue.Dequeue();
				if (unit_queue.Count == 0)
				{
					//mouseClicked = false;
					unit_queue.Clear();
				}
			}

		}
		
    }

}

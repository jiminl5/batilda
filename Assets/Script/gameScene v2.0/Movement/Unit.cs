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

	private int _chef_animState = Animator.StringToHash("chef_animState");
	private Animator _animator;

	public string left_right;
	public string down_up;

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
				//MOVEMENT ANIMATION && First movement
				if (g_object.transform.position.x > currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y) //LEFT
				{
					_animator.SetInteger(_chef_animState, 1);
					left_right = "left";
				}
				if (g_object.transform.position.x < currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y) //RIGHT
				{
					_animator.SetInteger(_chef_animState, 2);
					left_right = "right";
				}
				if (g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y > currentWayPoint.y) //DOWN
				{
					_animator.SetInteger(_chef_animState, 3);
					down_up = "down";
				}
				if (g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y < currentWayPoint.y) //UP
				{
					_animator.SetInteger(_chef_animState, 4);
					down_up = "up";
				}
				
				// 2 - Way Direction //for tenth digit 1: left first, 2: right first, 3: down first, 4: up first
				if (left_right.Equals("left") && g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y > currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 11); // left then down
				else if (left_right.Equals("left") && g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y < currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 12); // left then up
				else if (left_right.Equals("right") && g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y > currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 21); // right then down
				else if (left_right.Equals("right") && g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y < currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 22); // right then up
				
				if (down_up.Equals("down") && g_object.transform.position.x > currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 31); // Down then left
				else if (down_up.Equals("down") && g_object.transform.position.x < currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 32); // Down then right
				else if (down_up.Equals("up") && g_object.transform.position.x > currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 41);
				else if (down_up.Equals("up") && g_object.transform.position.x < currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_chef_animState, 42);















				//MOVE
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

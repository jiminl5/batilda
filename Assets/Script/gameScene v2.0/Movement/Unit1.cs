using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit1 : MonoBehaviour {

	public int tileX;
	public int tileY;
	public TileMap1 map;

	float speed = 5f;
    float timeLeft = 10f;

	int tmp;

	private int _bat_animState = Animator.StringToHash("bat_animState");
	private Animator _animator;

	public string left_right;
	public string down_up;

	//List
	public List<Node> currentPath = null;
    public static List<Node> temp_list2 = null;

    //public static bool mouseClicked = false;

    public GameObject g_object1;

    public static Queue<List<Node>> unit_queue1 = new Queue<List<Node>>();

    void Start()
	{
        //temp_list2 = new List<Node>();
        g_object1 = GameObject.Find("Unit1");
		_animator = this.GetComponentInChildren<Animator> ();
	}

	public void Update()
	{
		if (currentPath != null && unit_queue1.Count != 0) {
			MoveNextTile();
		}
	}

    public void QueueAction(List<Node> queue_list1, bool check)
    {
        if (!check)
        {
            unit_queue1.Enqueue(queue_list1);
        }
        else if (check)
        {
            queue_list1.RemoveRange(0, queue_list1.Count - 2);
            unit_queue1.Enqueue(queue_list1);
        }
    }

    //Move to nextTile
	public void MoveNextTile()//List<Node> temp_list)
	{
		this.gameObject.GetComponentInChildren<Waitress>().atPosition = false;
        List<Node> temp_path = new List<Node>();
        temp_path = unit_queue1.Peek();
		if (currentPath == null && temp_path == null) {
			print ("null");
			return;
		}
		if (unit_queue1.Count != 0){
            tileX = temp_path[1].x;
            tileY = temp_path[1].y;
            float real_tileX = tileX + (tileX * 0.5f);
            float real_tileY = tileY;

            //print("tileX: " + real_tileX + ", tileY: " + real_tileY);
            Vector2 currentWayPoint = new Vector2(real_tileX, real_tileY);
	        //transform.position = new Vector2(temp_path[0].x, temp_path[0].y);
	        //grab next first node and move
			if (g_object1.transform.position.x != currentWayPoint.x || g_object1.transform.position.y != currentWayPoint.y)
            {
				//MOVEMENT ANIMATION && First movement
				if (g_object1.transform.position.x > currentWayPoint.x && g_object1.transform.position.y == currentWayPoint.y) //LEFT
				{
					_animator.SetInteger(_bat_animState, 1);
					left_right = "left";
				}
				if (g_object1.transform.position.x < currentWayPoint.x && g_object1.transform.position.y == currentWayPoint.y) //RIGHT
				{
					_animator.SetInteger(_bat_animState, 2);
					left_right = "right";
				}
				if (g_object1.transform.position.x == currentWayPoint.x && g_object1.transform.position.y > currentWayPoint.y) //DOWN
				{
					_animator.SetInteger(_bat_animState, 3);
					down_up = "down";
				}
				if (g_object1.transform.position.x == currentWayPoint.x && g_object1.transform.position.y < currentWayPoint.y) //UP
				{
					_animator.SetInteger(_bat_animState, 4);
					down_up = "up";
				}

				// 2 - Way Direction //for tenth digit 1: left first, 2: right first, 3: down first, 4: up first
				if (left_right.Equals("left") && g_object1.transform.position.x == currentWayPoint.x && g_object1.transform.position.y > currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 11); // left then down
				else if (left_right.Equals("left") && g_object1.transform.position.x == currentWayPoint.x && g_object1.transform.position.y < currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 12); // left then up
				else if (left_right.Equals("right") && g_object1.transform.position.x == currentWayPoint.x && g_object1.transform.position.y > currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 21); // right then down
				else if (left_right.Equals("right") && g_object1.transform.position.x == currentWayPoint.x && g_object1.transform.position.y < currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 22); // right then up

				if (down_up.Equals("down") && g_object1.transform.position.x > currentWayPoint.x && g_object1.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 31); // Down then left
				else if (down_up.Equals("down") && g_object1.transform.position.x < currentWayPoint.x && g_object1.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 32); // Down then right
				else if (down_up.Equals("up") && g_object1.transform.position.x > currentWayPoint.x && g_object1.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 41);
				else if (down_up.Equals("up") && g_object1.transform.position.x < currentWayPoint.x && g_object1.transform.position.y == currentWayPoint.y)
					_animator.SetInteger(_bat_animState, 42);


				//MOVE
                g_object1.transform.position = Vector2.MoveTowards(g_object1.transform.position, currentWayPoint, Time.deltaTime * speed); // move toward not lerp
            }
			if (g_object1.transform.position.x == currentWayPoint.x && g_object1.transform.position.y == currentWayPoint.y)
			{
                unit_queue1.Peek().RemoveAt(0);
			}
			if (temp_path.Count == 1)
			{
				this.gameObject.GetComponentInChildren<Waitress>().atPosition = true;
				left_right = ""; // Make direction empty
				down_up = "";
				print("Succesfully at destination");
				_animator.SetInteger(_bat_animState, 0);
                //mouseClicked = false;
                unit_queue1.Dequeue();
                if (unit_queue1.Count == 0)
                {
                    unit_queue1.Clear();
                }
			}

		}
		
    }

}

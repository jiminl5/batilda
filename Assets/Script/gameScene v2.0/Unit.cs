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

    public static bool mouseClicked = false;

    GameObject g_object;

	void Start()
	{
        temp_list = new List<Node>();
        g_object = GameObject.Find("Unit");
	}

	public void Update()
	{
		if (currentPath != null && mouseClicked) {
			int currNode = 0;

			while(currNode < currentPath.Count - 1)
			{
				Vector2 start = map.TileToWorld( currentPath[currNode].x, currentPath[currNode].y);
				Vector2 end = map.TileToWorld( currentPath[currNode + 1].x, currentPath[currNode + 1].y);

				Debug.DrawLine(start, end, Color.cyan); // track path

				currNode++;
			}
            temp_list = currentPath;
			MoveNextTile();
		}
	}
    //Move to nextTile
	public void MoveNextTile()//List<Node> temp_list)
	{
        List<Node> temp_path = new List<Node>();
        temp_path = temp_list;
		if (currentPath == null && temp_path == null) {
			print ("null");
			return;
		}
		if (mouseClicked){
            tileX = temp_path[1].x;
            tileY = temp_path[1].y;
            float real_tileX = tileX + (tileX * 0.5f);
            float real_tileY = tileY;

            print("tileX: " + real_tileX + ", tileY: " + real_tileY);
            Vector2 currentWayPoint = new Vector2(real_tileX, real_tileY);
	        //transform.position = new Vector2(temp_path[0].x, temp_path[0].y);
	        //grab next first node and move
            if (g_object.transform.position.x != currentWayPoint.x || g_object.transform.position.y != currentWayPoint.y)
            {
                g_object.transform.position = Vector2.MoveTowards(g_object.transform.position, currentWayPoint, Time.deltaTime * speed); // move toward not lerp
            }
			if (g_object.transform.position.x == currentWayPoint.x && g_object.transform.position.y == currentWayPoint.y)
			{
				temp_path.RemoveAt(0);
			}
			if (temp_path.Count == 1)
			{
				print("Succesfully at destination");
				mouseClicked = false;
			}

		}
		
    }

}

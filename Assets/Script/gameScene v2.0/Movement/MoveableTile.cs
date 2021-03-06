﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveableTile : MonoBehaviour {

	public int mtX = 0;
	public int mtY = 0;
	public TileMap map;
	public TileMap1 map1;

	public GameObject[] plates; // Maximum Length 4
	public GameObject[] food_plates;
	GameObject[] blk_tile;
	GameObject[] red_tile;

    public GameObject check;
    public static Queue<GameObject> check_Queue = new Queue<GameObject>(); //Foxanna
    public static Queue<GameObject> check_Queue_1 = new Queue<GameObject>(); //Batilda

    private float tempy;

    private bool clickable = true;

    //Used for speech coordinates
    public int tempy_x; 
    public int tempy_y; 

	void Awake()
	{
		Setup_Tile ();
	}
	
	public void Setup_Tile()
	{
		blk_tile = GameObject.FindGameObjectsWithTag("tile_blk");
		red_tile = GameObject.FindGameObjectsWithTag("tile_red");
		//if (plates == null) {
			plates = GameObject.FindGameObjectsWithTag("empty_plate");
		//}
		//if (food_plates == null) 
		//{
			food_plates = GameObject.FindGameObjectsWithTag("not_empty_plate");
		//}
		
		ResetMidTiles ();
		//plates.
	}

	public void ResetMidTiles()
	{
		for (int i = 0; i < red_tile.Length; i++) {
			red_tile[i].GetComponent<BoxCollider2D>().enabled = true;

            // Disable Unecessary tiles ----------------
            if (red_tile[i].transform.position.y >= 8)
                Destroy(red_tile[i]);
            //red_tile[i].SetActive(false);
            else if (red_tile[i].transform.position.x == 7.5f && red_tile[i].transform.position.y <= 2) // DISABLE MID RED TILE
                Destroy(red_tile[i]);
            //red_tile[i].SetActive(false);
            else if ((red_tile[i].transform.position.x > 7.5f && red_tile[i].transform.position.x < 15f)
                        && !(red_tile[i].transform.position.y <= 2 || red_tile[i].transform.position.y == 6
                         || red_tile[i].transform.position.y == 7))
                Destroy(red_tile[i]);
            else if (red_tile[i].transform.position.x == 15f && red_tile[i].transform.position.y == 3)
                Destroy(red_tile[i]);
            //red_tile[i].SetActive(false);
        }
        for (int j = 0; j < blk_tile.Length; j++) {
			blk_tile[j].GetComponent<BoxCollider2D>().enabled = true;

            // Disable Unecessary tiles ----------------
            if (blk_tile[j].transform.position.y >= 8)
                Destroy(blk_tile[j]);
            // blk_tile[j].SetActive(false);
            else if (blk_tile[j].transform.position.y == 7 && blk_tile[j].transform.position.x == 0)
                Destroy(blk_tile[j]);
            //blk_tile[j].SetActive(false);
            else if ((blk_tile[j].transform.position.x > 0 && blk_tile[j].transform.position.x < 7.5f)
                     && (blk_tile[j].transform.position.y > 0 && blk_tile[j].transform.position.y < 6)
                     && !((blk_tile[j].transform.position.y == 4 && blk_tile[j].transform.position.x == 3)
                     || (blk_tile[j].transform.position.y == 4 && blk_tile[j].transform.position.x == 4.5f)
                     || (blk_tile[j].transform.position.y == 3 && blk_tile[j].transform.position.x == 3f)
                     || (blk_tile[j].transform.position.y == 3 && blk_tile[j].transform.position.x == 4.5f)))
                Destroy(blk_tile[j]);
            // blk_tile[j].SetActive(false);
        }
		MidTileMoveable ();
	}

	void MidTileMoveable()
	{
		for (int i = 0; i < plates.Length; i++) {
			for (int j = 0; j < red_tile.Length; j++)
			{
				if (red_tile[j].transform.position.x == 7.5 && red_tile[j].transform.position.y == plates[i].transform.position.y) //check if those tiles are same as plates with specific tag
					red_tile[j].GetComponent<BoxCollider2D>().enabled = false;
			}
		}
		for (int x = 0; x < food_plates.Length; x++) {
			for (int y = 0; y < blk_tile.Length; y++)
			{
				if (blk_tile[y].transform.position.x == 7.5 && blk_tile[y].transform.position.y == food_plates[x].transform.position.y)
					blk_tile[y].GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
	
    public void RemoveAllTileColliders()
    {
        foreach(Transform child in GameObject.Find("Tiles").transform)
        {
            child.GetComponent<BoxCollider2D>().enabled = false;
        }
        /*
        if (red_tile.Length > 0 && blk_tile.Length > 0)
        {
            for (int j = 0; j < red_tile.Length; j++)
            {
                red_tile[j].GetComponent<BoxCollider2D>().enabled = false;
            }

            for (int y = 0; y < blk_tile.Length; y++)
            {
                blk_tile[y].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        */
    }

    void GenerateCheckmark(int x, int y) //Foxanna
    {
        float newX = x * 0.5f;
        GameObject tmp_check = (GameObject)Instantiate(check, new Vector2((float)x + newX, (float)y + 0.5f), Quaternion.identity);
        check_Queue.Enqueue(tmp_check);
    }

    void GenerateCheckmark_1(int x, int y) //Batilda
    {
        float newX = x * 0.5f;
        GameObject tmp_check_1 = (GameObject)Instantiate(check, new Vector2((float)x + newX, (float)y + 0.5f), Quaternion.identity);
        check_Queue_1.Enqueue(tmp_check_1);
    }

    void preventSpam()
    {
        clickable = true;
    }

    void OnMouseDown()
    {
        DoAction();
    }

    public void SpeechBubDown(int temp_x, int temp_y) // when speech bubble is touched
    {
        tempy_x = temp_x;
        tempy_y = temp_y;
        DoSpeechAction();
    }

    void DoSpeechAction()
    {
        if (tempy_x == 10)
        {
            if (tempy_y <= 2) //corner
            {
                tempy_y = 2;
                map1.GeneratePathTo(tempy_x - 1, tempy_y + 1);
            }
            else
                map1.GeneratePathTo(tempy_x - 1, tempy_y);
        }
        else if (tempy_y <= 2)
        {
            tempy_y = 2;
            if (tempy_x == 5)
                map1.GeneratePathTo(tempy_x + 1, tempy_y + 1); // Corner
            else
                map1.GeneratePathTo(tempy_x, tempy_y + 1);
        }
        GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = tempy_x;
        GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = tempy_y;
        if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null
        || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null))
        {
            Waitress.obj_queue1.Enqueue(GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition());
            GenerateCheckmark_1(tempy_x, tempy_y);
        }
        else if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null
        || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null))
        {
            Waitress.obj_queue1.Enqueue(GameObject.Find("Null_Object"));
            check_Queue_1.Enqueue(GameObject.Find("Null_Object"));
        }
    }

    void DoAction()
    {
        //CHEF
        //print("mtX: " + mtX + ", mtY: " + mtY);
        if (clickable && (Unit.unit_queue.Count <= 10 && Chef.obj_queue.Count <= 10) && (Unit1.unit_queue1.Count <= 10 && Waitress.obj_queue1.Count <= 10)
        && check_Queue.Count <= 10 && check_Queue_1.Count <= 10)
        {
            clickable = false;
            Invoke("preventSpam", 0.15f);
            if (mtX < 5)
            {
                // left shelf
                if (mtX == 0 && (mtY >= 0 && mtY <= 6))
                {
                    if (mtY == 0) // Trash , left-bottom corner
                        map.GeneratePathTo(mtX + 1, mtY + 1);
                    else if (mtY == 6) // Pot(?), left-top corner
                        map.GeneratePathTo(mtX + 1, mtY - 1);
                    else
                        map.GeneratePathTo(mtX + 1, mtY);
                }
                // bottom shelf
                else if (mtY == 0 && (mtX >= 1 && mtX <= 4))
                {
                    map.GeneratePathTo(mtX, mtY + 1);
                }
                // top shelf --------OVENS
                else if ((mtY == 6 || mtY == 7) && (mtX >= 1 && mtX < 5))
                {
                    if (mtY == 7 && (mtX == 1 || mtX == 2))
                    {
                        map.GeneratePathTo(mtX, mtY - 2);
                    }
                    else if (mtY == 7 && (mtX == 3 || mtX == 4))
                    {
                        mtY -= 1;
                        map.GeneratePathTo(mtX, mtY - 1);
                    }
                    else
                    {
                        map.GeneratePathTo(mtX, mtY - 1);
                    }
                }
                else if (mtY >= 3 && mtX == 2) // Grill
                {
                    map.GeneratePathTo(mtX - 1, mtY);
                }
                else if (mtY >= 3 && mtX == 3) // Grill
                {
                    map.GeneratePathTo(mtX + 1, mtY);
                }
                //Chef.clicked = true;
                GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtX;
                GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mtY;
                //QUEUE ACTION
                if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null
                || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null))
                {
                    Chef.obj_queue.Enqueue(GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition());
                    GenerateCheckmark(mtX, mtY);
                }
                else if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null
                || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null))
                {
                    Chef.obj_queue.Enqueue(GameObject.Find("Null_Object"));
                    check_Queue.Enqueue(GameObject.Find("Null_Object"));
                }
            }
            else if (mtX == 5 && mtY >= 0 && mtY <= 6)
            {
                if (map != null && (mtY == 6 || mtY == 0))
                {
                    if (mtY == 6)
                        map.GeneratePathTo(4, mtY - 1);
                    else if (mtY == 0)
                        map.GeneratePathTo(4, mtY + 1);
                    //Chef.clicked = true;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtX;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mtY;
                    if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null
                    || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null))
                    {
                        Chef.obj_queue.Enqueue(GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition());
                        GenerateCheckmark(mtX, mtY);
                    }
                    else if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null
                    || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null))
                    {
                        Chef.obj_queue.Enqueue(GameObject.Find("Null_Object"));
                        check_Queue.Enqueue(GameObject.Find("Null_Object"));
                    }
                }
                else if (map != null)
                {
                    map.GeneratePathTo(4, mtY);
                    //Chef.clicked = true;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtX;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mtY;
                    if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null
                    || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null))
                    {
                        Chef.obj_queue.Enqueue(GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition());
                        GenerateCheckmark(mtX, mtY);
                    }
                    else if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null
                    || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null))
                    {
                        Chef.obj_queue.Enqueue(GameObject.Find("Null_Object"));
                        check_Queue.Enqueue(GameObject.Find("Null_Object"));
                    }
                }
                if (map1 != null && mtY == 6)
                {
                    map1.GeneratePathTo(6, mtY - 1);
                    //Unit1.mouseClicked = true;
                    //Waitress.clicked = true;
                    GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtX;
                    GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mtY;
                    if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null
                    || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null))
                    {
                        Waitress.obj_queue1.Enqueue(GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition());
                        GenerateCheckmark_1(mtX, mtY);
                    }
                    else if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null
                    || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null))
                    {
                        Waitress.obj_queue1.Enqueue(GameObject.Find("Null_Object"));
                        check_Queue_1.Enqueue(GameObject.Find("Null_Object"));
                    }
                }
                else if (map1 != null)
                {
                    map1.GeneratePathTo(6, mtY);
                    //Unit1.mouseClicked = true;
                    //Waitress.clicked = true;
                    GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtX;
                    GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mtY;
                    if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null
                    || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null))
                    {
                        Waitress.obj_queue1.Enqueue(GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition());
                        GenerateCheckmark_1(mtX, mtY);
                    }
                    else if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null
                    || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null))
                    {
                        Waitress.obj_queue1.Enqueue(GameObject.Find("Null_Object"));
                        check_Queue_1.Enqueue(GameObject.Find("Null_Object"));
                    }
                }
            }
            // Waitress
            else if (mtX > 5 && mtY >= 0 && mtY < 8)
            {
                // Top Shelf
                if (mtY >= 6)
                {
                    if (mtY == 7)
                        mtY -= 1;
                    if (mtX == 5) //left corner
                        map1.GeneratePathTo(mtX + 1, mtY - 1);
                    else if (mtX == 10) // right corner
                        map1.GeneratePathTo(mtX - 1, mtY - 1);
                    else
                        map1.GeneratePathTo(mtX, mtY - 1);
                    //Unit1.mouseClicked = true;
                }
                // Right Shelf
                else if (mtX == 10)
                {
                    if (mtY <= 2) //corner
                    {
                        mtY = 2;
                        map1.GeneratePathTo(mtX - 1, mtY + 1);
                    }
                    else
                        map1.GeneratePathTo(mtX - 1, mtY);
                    //Unit1.mouseClicked = true;
                }
                // Bottom Shelf
                else if (mtY <= 2)
                {
                    mtY = 2;
                    if (mtX == 5)
                        map1.GeneratePathTo(mtX + 1, mtY + 1); // Corner
                    else
                        map1.GeneratePathTo(mtX, mtY + 1);
                    //Unit1.mouseClicked = true;
                }
                //Waitress.clicked = true;
                GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtX;
                GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mtY;
                if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null
                || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null))
                {
                    Waitress.obj_queue1.Enqueue(GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition());
                    GenerateCheckmark_1(mtX, mtY);
                }
                else if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null
                || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null))
                {
                    Waitress.obj_queue1.Enqueue(GameObject.Find("Null_Object"));
                    check_Queue_1.Enqueue(GameObject.Find("Null_Object"));
                }
            }

        }
        else
            print("TOO MANY TASKS!!!!!");
    }
}

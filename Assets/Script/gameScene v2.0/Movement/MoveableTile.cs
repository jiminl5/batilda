using UnityEngine;
using System.Collections;

public class MoveableTile : MonoBehaviour {

	public int mtX = 0;
	public int mtY = 0;
	public TileMap map;
	public TileMap1 map1;

	public GameObject[] plates; // Maximum Length 4
	public GameObject[] food_plates;
	GameObject[] blk_tile;
	GameObject[] red_tile;

	bool chef_move;

	void Start()
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
		}
		for (int j = 0; j < blk_tile.Length; j++) {
			blk_tile[j].GetComponent<BoxCollider2D>().enabled = true;

			// Disable Unecessary tiles
			if (blk_tile[j].transform.position.y >= 7)
				blk_tile[j].SetActive(false);
			else if ((blk_tile[j].transform.position.x > 0 && blk_tile[j].transform.position.x < 7.5f)
			         && (blk_tile[j].transform.position.y > 0 && blk_tile[j].transform.position.y < 6)
			         && !(blk_tile[j].transform.position.y == 4 && blk_tile[j].transform.position.x == 3))
				blk_tile[j].SetActive(false);
		}
		MidTileMoveable ();
	}

	void MidTileMoveable()
	{
		for (int i = 0; i < plates.Length; i++) {
			for (int j = 0; j < red_tile.Length; j++)
			{
				if (red_tile[j].transform.position.x == 7.5 && red_tile[j].transform.position.y == plates[i].transform.position.y) //check if those tiles are same as plates with specific tag
				//	red_tile[j].SetActive(false);
					red_tile[j].GetComponent<BoxCollider2D>().enabled = false;
			}
		}
		for (int x = 0; x < food_plates.Length; x++) {
			for (int y = 0; y < blk_tile.Length; y++)
			{
				if (blk_tile[y].transform.position.x == 7.5 && blk_tile[y].transform.position.y == food_plates[x].transform.position.y)
				//	blk_tile[y].SetActive(false);
					blk_tile[y].GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
	
	void OnMouseDown()
	{
		//CHEF
		print ("mtX: " + mtX + ", mtY: " + mtY);
		//GameObject.FindGameObjectWithTag ("Player").GetComponent<Chef> ().atPosition = false;
		if (Unit.unit_queue.Count <= 20) {
			if (mtX < 5) {
                // left shelf
                if (mtX == 0 && (mtY >= 0 && mtY <= 6))
                {
                    if (mtY == 0) // Trash , left-bottom corner
                        map.GeneratePathTo(mtX + 1, mtY + 1);
                    else if (mtY == 6) // Pot(?), left-top corner
                        map.GeneratePathTo(mtX + 1, mtY - 1);
                    else
                        map.GeneratePathTo(mtX + 1, mtY);
                    //Unit.mouseClicked = true; // Trigger movement
                }
                // bottom shelf
                else if (mtY == 0 && (mtX >= 1 && mtX <= 4))
                {
                    map.GeneratePathTo(mtX, mtY + 1);
                    //Unit.mouseClicked = true; // Trigger movement
                }
                // top shelf
                else if (mtY == 6 && (mtX >= 1 && mtX < 5))
                {
                    //				if (mtX == 5)
                    //					map.GeneratePathTo (mtX - 1, mtY - 1);
                    //				else
                    map.GeneratePathTo(mtX, mtY - 1);
                    //Unit.mouseClicked = true; // Trigger movement
                }
                else if (mtY == 4 && mtX == 2) // BREAD TABLE
                {
                    map.GeneratePathTo(mtX - 1, mtY);
                }
				//Chef.clicked = true;
				GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().mtX = mtX;
				GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().mtY = mtY;
				//QUEUE ACTION
				if (GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition () != null)
					Chef.obj_queue.Enqueue(GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition ());
				else if (GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition () == null)
					Chef.obj_queue.Enqueue(GameObject.Find("Null_Object"));
			}
			else if (mtX == 5 && mtY >= 3 && mtY <= 6) {
                if (map != null && mtY == 6)
                {
                    map.GeneratePathTo(4, mtY - 1);
                    //Chef.clicked = true;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtX;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mtY;
					if (GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition () != null)
						Chef.obj_queue.Enqueue(GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition ());
					else if (GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition () == null)
						Chef.obj_queue.Enqueue(GameObject.Find("Null_Object"));
                }
                else if (map != null)
                {
                    map.GeneratePathTo(4, mtY);
                    //Chef.clicked = true;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtX;
                    GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mtY;
					if (GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition () != null)
						Chef.obj_queue.Enqueue(GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition ());
					else if (GameObject.FindGameObjectWithTag ("Chef").GetComponent<Chef> ().findGameObjectAtClickedPosition () == null)
						Chef.obj_queue.Enqueue(GameObject.Find("Null_Object"));
                }
				if (map1 != null && mtY == 6)
				{
					map1.GeneratePathTo(6, mtY - 1);
					Unit1.mouseClicked = true;
					Waitress.clicked = true;
					GameObject.FindGameObjectWithTag ("Waitress").GetComponent<Waitress> ().mtX = mtX;
					GameObject.FindGameObjectWithTag ("Waitress").GetComponent<Waitress> ().mtY = mtY;
				}
                else if (map1 != null)
                {
                    map1.GeneratePathTo(6, mtY);
                    Unit1.mouseClicked = true;
                    Waitress.clicked = true;
                    GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtX;
                    GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mtY;
                }
			}
			// Waitress
			else if (mtX > 5 && mtY > 1 && mtY < 7) {
				// Top Shelf
				if (mtY == 6) {
					if (mtX == 5) //left corner
						map1.GeneratePathTo (mtX + 1, mtY - 1);
					else if (mtX == 10) // right corner
						map1.GeneratePathTo (mtX - 1, mtY - 1);
					else
						map1.GeneratePathTo (mtX, mtY - 1);
					Unit1.mouseClicked = true;
				}
				// Right Shelf
				else if (mtX == 10) {
					if (mtY == 2) //corner
						map1.GeneratePathTo (mtX - 1, mtY + 1);
					else
						map1.GeneratePathTo (mtX - 1, mtY);
					Unit1.mouseClicked = true;
				}
				// Bottom Shelf
				else if (mtY == 2) {
					if (mtX == 5)
						map1.GeneratePathTo (mtX + 1, mtY + 1); // Corner
					else
						map1.GeneratePathTo (mtX, mtY + 1);
					Unit1.mouseClicked = true;
				}
				Waitress.clicked = true;
				GameObject.FindGameObjectWithTag ("Waitress").GetComponent<Waitress> ().mtX = mtX;
				GameObject.FindGameObjectWithTag ("Waitress").GetComponent<Waitress> ().mtY = mtY;
				// Left Shelf -- MID TILE
				//			else if (mtX == 5)
				//			{
				//				map1.GeneratePathTo(mtX + 1, mtY);
				//				Unit1.mouseClicked = true;
				//			}
			}

		} 
		else
			print ("TOO MANY TASKS!!!!!");
	}
}

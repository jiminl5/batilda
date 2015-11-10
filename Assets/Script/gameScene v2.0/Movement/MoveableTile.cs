using UnityEngine;
using System.Collections;

public class MoveableTile : MonoBehaviour {

	public int mtX = 0;
	public int mtY = 0;
	public TileMap map;
	public TileMap1 map1;

	GameObject[] plates; // Maximum Length 4
	GameObject[] food_plates;
	GameObject[] blk_tile;
	GameObject[] red_tile;

	bool chef_move;

	void Start()
	{
		blk_tile = GameObject.FindGameObjectsWithTag("tile_blk");
		red_tile = GameObject.FindGameObjectsWithTag("tile_red");
		if (plates == null) {
			plates = GameObject.FindGameObjectsWithTag("empty_plate");
		}
		if (food_plates == null) 
		{
			food_plates = GameObject.FindGameObjectsWithTag("not_empty_plate");
		}
	}

	void Update()
	{
		for (int i = 0; i < plates.Length; i++) {
			for (int j = 0; j < red_tile.Length; j++)
			{
				if (red_tile[j].transform.position.x == 7.5 && red_tile[j].transform.position.y == plates[i].transform.position.y)
					red_tile[j].SetActive(false);
			}
		}
		for (int x = 0; x < food_plates.Length; x++) {
			for (int y = 0; y < blk_tile.Length; y++)
			{
				if (blk_tile[y].transform.position.x == 7.5 && blk_tile[y].transform.position.y == food_plates[x].transform.position.y)
					blk_tile[y].SetActive(false);
			}
		}
	}
	
	void OnMouseUp()
	{
		//CHEF
		print ("mtX: " + mtX + ", mtY: " + mtY);
		//GameObject.FindGameObjectWithTag ("Player").GetComponent<Chef> ().atPosition = false;
		if (mtX < 5) {
			// left shelf
			if (mtX == 0 && (mtY >= 0 && mtY <= 6)) {
				if (mtY == 0) // Trash , left-bottom corner
					map.GeneratePathTo (mtX + 1, mtY + 1);
				else if (mtY == 6) // Pot(?), left-top corner
					map.GeneratePathTo (mtX + 1, mtY - 1);
				else
					map.GeneratePathTo (mtX + 1, mtY);	
				Unit.mouseClicked = true; // Trigger movement
			}
			// bottom shelf
			else if (mtY == 0 && (mtX >= 1 && mtX <= 4)) {
				map.GeneratePathTo (mtX, mtY + 1);
				Unit.mouseClicked = true; // Trigger movement
			}
			// top shelf
			else if (mtY == 6 && (mtX >= 1 && mtX < 5)) {
//				if (mtX == 5)
//					map.GeneratePathTo (mtX - 1, mtY - 1);
//				else
				map.GeneratePathTo (mtX, mtY - 1);
				Unit.mouseClicked = true; // Trigger movement
			}

			Chef.clicked = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Chef> ().mtX = mtX;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Chef> ().mtY = mtY;
		} 
		else if (mtX == 5 && mtY >= 3 && mtY <= 6) {
			for (int l = 0; l < plates.Length; l++)
			{
				if (plates[l].transform.position.y == mtY && mtY == 6)
				{
					map.GeneratePathTo(4, 5);
					Unit.mouseClicked = true;
				}
				else if (plates[l].transform.position.y == mtY)
				{
					map.GeneratePathTo(4,mtY);
					Unit.mouseClicked = true;
				}
			}
			for (int m = 0; m < food_plates.Length; m++)
			{
				if (food_plates[m].transform.position.y == mtY)
				{
					map1.GeneratePathTo(6, mtY);
					Unit1.mouseClicked = true;
				}
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
			// Left Shelf -- MID TILE
//			else if (mtX == 5)
//			{
//				map1.GeneratePathTo(mtX + 1, mtY);
//				Unit1.mouseClicked = true;
//			}
		}
	}
}

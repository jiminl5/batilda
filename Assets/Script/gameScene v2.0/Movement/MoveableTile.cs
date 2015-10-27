using UnityEngine;
using System.Collections;

public class MoveableTile : MonoBehaviour {

	public int mtX = 0;
	public int mtY = 0;
	public TileMap map;
	public TileMap1 map1;

	void OnMouseDown()
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
			else if (mtY == 6 && (mtX >= 1 && mtX <= 5)) {
				if (mtX == 5)
					map.GeneratePathTo (mtX - 1, mtY - 1);
				else
					map.GeneratePathTo (mtX, mtY - 1);
				Unit.mouseClicked = true; // Trigger movement
			}
			Chef.clicked = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Chef> ().mtX = mtX;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Chef> ().mtY = mtY;

		}
		// Waitress
		else if (mtX >= 5 && mtY > 1 && mtY < 7) {
			// Top Shelf
			if (mtY == 6)
			{
				if (mtX == 5) //left corner
					map1.GeneratePathTo(mtX + 1, mtY - 1);
				else if (mtX == 10) // right corner
					map1.GeneratePathTo(mtX - 1, mtY - 1);
				else
					map1.GeneratePathTo(mtX, mtY - 1);
				Unit1.mouseClicked = true;
			}
			// Right Shelf
			else if (mtX == 10)
			{
				if (mtY == 2) //corner
					map1.GeneratePathTo(mtX - 1, mtY + 1);
				else
					map1.GeneratePathTo(mtX - 1, mtY);
				Unit1.mouseClicked = true;
			}
			// Bottom Shelf
			else if (mtY == 2)
			{
				if (mtX == 5)
					map1.GeneratePathTo(mtX + 1, mtY + 1); // Corner
				else
					map1.GeneratePathTo(mtX, mtY + 1);
				Unit1.mouseClicked = true;
			}
			// Left Shelf
			else if (mtX == 5)
			{
				map1.GeneratePathTo(mtX + 1, mtY);
				Unit1.mouseClicked = true;
			}
		}
	}
}

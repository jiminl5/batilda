using UnityEngine;
using System.Collections;

public class MoveableTile : MonoBehaviour {

	public int mtX = 0;
	public int mtY = 0;
	public TileMap map;

    public Unit _unit;

	void OnMouseDown()
	{
		//CHEF
		print ("mtX: " + mtX + ", mtY: " + mtY);
		// left shelf
		if (mtX == 0 && (mtY >= 0 && mtY <= 6)) {
			if (mtY == 0) // Trash , left-bottom corner
				map.GeneratePathTo (mtX + 1, mtY + 1);
			else if (mtY == 6) // Pot(?), left-top corner
				map.GeneratePathTo (mtX + 1, mtY - 1);
			else
				map.GeneratePathTo (mtX + 1, mtY);
			Unit.mouseClicked = true;
		}
		// bottom shelf
		else if (mtY == 0 && (mtX >= 1 && mtX <= 4)) {
			map.GeneratePathTo (mtX, mtY + 1);
			Unit.mouseClicked = true;
		}
		// top shelf
		else if (mtY == 6 && (mtX >= 1 && mtX <= 5)) {
			if (mtX == 5)
				map.GeneratePathTo (mtX - 1, mtY - 1);
			else
				map.GeneratePathTo (mtX, mtY - 1);
			Unit.mouseClicked = true;
		}
	}
}

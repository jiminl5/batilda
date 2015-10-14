using UnityEngine;
using System.Collections;

public class MoveableTile : MonoBehaviour {

	public int mtX = 0;
	public int mtY = 0;
	public TileMap map;

    public Unit _unit;

	void OnMouseDown()
	{
		map.GeneratePathTo (mtX, mtY);
        Unit.mouseClicked = true;
	}
}

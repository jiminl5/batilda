using UnityEngine;
using System.Collections;

[System.Serializable] // make this class editable (using public) in Unity Editor
public class TileType { // Raw c# class not monobehaviour

	public string name; // table, kitchen, bar, etc.
	public GameObject tileVisualPrefab;

	public float movementCost = 1f;
	public bool walkable = true;
}

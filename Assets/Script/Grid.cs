using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public LayerMask unwalkableMask; // unwalkable mask
	public Vector2 gridWorldSize; // area grid is going to cover
	public float nodeRadius; // define how much space each individual node covers
	Node[,] grid; // 2-dimensional array of nodes

	float nodeDiameter;
	int gridSizeX, gridSizeY;

	void Start()
	{
		nodeDiameter = nodeRadius * 2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter); // gives how many nodes we can fit in to the world size
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

		CreateGrid();
	}

	void CreateGrid()
	{
		grid = new Node[gridSizeX, gridSizeY];

		Vector2 _thisPosition = transform.position;
		//_thisPosition.z = 0;

		Vector2 worldBottomLeft = _thisPosition - Vector2.right * gridWorldSize.x / 2 - Vector2.up * gridWorldSize.y / 2; // bottom left corners

		for (int x = 0; x < gridSizeX; x++) {
			for (int y = 0; y < gridSizeY; y++)
			{
				Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask)); // check if there is collision, if there is collision set walkable opposite of that
				grid[x,y] = new Node(walkable, worldPoint);
			}
		}
	}

	void OnDrawGizmos(){ // Gizmos Method
		Gizmos.DrawWireCube(transform.position, new Vector2(gridWorldSize.x, gridWorldSize.y)); // walkable Gizmo

		if (grid != null) {
			foreach (Node n in grid){
				Gizmos.color = (n.walkable)?Color.white:Color.red; // if walkable then color white, if not then color red
				Gizmos.DrawCube(n.worldPosition, Vector2.one * (nodeDiameter - .1f));
			}
		}
	}
}

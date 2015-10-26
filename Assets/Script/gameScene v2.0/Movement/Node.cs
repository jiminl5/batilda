using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node{
	public List<Node> neighbours;
	public int x;
	public int y;
	
	public Node() // Default Constructor
	{
		neighbours = new List<Node>();
	}
	
	public float DistanceTo(Node n) // Returns distance between 2 nodes
	{
		return Vector2.Distance (
			new Vector2(x,y),
			new Vector2(n.x, n.y)
			);
	}
}

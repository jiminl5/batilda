using UnityEngine;
using System.Collections;
// Added Libraries
using System.Collections.Generic; // list
using System.Linq; // OrderBy

public class TileMap1 : MonoBehaviour {

	//public GameObject selectedUnit;
	public GameObject selectedUnit1;

	public TileType[] tileTypes; // array (e.g. tile type grass, tile type table, tile type kitchen)

	int[,] tiles; // 2-Dimensional Array

	// 16:9
	int mapSizeX = 11;
	int mapSizeY = 9;

	// 2D array of Nodes
	Node[,] graph;
	Node source;

    void Start()
	{
		// Setup Selected Unit's variable
		selectedUnit1.GetComponent<Unit1> ().tileX = (int)(selectedUnit1.transform.position.x / 0.5 / 3); // Modified Formula -- Fixed value at initial point
		selectedUnit1.GetComponent<Unit1> ().tileY = (int)selectedUnit1.transform.position.y;
		//selectedUnit1.GetComponent<Unit1> ().map = this;

		//GenerateMapData ();
		//GeneratePathfindingGraph ();
		//GenerateMapVisual ();
	}

	public void GenerateMapData()
	{
		// Allocate map tiles
		tiles = new int[mapSizeX, mapSizeY]; //instantiate

		int x, y;

		// Initialize Entire map
		// Set everything to be walkable
		for (x = 0; x < mapSizeX; x++) {
			for (y = 0; y < mapSizeY; y++) {
				tiles[x,y] = 0; // first tile type which is walkable.
			}
		}

	}

	////////////////////////////////////////
	float CostToEnterTile(int x, int y)
	{
		TileType tt = tileTypes [ tiles[x,y] ];

		if (WalkableTile(x, y) == false)
			return Mathf.Infinity;

		return tt.movementCost;
	}

	public bool WalkableTile(int x, int y)
	{
		TileType tt = tileTypes [ tiles[x,y] ];
		
		return tt.walkable;
	}

	public void GeneratePathfindingGraph()
	{
		//Data Structure
		//Initialize the array
		graph = new Node[mapSizeX, mapSizeY];

		//Initialize a Node for each spot in the array
		for (int x = 0; x < mapSizeX; x++) {
			for (int y = 0; y < mapSizeY; y++) {
				graph[x,y] = new Node();
				graph[x,y].x = x;
				graph[x,y].y = y;
			}
		}

		// Calculate all the neighbours now
		for (int x = 0; x < mapSizeX; x++) {
			for (int y = 0; y < mapSizeY; y++) {
				// 4-way connected map, 8-way tiles
				if (x > 0)
					graph[x,y].neighbours.Add(graph[x - 1, y]);
				if (x < mapSizeX - 1)
					graph[x,y].neighbours.Add(graph[x + 1, y]);
				if (y > 0)
					graph[x,y].neighbours.Add(graph[x, y - 1]);
				if (y < mapSizeY - 1)
					graph[x,y].neighbours.Add(graph[x, y + 1]);
			}
		}
	}

	public void GenerateMapVisual()
	{
		for (int x = 5; x < mapSizeX; x++) {
			for (int y = 0; y < mapSizeY; y++) {
				TileType tt = tileTypes[tiles[x,y]];
                //Generate Visual
                float newX = x * 0.5f;
				GameObject tmp_go = (GameObject)Instantiate( tt.tileVisualPrefab, new Vector2((float) x + newX,y), Quaternion.identity);
				MoveableTile mt = tmp_go.GetComponent<MoveableTile>();
				mt.mtX = x;
				mt.mtY = y;
				mt.map1 = this;
			}
		}
	}

	public Vector2 TileToWorld(int x, int y)
	{
		return new Vector2 (x, y);
	}

	public void GeneratePathTo (int x, int y)
	{
        //Clear out our units old path
		selectedUnit1.GetComponent<Unit1> ().currentPath = null;
		//Dijkstra's (A* algorithm) Algorithm
		//Using a priority Queue
		// pseudocode from - wikipedia.org
		Dictionary<Node, float> dist = new Dictionary<Node, float> (); // distance
		Dictionary<Node, Node> prev = new Dictionary<Node, Node> (); // previous, predecessor

		// Q in wikipedia - the list of nodes that are unvisited
		List<Node> unvisited = new List<Node>();

        if (Unit1.unit_queue1.Count == 0)
        {
            int temp_X = selectedUnit1.GetComponent<Unit1>().tileX;
            int temp_Y = selectedUnit1.GetComponent<Unit1>().tileY;
            if (temp_X == x && temp_Y == y)
            {
                temp_X = temp_X + 1;
                temp_Y = temp_Y + 1;
            }
            source = graph[temp_X, temp_Y];
        }
        else if(Unit1.unit_queue1.Count >= 1)
        {
            int temp_X = Unit1.unit_queue1.ElementAt(Unit1.unit_queue1.Count - 1).Last().x;
            int temp_Y = Unit1.unit_queue1.ElementAt(Unit1.unit_queue1.Count - 1).Last().y;
            if (temp_X == x && temp_Y == y)
            {
                temp_X = temp_X + 1;
                temp_Y = temp_Y + 1;
            }
            source = graph[temp_X, temp_Y];
        }

		//source = graph [selectedUnit1.GetComponent<Unit1> ().tileX,
		//                selectedUnit1.GetComponent<Unit1> ().tileY];

		Node target = graph [x,y];

		// Create Vertex Set
		//Initialization
		dist [source] = 0; // Unknown distance - Infinity/Zero
		prev [source] = null; // Previous node in optimal path from source
		//Initialize everything to have infinite distance
		foreach (Node v in graph) { // where v has not yet been assigned
			if(v != source)
			{
				dist[v] = Mathf.Infinity; // Unknown distance from source to v - Infinity
				prev[v] = null; // Previous node in optimal path from source
			}

			unvisited.Add(v);
		}
		// While Q is not empty:
		while (unvisited.Count > 0) { // The main Loop
			// Consider having Q be a Priority Queue for fast performance
			// u is going to be the unvisited node with the shortest path.
			Node u = null;//vertex in Q with min dist[u] // source node in first case
			//Optimize
			foreach (Node possibleU in unvisited)
			{
				if (u == null || dist[possibleU] < dist[u])
				{
					u = possibleU;
				}
			}

			// Shortest Path
			if (u == target)
			{
				break; // Exit the while loop if found shortest path
			}


			unvisited.Remove(u); // remove u from Q

			foreach(Node v in u.neighbours) // for each neighbor v of u // where v has not yet been removed
			{
				//float alt = dist[u] + u.DistanceTo(v); // alt(temp float) := dis[u] + length(u, v)
				float alt = dist[u] + CostToEnterTile(v.x, v.y); 
				if (alt < dist[v]) // A shorter path to v has been found
				{
					dist[v] = alt;
					prev[v] = u;
				}
			}
		}
		// Check if no route to target at ALL
		if (prev[target] == null)
		{
			// No route between the target and the source
			return;
		}
		// Loop each target and add them to current path
		List<Node> currentPath = new List<Node> ();
		Node curr = target;

		// Setp through the 'prev' chain and add to path
		while(curr != null)
		{
			currentPath.Add(curr);
			curr = prev[curr];
		}
		//Invert current path
		currentPath.Reverse ();
        
		selectedUnit1.GetComponent<Unit1> ().currentPath = currentPath;
        selectedUnit1.GetComponent<Unit1>().QueueAction(currentPath);
	}
}



















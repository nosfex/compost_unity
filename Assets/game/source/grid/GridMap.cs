using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridMap : MonoBehaviour
{
    public Grid gridBase;
    Grid[][] currentGrids;

    public int initialGrids;
    public GameObject testSphere;
    [HideInInspector]
    public int gridCount;
    int increaseGridCount = 0;
    // Use this for initialization
	void Start ()
    {
        initializeMap(initialGrids, out currentGrids);
        Grid g = currentGrids[1][1];
        GameObject sphere = Instantiate(testSphere);
        sphere.transform.position = g.transform.position;
        sphere.transform.SetParent(g.transform);
	}

    void initializeMap(int gridSize, out Grid[][] grids, int gridOffset = 0)
    {

        int maxGrids = (gridSize);
        // GH: Initialize the grids ?
        grids = new Grid[maxGrids][];
        // GH: initial size for the grid
        for (int x = 0; x < maxGrids; x++)
        {
            grids[x] = new Grid[maxGrids];
            for (int y = 0; y < maxGrids; y++)
            {
                Grid g = GameObject.Instantiate<Grid>(gridBase);
                g.transform.position = new Vector3(-10 * (y + gridOffset), 0, -10 * (x + gridOffset) );
                g.transform.SetParent(this.gameObject.transform);
                // GH: Set the grid

                g.name = "grid_" + x.ToString() + "_" + y.ToString() + "_pass_" + increaseGridCount.ToString();
                grids[x][y] = g;
            }
        }

        gridCount = maxGrids;

    }

    public void AddGrids()
    {
        // GH: Add 1 line for every side
        increaseGridCount += 2;
        gridCount+=2;

        Grid[][] temp;
        initializeMap(gridCount, out temp, -increaseGridCount);
        // GH: Recalculate with the maximum possible grids per line
        int maxGridLine = gridCount;
        // GH: Replace the new tiles with the old ones
        for (int x = 1; x < maxGridLine - 1; x++)
        {
            for (int y = 1; y < maxGridLine - 1; y++)
            {
                Vector3 newPos = temp[x][y].transform.position;
                string name = temp[x][y].name;
                Destroy(temp[x][y]);
                temp[x][y] = Instantiate(currentGrids[x - 1][y - 1]);
                temp[x][y].transform.SetParent(transform);
                temp[x][y].name = name;
                temp[x][y].transform.position = newPos;
            }
        }

        // GH: Make everything cool
        currentGrids = temp;

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("pass_" + increaseGridCount))
            {
                continue;
            }

            else
            {
                GameObject go = transform.GetChild(i).gameObject;
                Destroy(go, 0.1f);
            }
        }
        /*
        for (int i = 0; i < gridCount; i++)
        {
            foreach (Grid g in temp[i])
            {
                Destroy(g.gameObject, 0.5f);
            }
        }
        */
        
    }

    public List<Grid> getN4List(int x, int y)
    {
        List<Grid> n4 = new List<Grid>();

        if (x > 0)
        {
            n4.Add(currentGrids[x - 1][y]);
        }

        if (x < gridCount - 1)
        {
            n4.Add(currentGrids[x + 1][y]);
        }

        if (y > 0)
        {
            n4.Add(currentGrids[x][y - 1]);
        }

        if (y < gridCount - 1)
        {
            n4.Add(currentGrids[x][y + 1]);
        }

        return n4;
    }



    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            AddGrids();
        }
	}
}

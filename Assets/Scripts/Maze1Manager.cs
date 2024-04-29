using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze1Manager : MonoBehaviour
{
    //followed what we learned in class, thank you!!

    //Prefab database
    [SerializeField]
    PrefabDatabase prefabDB;

    //creating map size
    [SerializeField]
    int mazeX = 20;
    [SerializeField]
    int mazeY = 20;

    //Container
    [SerializeField]
    Transform mazeGroup;

    //Prefab instances 2D array
    Maze1Cell[,] mazeCellMap;

    //Stack for Recursive backtracker
    Stack<Maze1Cell> pathFindingCells = new Stack<Maze1Cell>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateMaze();
    }

    void GenerateMaze()
    {
        mazeCellMap = new Maze1Cell[mazeX, mazeY];


        //building the cells
        for (int x = 0; x < mazeX; x++)
        {
            for (int y = 0; y < mazeY; y++)
            {
                Maze1Cell cell = Instantiate(prefabDB.prefabList[0], mazeGroup).GetComponent<Maze1Cell>();
                cell.transform.position = new Vector3(cell.mazeSize * x, 0, cell.mazeSize * y);

                mazeCellMap[x, y] = cell;

                //assigning
                cell.Init(x, y);
            }
        }

        //starting recurssive
        RecursiveBacktracking(mazeCellMap[Random.Range(0, mazeX), Random.Range(0, mazeY)]);
    }

    void RecursiveBacktracking(Maze1Cell selectedCell)
    {
        selectedCell.isVisited = true;
        List<Maze1Cell> neighborUnvisitedCells = new List<Maze1Cell>();
        

        //making the openings
        if (selectedCell.locX - 1 >= 0)
        {
            Maze1Cell checkingNeighborCell = mazeCellMap[selectedCell.locX - 1, selectedCell.locY];
            if (!checkingNeighborCell.isVisited)
            {
                neighborUnvisitedCells.Add(checkingNeighborCell);
            }
        }
        if (selectedCell.locX + 1 < mazeX)
        {
            Maze1Cell checkingNeighborCell = mazeCellMap[selectedCell.locX + 1, selectedCell.locY];
            if (!checkingNeighborCell.isVisited)
            {
                neighborUnvisitedCells.Add(checkingNeighborCell);
            }
        }
        if (selectedCell.locY - 1 >= 0)
        {
            Maze1Cell checkingNeighborCell = mazeCellMap[selectedCell.locX, selectedCell.locY - 1];
            if (!checkingNeighborCell.isVisited)
            {
                neighborUnvisitedCells.Add(checkingNeighborCell);
            }
        }
        if (selectedCell.locY + 1 < mazeY)
        {
            Maze1Cell checkingNeighborCell = mazeCellMap[selectedCell.locX, selectedCell.locY + 1];
            if (!checkingNeighborCell.isVisited)
            {
                neighborUnvisitedCells.Add(checkingNeighborCell);
            }
        }

        //Twhen theres a leftover cell
        if (neighborUnvisitedCells.Count > 0)
        {
            //Connect
            Maze1Cell nextSelectedCell = neighborUnvisitedCells[Random.Range(0, neighborUnvisitedCells.Count)];
            if (nextSelectedCell.locX < selectedCell.locX)
            {
                //nextSelectedCell L + selectedCell R
                nextSelectedCell.walls[0].SetActive(false);
                selectedCell.walls[1].SetActive(false);
            }
            else if (nextSelectedCell.locX > selectedCell.locX)
            {
                //nextSelectedCell R + selectedCell L
                nextSelectedCell.walls[1].SetActive(false);
                selectedCell.walls[0].SetActive(false);
            }
            else if (nextSelectedCell.locY < selectedCell.locY)
            {
                //nextSelectedCell D + selectedCell U
                nextSelectedCell.walls[3].SetActive(false);
                selectedCell.walls[2].SetActive(false);
            }
            else if (nextSelectedCell.locY > selectedCell.locY)
            {
                //nextSelectedCell U + selectedCell D
                nextSelectedCell.walls[2].SetActive(false);
                selectedCell.walls[3].SetActive(false);
            }
            //Push current 
            pathFindingCells.Push(selectedCell);



         //Keep recursive
            RecursiveBacktracking(nextSelectedCell);
        }
        else if (pathFindingCells.Count > 0)
        {
            //roll back
            Maze1Cell nextSelectedCell = pathFindingCells.Pop();

            RecursiveBacktracking(nextSelectedCell);
        }
        else
        {
            Debug.Log("Generation Done");
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze1Cell : MonoBehaviour
{
    [HideInInspector]
    public bool isVisited = false;
    public float mazeSize = 5;

    //0 = left, 1 = right, 2 = up 3 = dpwm
    public GameObject[] walls;

    [HideInInspector]
    public int locX;
    [HideInInspector]
    public int locY;
    // Start is called before the first frame update


    public void Init(int x, int y)
    {
        locX = x;
        locY = y;

    }
}

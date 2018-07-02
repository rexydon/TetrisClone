using Assets.Scripts.GameClasses;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TetrisGrid : MonoBehaviour {

    private int gridWidth = 10;
    private int gridHeight = 20;
    private int gridExtra = 4;
    private int gridTotal;
    System.Random rnd = new System.Random();
    public float lastUpdate = 0.0f;
    private float timer = 0.0f;
    
    public GameObject[,] gridObjects;
    private TetrisGameGrid myGrid;  //null by default


	// Use this for initialization
	void Start () {
        gridTotal = gridHeight + gridExtra;
        myGrid = new TetrisGameGrid(gridWidth, gridTotal);
        gridObjects = new GameObject[gridWidth, gridTotal];

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridTotal; j++)
            {
                string useString = "/Grid/row " + j + "/Quad " + i;
                gridObjects[i, j] = GameObject.Find(useString);
            }
        }

        myGrid.gridSpaces[0, 1] = new Block(0, 1, BlockColor.Green);
        myGrid.gridSpaces[0, 0] = new Block(0, 0, BlockColor.Red);
        myGrid.gridSpaces[0, 2] = new Block(0, 2, BlockColor.Blue);
        myGrid.gridSpaces[0, 3] = new Block(0, 3, BlockColor.Gray);
        myGrid.gridSpaces[0, 4] = new Block(0, 4, BlockColor.Yellow);
        myGrid.gridSpaces[0, 5] = new Block(0, 5, BlockColor.White);
        myGrid.gridSpaces[0, 6] = new Block(0, 6, BlockColor.Cyan);
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridTotal; j++)
            {
                if (myGrid.gridSpaces[i, j] == null)
                {
                    gridObjects[i, j].SetActive(false);
                }
                else
                {
                    gridObjects[i, j].SetActive(true);
                    Material blockMat = gridObjects[i, j].GetComponent<Renderer>().material;
                    BlockColor useColor = myGrid.gridSpaces[i, j].color;
                    switch (useColor)
                    {
                        case BlockColor.Green:
                            blockMat.color = Color.green;
                            break;
                        case BlockColor.White:
                            blockMat.color = Color.white;
                            break;
                        case BlockColor.Red:
                            blockMat.color = Color.red;
                            break;
                        case BlockColor.Gray:
                            blockMat.color = Color.gray;
                            break;
                        case BlockColor.Yellow:
                            blockMat.color = Color.yellow;
                            break;
                        case BlockColor.Blue:
                            blockMat.color = Color.blue;
                            break;
                        case BlockColor.Cyan:
                            blockMat.color = Color.cyan;
                            break;
                        default:
                            break;
                    }

                }
            }
        }
        if (timer - lastUpdate >= 1.0f)
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    int isBlock = rnd.Next(10);
                    if (isBlock < 7)
                    {
                        int randNum = rnd.Next(1, 7);
                        myGrid.gridSpaces[i, j] = new Block(i, j, (BlockColor)Enum.Parse(typeof(BlockColor), randNum.ToString()));
                    }
                    else
                    {
                        myGrid.gridSpaces[i, j] = null;
                    }
                }
            }
            lastUpdate = timer;
        }
        timer += Time.deltaTime;
    }
}

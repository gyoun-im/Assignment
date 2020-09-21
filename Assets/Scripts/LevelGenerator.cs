﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject outsideCorner;
    public GameObject outsideWall;
    public GameObject insideCorner;
    public GameObject insideWall;
    public GameObject tJunction;
    public GameObject normalPellet;
    public GameObject powerPellet;

    private int [,] levelMap = 
        {
         {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
         {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
         {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
         {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
         {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
         {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
         {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
         {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
         {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
         {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
         {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
         {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
         {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
         {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
         {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };


    void Start()
    {
        //instantiate first quarter
        createLevelQuarter(levelMap, -30.0f, 28.0f);

        //mirror the first quarter and instantiate
        flipArray(1);
        createLevelQuarter(levelMap, -3.4f, 28.0f);

        //mirror the second quarter, remove the top layer and instantiate
        flipArray(2);
        for (int i = 0; i < 14; ++ i)
        {
            levelMap[0, i] = 0;
        }
        createLevelQuarter(levelMap, -3.4f, 1.4f);

        //mirror the third quarter and instantiate
        flipArray(1);
        createLevelQuarter(levelMap, -30.0f, 1.4f);
    }


    void Update()
    {
        
    }

    private void createLevelQuarter(int [,] array, float x, float y)
    {
        float yPos = y;
        for (int i = 0; i < 15; ++i)
        {
            float xPos = x;
            for (int j = 0; j < 14; ++j)
            {
                if (levelMap[i, j] == 1)
                {
                    createOutsideCorner(xPos, yPos, findRotation(i, j));
                }else if (levelMap[i, j] == 2)
                {
                    createOutsideWall(xPos, yPos, findRotation(i, j));
                }else if (levelMap[i, j] == 3)
                {
                    createInsideCorner(xPos, yPos, findRotation(i, j));
                }else if (levelMap[i, j] == 4)
                {
                    createInsideWall(xPos, yPos, findRotation(i, j));
                }else if (levelMap[i, j] == 5)
                {
                    createNormalPellet(xPos, yPos, 0);
                }else if (levelMap[i, j] == 6)
                {
                    createPowerPellet(xPos, yPos, 0);
                }else if (levelMap[i, j] == 7)
                {
                    createTJunction(xPos, yPos, findRotation(i, j));
                }
                xPos += 1.9f;
            }
            yPos -= 1.9f;
        }
    }


    private void createOutsideCorner(float xPos, float yPos, int rotation)
    {
        Instantiate(outsideCorner, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, rotation));
    }
    private void createOutsideWall(float xPos, float yPos, int rotation)
    {
        Instantiate(outsideWall, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, rotation));
    }
    private void createInsideCorner(float xPos, float yPos, int rotation)
    {
        Instantiate(insideCorner, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, rotation));
    }
    private void createInsideWall(float xPos, float yPos, int rotation)
    {
        Instantiate(insideWall, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, rotation));
    }
    private void createTJunction(float xPos, float yPos, int rotation)
    {
        Instantiate(tJunction, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, rotation));
    }
    private void createNormalPellet(float xPos, float yPos, int rotation)
    {
        Instantiate(normalPellet, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, rotation));
    }
    private void createPowerPellet(float xPos, float yPos, int rotation)
    {
        Instantiate(powerPellet, new Vector3(xPos, yPos, 0), Quaternion.Euler(0, 0, rotation));
    }


    private int findRotation(int i, int j)
    {
        int rotation = 0;
        //outside walls
        if (!isHorizontalEdge(i, j) && levelMap[i, j] == 2 && (levelMap[i + 1, j] == 2 || levelMap[i - 1, j] == 2))
        {
            rotation = 90;
        }
        //T Juntion
        else if (levelMap[i, j] == 7 && i > 0)
        {
            rotation = 180;
        }else if (!isEdge(i, j))
        {   //Inside Walls
            if (levelMap[i, j] == 4)
            {
                if (levelMap[i, j-1] == 0 || levelMap[i, j + 1] == 0 || levelMap[i, j - 1] == 5 || levelMap[i, j + 1] == 5)
                {
                    rotation = 90;
                }
                if ((levelMap[i, j-1] == 0 || levelMap[i, j + 1] == 0) && levelMap[i+ 1, j] == 0)
                {
                    rotation += 90;
                }
            //Inside Corners
            }else if (levelMap[i, j] == 3)
            {
                if (levelMap[i-1, j] == 4 || levelMap[i - 1, j] == 3)
                {
                    rotation += 90;
                }
                if (levelMap[i, j-1] == 4 || levelMap[i, j - 1] == 3)
                {
                    rotation += 90;
                }
                if ((levelMap[i, j-1] == 4 || levelMap[i, j - 1] == 3) && (levelMap[i+1, j] == 4 || levelMap[i + 1, j] == 3))
                {
                    rotation += 180;
                }
                if ((levelMap[i-1, j] == 3 || levelMap[i - 1, j] == 4) && levelMap[i, j+1] == 4 && levelMap[i, j - 1] == 4)
                {
                    rotation += 180;
                    if (levelMap[i+1, j] == 4)
                    {
                        rotation += 90;
                        if (j > 7)
                        {
                            rotation += 90;
                        }
                    }
                    if (levelMap[i - 1, j] == 4 && j > 7)
                    {
                        rotation += 270;
                    }
                }
            //Outside corners
            }else if(levelMap[i, j] == 1)
            {
                if (j < 6)
                {
                    rotation += 180;
                    if (levelMap[i-1, j] == 0 || levelMap[i - 1, j] == 5)
                    {
                        rotation += 90;
                    }
                }else if (levelMap[i + 1, j] == 0 || levelMap[i + 1, j] == 5)
                {
                    rotation += 90;
                }
            }

        }else if (isEdge(i, j))
        {   
            //outside corners on the edges of the array
            if (levelMap[i, j] == 1)
            {
                if (i == 14 || j == 13)
                {
                    rotation += 90;
                    if (j == 13)
                    {
                        rotation += 90;
                        if (i < 7)
                        {
                            rotation += 90;
                        }
                    }
                }
                if (i == 9 && j == 0)
                {
                    rotation += 90;
                }
            }
            //inside walls on the edges of the array
            if (levelMap[i, j] == 4)
            {
                rotation += 90;
                if (i > 0 && i < 14)
                {
                    if (levelMap[i+1, j] == 5 || levelMap[i - 1, j] == 5)
                    {
                        rotation += 90;
                    }
                }
            //inside corners on the edges of the array    
            }else if(levelMap[i, j] == 3)
            {
                rotation += 90;
                if (j == 0)
                {
                    rotation += 90;
                }
                if (i == 7)
                {
                    rotation += 180;
                    if (levelMap[0,0] == 0)
                    {
                        rotation += 90;
                        if (j > 0)
                        {
                            rotation += 180;
                        }
                    }
                }
                if (i == 4 && levelMap[i+1, j] == 4)
                {
                    rotation += 90;
                    if (j > 0)
                    {
                        rotation += 180;
                    }
                }
                if (i == 10 && levelMap[i + 1, j] == 4)
                {
                    rotation += 90;
                    if (j > 0)
                    {
                        rotation += 180;
                    }
                }
            }


        }
        return rotation;
    }


    private bool isEdge(int i, int j)
    {
        if (i == 0 || i == 14 || j == 0 || j == 13)
        {
            return true;
        }
        return false;
    }

    private bool isHorizontalEdge(int i, int j)
    {
        if (i == 0 || i == 14)
        {
            return true;
        }
        return false;
    }


    private void flipArray(int mode)
    {
        if (mode == 1)
        {
            for (int i = 0; i < 15; ++i)
            {
                int rowLength = levelMap.GetLength(1) -1;
                for (int j = 0; j < 7; ++j)
                {
                    swapYValue(i, j, rowLength);
                    --rowLength;
                }
            }
        }
        if (mode == 2)
        {
            for (int i = 0; i < 14; ++i)
            {
                int columnLength = levelMap.GetLength(0) - 1; 
                for (int j = 0; j < 7; ++j)
                {
                    swapXValue(i, j, columnLength);
                    --columnLength;
                }
            }
        }
    }

    private void swapYValue(int i, int j, int number)
    {
        int temp = levelMap[i, j];
        levelMap[i, j] = levelMap[i, number];
        levelMap[i, number] = temp;

    }

    private void swapXValue(int i, int j, int number)
    {
        int temp = levelMap[j, i];
        levelMap[j, i] = levelMap[number, i];
        levelMap[number, i] = temp;

    }
}

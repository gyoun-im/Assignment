using System.Collections;
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

    int [,] leveMap = 
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

    int xPos;
    int yPos;

    // Start is called before the first frame update
    void Start()
    {
        yPos = 10;

        for (int i = 0; i < 15; ++i)
        {
            xPos = -10;
            for (int j = 0; j < 14; ++j)
            {
                if (leveMap[i, j] == 1)
                {
                    createOutsideCorner(xPos, yPos, 0);
                }

                if (leveMap[i, j] == 2)
                {
                    createOutsideWall(xPos, yPos, 0);
                }

                if (leveMap[i, j] == 3)
                {
                    createInsideCorner(xPos, yPos, 0);
                }

                if (leveMap[i, j] == 4)
                {
                    createInsideWall(xPos, yPos, 0);
                }

                if (leveMap[i, j] == 5)
                {
                    createNormalPellet(xPos, yPos, 0);
                }

                if (leveMap[i, j] == 6)
                {
                    createPowerPellet(xPos, yPos, 0);
                }

                if (leveMap[i, j] == 7)
                {
                    createTJunction(xPos, yPos, 0);
                }
                xPos += 2;
            }
            yPos -= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void createOutsideCorner(int xPos, int yPos, int rotation)
    {
        Instantiate(outsideCorner, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void createOutsideWall(int xPos, int yPos, int rotation)
    {
        Instantiate(outsideWall, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void createInsideCorner(int xPos, int yPos, int rotation)
    {
        Instantiate(insideCorner, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void createInsideWall(int xPos, int yPos, int rotation)
    {
        Instantiate(insideWall, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void createTJunction(int xPos, int yPos, int rotation)
    {
        Instantiate(tJunction, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void createNormalPellet(int xPos, int yPos, int rotation)
    {
        Instantiate(normalPellet, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void createPowerPellet(int xPos, int yPos, int rotation)
    {
        Instantiate(powerPellet, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}

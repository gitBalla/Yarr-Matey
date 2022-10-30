using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Member Variables
    //// Level map
    int[,] levelMap =
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

    //// Map Pieces
    [SerializeField] private GameObject[] mapSprites;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("Map"));

        InstantiateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Instantiate the entire map
    void InstantiateMap()
    {
        InstantiateHalfMap(1);
        InstantiateHalfMap(-1);
    }

    // Instantiate half map, parameter: 1 for pos y (upper), -1 for neg y (lower)
    void InstantiateHalfMap(int y)
    {
        InstantiateQuarterMap(1, y);
        InstantiateQuarterMap(-1, y);
    }

    // Instantiate quarter map, parameter: 1 for pos x (right), -1 for neg x (left)
    void InstantiateQuarterMap(int x, int y)
    {
        int spriteID;
        GameObject thisSprite;
        Vector2 location;
        Vector3 rotationVector;
        Quaternion rotation;

        // iterate backwards through the 2d array to ensure starting from center and going out
        for (int i = levelMap.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = levelMap.GetLength(1) - 1; j >= 0; j--)
            {
                if (i != levelMap.GetLength(0) - 1 || y != 1) //remove duplicate line
                {
                    // get the sprite number
                    spriteID = levelMap[i, j];
                    // get the actual sprite object
                    thisSprite = mapSprites[spriteID];
                    // determine it's location based on iteration, map multiplier (0.5), origin distance (0.25), and x or y multiplier (pos/neg)
                    location = new Vector2(x * (((j - levelMap.GetLength(1)) * 0.5f) + 0.25f), y * (((i - levelMap.GetLength(0)) * 0.5f) + 0.5f));
                    // find rotation for each sprite
                    rotationVector = FindRotation(i, j, x, y);
                    rotationVector.x *= x;
                    rotationVector.y *= y;
                    rotation = Quaternion.Euler(rotationVector);

                    Instantiate(thisSprite, location, rotation); 
                }
            }
        }
    }

    Vector3 FindRotation(int x, int y, int yRotate, int xRotate)
    {
        Vector3 rotationVector = Vector3.zero;
        int spriteID = levelMap[x, y];
        switch (spriteID)
        {
            case 0:
            case 5:
            case 6:
                break; //do nothing with blank spaces and powerups

            case 1:
            case 3:
                break; //rotate corner pieces

            case 2:
            case 4:
                break; //rotate flat wall pieces

            case 7:
                break; //rotate inner/outer wall connector

            default:
                break;
        }
        if (xRotate == 1 && yRotate == 1) { rotationVector += new Vector3(180, 0, 0); }
        if (xRotate == -1 && yRotate == -1) { rotationVector += new Vector3(0, 180, 0); }
        if (xRotate == 1 && yRotate == -1) { rotationVector += new Vector3(180, 180, 0); }

        return rotationVector;
    }
}

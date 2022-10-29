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
        float zRotation;
        // iterate backwards through the 2d array to ensure starting from center and going out
        for (int i = levelMap.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = levelMap.GetLength(1) - 1; j >= 0; j--)
            {
                // get the sprite number
                spriteID = levelMap[i, j];
                // get the actual sprite object
                thisSprite = mapSprites[spriteID];
                // determine it's location based on iteration, map multiplier (0.5), origin distance (0.25), and x or y multiplier (pos/neg)
                location = new Vector2(x * (((j - levelMap.GetLength(1)) * 0.5f) + 0.25f), y * (((i - levelMap.GetLength(0)) * 0.5f) + 0.25f));
                // find rotation for each sprite
                zRotation = FindRotation(i,j);

                Instantiate(thisSprite, location, Quaternion.Euler(new Vector3(0.0f, 0.0f, zRotation)));
            }
        }
    }

    float FindRotation(int x, int y)
    {

        return 0.0f;
    }
}

using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
    
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    public int columns = 8;
    public int rows = 8;
    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;

    private Transform boardHolder;
    private List<Vector3> gridPossision = new List<Vector3>();

    void InitialiseList()
    {
        gridPossision.Clear();
        for (int i = 1; i < columns - 1; ++i)
            for (int j = 1; j < rows - 1; ++j)
                gridPossision.Add(new Vector3(i, j, 0f));
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int i=-1; i<columns+1;++i)
            for (int j=-1;j<rows+1;++j)
            {
                GameObject toIntantiate;
                if (i == -1 || i == columns || j == -1 || j == rows)
                    toIntantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                else
                    toIntantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                GameObject instance = Instantiate(toIntantiate, new Vector3(i, j, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
    }

    Vector3 RandomPossition()
    {
        int randomIndex = Random.Range(0, gridPossision.Count);
        Vector3 result = gridPossision[randomIndex];
        gridPossision.RemoveAt(randomIndex);
        return result;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max);
        for (int i=0;i<objectCount;++i)
        {
            Vector3 possition = RandomPossition();
            GameObject tileChoise = tileArray[Random.Range(0,tileArray.Length)];
            Instantiate(tileChoise, possition, Quaternion.identity);
        }
    }
    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
        LayoutObjectAtRandom(enemyTiles, (int)Mathf.Log((float)level, 2f), (int)Mathf.Log((float)level, 2f));
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }


}

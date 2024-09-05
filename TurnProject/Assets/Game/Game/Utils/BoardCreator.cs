using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public int boardLength {  get; private set; }
    public int boardWidth { get; private set; }
    public GameObject tileObj { get; private set; }
    public List<GameObject> tiles { get; private set; }

    public BoardCreator(int length, int width, GameObject tile)
    {
        boardLength = length;
        boardWidth = width;
        tileObj = tile;
        tiles = new List<GameObject>();
    }

    public void CreateBoard()
    {
        
        int addIndex = 0;
        for(int i = 0; i < boardLength; i++)
        {
            addIndex++;
            GameObject go = Instantiate(tileObj, new Vector3(1, 1, 1.1f*i + 1), Quaternion.identity);
            tiles.Add(go);
        }

        for(int i = 0; i < boardWidth; i++)
        {
            addIndex++;
            GameObject go = Instantiate(tileObj, new Vector3(1.1f * i + 2.1f, 1, tiles[boardLength - 1].transform.position.z), Quaternion.identity);
            tiles.Add(go);
        }

        for (int i = 0; i< boardLength; i++)
        {
            addIndex++;
            GameObject go = Instantiate(tileObj, new Vector3(tiles[boardLength + boardWidth - 1].transform.position.x, 1, 1.1f * i - .1f), Quaternion.identity);
            tiles.Add(go);
        }

        for (int i = 0; i < boardWidth; i++)
        {
            addIndex++;
            GameObject go = Instantiate(tileObj, new Vector3(1.1f * i +1, 1, tiles[boardLength + boardWidth].transform.position.z), Quaternion.identity);
            tiles[(2 * boardLength) + boardWidth - 1].GetComponent<Renderer>().material.color = Color.blue;
            tiles.Add(go);
        }
    }
}

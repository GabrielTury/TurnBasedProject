using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public int boardLength {  get; private set; }
    public int boardWidth { get; private set; }
    public GameObject tileObj { get; private set; }
    public GameObject middleTileObj { get; private set; }
    public GameObject startTileObj { get; private set; }
    public GameObject CornerTileObj { get; private set; }

    public List<GameObject> tiles { get; private set; }

    public BoardCreator(int length, int width, GameObject tile, GameObject corner1, GameObject middle, GameObject Start)
    {
        boardLength = length;
        boardWidth = width;
        tileObj = tile;
        tiles = new List<GameObject>();
        CornerTileObj = corner1;
        startTileObj = Start;
        middleTileObj = middle;
    }

    public void CreateBoard()
    {
        float spaceM = 1.5f;
        int addIndex = 0;
        for (int i = 0; i < boardLength; i++)
        {
            GameObject go;
            if (i == 0)
            {
                go = Instantiate(startTileObj, new Vector3(1, 1, 1.1f * i + 1), Quaternion.identity);
            }
            else if (i == (int)boardLength/2)
            {
                go = Instantiate(middleTileObj, new Vector3(1, 1, spaceM * i + 1), Quaternion.identity);
            }
            else
            {
                go = Instantiate(tileObj, new Vector3(1, 1, 1.1f*i + 1), Quaternion.identity);
            }
            go.transform.localScale *= 0.1f;
            go.transform.rotation = Quaternion.Euler(0, 90, 0);
            tiles.Add(go);
            addIndex++;
        }


        for(int i = 0; i < boardWidth; i++)
        {
            GameObject go;
            if (i == 0)
            {
                go = Instantiate(CornerTileObj, new Vector3(1.1f * i + 2.1f, 1, tiles[boardLength - 1].transform.position.z), Quaternion.identity);
            }
            else if (i == (int)boardWidth / 2)
            {
                go = Instantiate(middleTileObj, new Vector3(1.1f * i + 2.1f, 1, tiles[boardLength - 1].transform.position.z), Quaternion.identity);
            }
            else
            {
                go = Instantiate(tileObj, new Vector3(1.1f * i + 2.1f, 1, tiles[boardLength - 1].transform.position.z), Quaternion.identity);
            }
            go.transform.localScale *= 0.1f;
            addIndex++;
            tiles.Add(go);
        }

        for (int i = 0; i< boardLength; i++)
        {
            GameObject go;
            if (i == 0)
            {
                go = Instantiate(CornerTileObj, new Vector3(tiles[boardLength + boardWidth - 1].transform.position.x, 1, 1.1f * i - .1f), Quaternion.identity);
            }
            else if (i == (int)boardLength / 2)
            {
                go = Instantiate(middleTileObj, new Vector3(tiles[boardLength + boardWidth - 1].transform.position.x, 1, 1.1f * i - .1f), Quaternion.identity);
            }
            else
            {
                go = Instantiate(tileObj, new Vector3(tiles[boardLength + boardWidth - 1].transform.position.x, 1, 1.1f * i - .1f), Quaternion.identity);
            }

            go.transform.rotation = Quaternion.Euler(0, 90, 0);
            go.transform.localScale *= 0.1f;
            addIndex++;
            tiles.Add(go);
        }

        for (int i = 0; i < boardWidth; i++)
        {
            addIndex++;
            GameObject go = Instantiate(tileObj, new Vector3(1.1f * i - 1, 1, tiles[boardLength + boardWidth].transform.position.z), Quaternion.identity);
            tiles[(2 * boardLength) + boardWidth - 1].GetComponent<Renderer>().material.color = Color.blue;
            go.transform.localScale *= 0.1f;
            tiles.Add(go);
        }
    }

    public List<GameObject> GetTileList()
    {
        return tiles;
    }
}

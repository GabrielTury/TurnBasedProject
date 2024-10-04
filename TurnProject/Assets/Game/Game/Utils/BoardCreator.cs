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
        Vector3 LastTilePosition = Vector3.one;
        for (int i = 0; i < boardLength; i++)
        {
            GameObject go;
            if (i == 0)
            {
                go = Instantiate(startTileObj, new Vector3(1, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
                go.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
            }
            else if (i == 1)
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z + 1.5f), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == (int)boardLength/2)
            {
                go = Instantiate(middleTileObj, new Vector3(1, 1, 1.65f + LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == 1 + ((int)boardLength / 2))
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z + 1.65f), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else
            {
                go = Instantiate(tileObj, new Vector3(1, 1, 1.1f + LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
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
                go = Instantiate(CornerTileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z + 1.5f), Quaternion.identity);
                LastTilePosition = go.transform.position;
                go.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
            }
            else if (i==1)
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x + 1.4f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == (int)boardWidth / 2)
            {
                go = Instantiate(middleTileObj, new Vector3(LastTilePosition.x + 1.65f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == 1+((int)boardWidth / 2))
            {
                go = Instantiate(middleTileObj, new Vector3(LastTilePosition.x + 1.65f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x + 1.1f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
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
                go = Instantiate(CornerTileObj, new Vector3(LastTilePosition.x + 1.5f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
                go.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
            }
            else if (i == 1)
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z - 1.4f), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == (int)boardLength / 2)
            {
                go = Instantiate(middleTileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z - 1.65f), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == 1 + ((int)boardLength / 2))
            {
                go = Instantiate(middleTileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z - 1.65f), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z -1.1f), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }

            go.transform.rotation = Quaternion.Euler(0, 90, 0);
            go.transform.localScale *= 0.1f;
            addIndex++;
            tiles.Add(go);
        }

        for (int i = 0; i < boardWidth; i++)
        {
            GameObject go;
            if (i == 0)
            {
                go = Instantiate(CornerTileObj, new Vector3(LastTilePosition.x, 1, LastTilePosition.z - 1.5f), Quaternion.identity);
                LastTilePosition = go.transform.position;
                go.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
            }
            else if (i == 1)
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x - 1.5f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == (int)boardWidth / 2)
            {
                go = Instantiate(middleTileObj, new Vector3(LastTilePosition.x - 1.65f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else if (i == 1+((int)boardWidth / 2))
            {
                go = Instantiate(middleTileObj, new Vector3(LastTilePosition.x - 1.65f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }
            else
            {
                go = Instantiate(tileObj, new Vector3(LastTilePosition.x-1.1f, 1, LastTilePosition.z), Quaternion.identity);
                LastTilePosition = go.transform.position;
            }

            addIndex++;
            go.transform.localScale *= 0.1f;
            tiles.Add(go);
        }
    }

    public List<GameObject> GetTileList()
    {
        return tiles;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set; }

    public List<GameObject> tileList;

    [SerializeField]
    GameObject baseObject, corner, start, middle;

    [SerializeField]
    TileScriptableObject[] tileInfo;
    


    [SerializeField]
    Vector2 boardDimensions;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        BoardCreator bc = new BoardCreator((int)boardDimensions.y, (int)boardDimensions.x, baseObject, corner, middle, start);
        bc.CreateBoard();
        tileList = bc.GetTileList();
        RandomizeBoard();
    }

    public void RandomizeBoard()
    {
        foreach (GameObject tile in tileList)
        {
            if(tile.GetComponent<Tile>() != null)
            {
                int rand = Random.Range(0, tileInfo.Length);
                tile.GetComponent<Tile>().SetTileInfo(tileInfo[rand]);
            }
        }
    }

    public Tile GetNearestTile(Vector3 pos)
    {
        float dist = 30f;
        Tile ret = null;
        foreach(GameObject tile in tileList)
        {
            if (Vector3.Distance(tile.transform.position, pos) < dist)
            {
                ret = tile.GetComponent<Tile>();
            }
        }
        return ret;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR
    [ContextMenu("CreateBoard")]
    public void CreateDebugBoard()
    {
        if(tileList.Count > 0)
        {
            foreach(GameObject go in tileList)
            {
                DestroyImmediate(go);    
                
            }
            tileList.Clear();
            return;
        }
        BoardCreator bc = new BoardCreator((int)boardDimensions.y, (int)boardDimensions.x, baseObject, corner, middle, start);
        bc.CreateBoard();
        tileList = bc.GetTileList();
        RandomizeBoard();

    }
#endif
}

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
        Debug.Log(tileList[5]);
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

    }
#endif
}

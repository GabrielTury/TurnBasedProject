using System.Collections;
using System.Collections.Generic;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject baseObject;

    [SerializeField]
    Vector2 boardDimensions;
    void Start()
    {
        BoardCreator bc = new BoardCreator((int)boardDimensions.y, (int)boardDimensions.x, baseObject);
        bc.CreateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField, Range(1f,20f)]
    float moveSpeed;

    int currentTileIndex;

    BoardManager boardManagerInstance;
    private void OnEnable()
    {
        GameEvents.TurnStart += OnStartTurn;
        GameEvents.TurnEnd += OnEndTurn;
    }

    private void OnDisable()
    {
        GameEvents.TurnStart -= OnStartTurn;
        GameEvents.TurnEnd -= OnEndTurn;
    }
    private void OnStartTurn()
    {
        
    }
    private void OnEndTurn()
    {
        
    }

    public void OnLocalStartTurn()
    {
        GameEvents.MovePlayer += Movement;
    }
    public void OnLocalEndTurn()
    {
        GameEvents.MovePlayer -= Movement;
    }
    private void Start()
    {
        boardManagerInstance = BoardManager.Instance;
    }
    #region Movement
    void Movement(int movementAmount)
    {
        //Debug.Log("Called Movement in player");

        currentTileIndex += movementAmount;
        //Debug.Log(boardManagerInstance);
        if(currentTileIndex > boardManagerInstance.tileList.Count)
        {
            currentTileIndex -= boardManagerInstance.tileList.Count;
        }
        MoveToTile();
    }

    private IEnumerator MoveToTile()
    {
        while(Vector3.Distance(transform.position, boardManagerInstance.tileList[currentTileIndex].transform.position) > .01)
        {
            transform.position = Vector3.MoveTowards(transform.position, boardManagerInstance.tileList[currentTileIndex].transform.position, Time.deltaTime * moveSpeed);

            yield return new WaitForEndOfFrame();
        }

        OnLocalEndTurn();
        GameEvents.OnTurnEnded();
    }
    #endregion
}

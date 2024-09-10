using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Tooltip("Count Starts From ZERO")]
    int playerAmount;

    int turnPlayer;

    public List<PlayerScript> players { get; private set; }

    public GameObject playerTempObject;

    private void OnEnable()
    {
        GameEvents.TurnEnd += TurnChanger;
    }

    private void OnDisable()
    {
        GameEvents.TurnEnd -= TurnChanger;
    }

    private void Awake()
    {
        players = new List<PlayerScript>();
    }
    void Start()
    {
        PlayerScript p = Instantiate(playerTempObject).GetComponent<PlayerScript>();
        if(p != null)
        {
            players.Add(p);
            players[0].OnLocalStartTurn();
            GameEvents.OnMovePlayer(5);
            //Debug.Log("Called Move Event");

        }
        else
        {
            Debug.LogError("No PlayerScript Found");
        }
    }

    private void TurnChanger()
    {
        if(turnPlayer + 1 > playerAmount)
        {
            turnPlayer = 0;
        }
        else
        {
            turnPlayer++;
        }
        //Change Turn Animation
        players[turnPlayer].OnLocalStartTurn();
    }
    public void SetPlayerAmount(int i)
    {
        playerAmount = i;
    }
}

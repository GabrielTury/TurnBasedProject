using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int playerAmount;

    int turnPlayer;

    public List<PlayerScript> players { get; private set; }

    public GameObject playerTempObject;

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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerAmount(int i)
    {
        playerAmount = i;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Tooltip("Count Starts From ONE")]
    int playerAmount;

    int turnPlayer;

    public bool ismoving;

    [SerializeField, Tooltip("List with all available cards on the game")]
    private List<ScriptableCard> cardList;

    public List<PlayerScript> players { get; private set; }

    public GameObject playerTempObject;

    private void OnEnable()
    {
        GameEvents.TurnEnd += TurnChanger;
        GameEvents.StartGame += InitializeGame;
    }

    private void OnDisable()
    {
        GameEvents.TurnEnd -= TurnChanger;
        GameEvents.StartGame -= InitializeGame;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        players = new List<PlayerScript>();
    }

    private void InitializeGame()
    {
        for (int i = 0; i < playerAmount; i++)
        {
            PlayerScript a = Instantiate(playerTempObject).GetComponent<PlayerScript>();
            players.Add(a);
        }

        if (players.Count > 0)
        {
            foreach (PlayerScript py in players)
            {
                py.SetInitialCards(7, cardList);
            }

            players[0].OnLocalStartTurn();
            //Debug.Log("Called Move Event");

        }
        else
        {
            Debug.LogError("No PlayerScript Found");
        }
    }

    private void TurnChanger()
    {
        if(turnPlayer + 1 >= playerAmount)
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

    public PlayerScript GetNextPlayer()
    {
        int playerIndex = 0;
        if(turnPlayer + 1 >= playerAmount)
        {
            playerIndex = 0;
        }
        else
        {
            playerIndex = playerAmount + 1;
        }

        return players[playerIndex];
    }

    public ScriptableCard[] GetRandomCards(int amount)
    {
        ScriptableCard[] returnCards = new ScriptableCard[amount];
        for(int i = 0; i < amount; i++)
        {
            returnCards[i] = cardList[Random.Range(0, cardList.Count)];
        }

        return returnCards;
    }


}

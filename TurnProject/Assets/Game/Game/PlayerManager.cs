using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Tooltip("Count Starts From ONE")]
    int playerAmount;

    int turnPlayer;

    public bool ismoving;

    [SerializeField, Tooltip("List with all available cards on the game")]
    private List<ScriptableCard> cardList;

    [SerializeField, Tooltip("List with all special cards")]
    private List<ScriptableCard> specialCards;

    [SerializeField]
    private GameObject turnChangeScreen;

    [SerializeField]
    private GameObject winScreen;

    [SerializeField]
    private TMP_Text winTxt;

    public List<PlayerScript> players { get; private set; }

    public GameObject playerTempObject;

    private void OnEnable()
    {
        GameEvents.TurnEnd += TurnChanger;
        GameEvents.StartGame += InitializeGame;
        GameEvents.EndGame += GameEvents_EndGame;
    }

    private void GameEvents_EndGame(PlayerScript arg0)
    {
        //Disable all players's cards
        foreach(var p in players)
        {
            p.DisableCards();
        }
        //Show Victory Screen than return to Menu
        winScreen.SetActive(true);
        winTxt.text = string.Format("Jogador {0} Ganhou!", turnPlayer+1);
    }

    private void OnDisable()
    {
        GameEvents.TurnEnd -= TurnChanger;
        GameEvents.StartGame -= InitializeGame;
        GameEvents.EndGame -= GameEvents_EndGame;
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
            PlayerScript a = Instantiate(GameManager.instance.GetPlayer(i)).GetComponentInChildren<PlayerScript>();
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
        turnChangeScreen.SetActive(true);
        turnChangeScreen.GetComponentInChildren<TMP_Text>().text = string.Format("Turno do jogador:\n Jogador {0}", turnPlayer + 1);
                
    }

    public void StartPlayerTurn()
    {
        players[turnPlayer].OnLocalStartTurn();
        turnChangeScreen.SetActive(false);
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
            playerIndex = turnPlayer + 1;
        }

        return players[playerIndex];
    }

    public PlayerScript GetCurrentPlayer()
    {
        return players[turnPlayer];
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

    public ScriptableCard[] GetRandomSpecialCards(int amount)
    {
        ScriptableCard[] returnCards = new ScriptableCard[amount];
        for (int i = 0; i < amount; i++)
        {
            returnCards[i] = specialCards[Random.Range(0, specialCards.Count)];
        }

        return returnCards;
    }

    #region preguica
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

}

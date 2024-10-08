using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    int numOfPlayers = 2;

    public static GameManager instance;


    [SerializeField]
    GameObject[] playerObjects;

    int currentSelections;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
        playerObjects = new GameObject[numOfPlayers];
    }

    // Update is called once per frame
    void InitializeGame()
    {
        currentSelections = 0;

        PlayerManager pm = FindObjectOfType<PlayerManager>();
        if (pm)
        {
            pm.SetPlayerAmount(numOfPlayers);
            
        }
        else
        {
            Debug.LogWarning("No PlayerManager Found!");
        }

        GameEvents.OnGameStarted();
    }

    public void SetPlayerPawn(GameObject pawn)
    {
        playerObjects[currentSelections] = pawn;
        currentSelections++;

        if(currentSelections >= numOfPlayers)
        {
            SceneManager.LoadScene(1);
        }

        text.text = string.Format(" \n Jogador Nº: {0}", currentSelections + 1);
    }

    public GameObject GetPlayer(int index)
    {
        return playerObjects[index];
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level ==1)
        {
            InitializeGame();
        }
    }
}

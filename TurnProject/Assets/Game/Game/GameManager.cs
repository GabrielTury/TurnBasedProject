using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    int numOfPlayers = 2;

    [SerializeField]
    GameObject[] playerObjects;

    int currentSelections;

    void Start()
    {
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
    }
}

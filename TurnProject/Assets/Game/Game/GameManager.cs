using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    int numOfPlayers = 1;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        InitializeGame();
    }

    // Update is called once per frame
    void InitializeGame()
    {
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
}

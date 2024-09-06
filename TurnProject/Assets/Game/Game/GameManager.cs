using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    int numOfPlayers;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        GameEvents.StartGame += InitializeGame;
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
    }
}

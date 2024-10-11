using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    [SerializeField, Range(1f,20f)]
    float moveSpeed;

    int currentTileIndex;

    [SerializeField]
    private GameObject cardPrefab;

    BoardManager boardManagerInstance;

    private List<GameObject> cards;

    public Tile currentTile { get; private set; }

    private void Awake()
    {
        cards = new List<GameObject>();

        if (BoardManager.Instance != null )
            currentTile = BoardManager.Instance.tileList[0].GetComponent<Tile>();
    }
    private void OnEnable()
    {
        boardManagerInstance = BoardManager.Instance;
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
        currentTile = BoardManager.Instance.GetNearestTile(gameObject.transform.position);
    }

    public void OnLocalStartTurn()
    {
        GameEvents.MovePlayer += Movement;
        GameEvents.CardBuy += BuyCard;
        GameEvents.UseCard += UseCard;
        
        switch(currentTile.special)
        {
            case GameEnums.TileSpecial.None:
                break;

            case GameEnums.TileSpecial.Start:
                UseCard(cards[0]);
                break;

            case GameEnums.TileSpecial.Plus2:
                ScriptableCard[] randoms = PlayerManager.instance.GetRandomCards(2);
                foreach(var rand in randoms)
                {
                    BuyCard(rand);
                }                
                break;

            case GameEnums.TileSpecial.DrawSpecialCard:
                ScriptableCard[] specials = PlayerManager.instance.GetRandomSpecialCards(1);
                foreach (var rand in specials)
                {
                    BuyCard(rand);
                }
                break;
        }

        float offset = 0;
        float playableCards = 0;
        foreach (var card in cards)
        {
            RectTransform tr = card.GetComponent<RectTransform>();
            tr.position = new Vector3(100, 0, 0);

            card.SetActive(true);
            tr.position += new Vector3(offset, 0, 0);
            offset += 70;

            if (card.GetComponent<CardBehaviour>().color == currentTile.color || currentTile.color == GameEnums.Colors.None)
            {
                playableCards++;
            }
        }

        if (playableCards == 0)
        {

            BuyCard(PlayerManager.instance.GetRandomCards(1)[0]);
            StartCoroutine(TimerForTurnEnd());        
        }
    }
    public void OnLocalEndTurn()
    {
        GameEvents.MovePlayer -= Movement;
        GameEvents.CardBuy -= BuyCard;
        GameEvents.UseCard -= UseCard;

        foreach (var card in cards)
        {
            card.SetActive(false);
        }

        PlayerManager.instance.ismoving = false;
    }

    public void BuyCard(ScriptableCard card)
    {
        Transform canvasParent = FindObjectOfType<Canvas>().transform;
        GameObject g = Instantiate(cardPrefab, canvasParent);

        g.GetComponent<CardBehaviour>().CreateCardBehaviour(card);
        g.GetComponent<Image>().sprite = card.GetSprite();

        cards.Add(g);
        g.SetActive(false);
    }

    public void UseCard(GameObject usedCard)
    {        
        cards.Remove(usedCard);
        Destroy(usedCard);

        if (cards.Count <= 0)
            GameEvents.OnGameEnded(this);
    }

    public void SetInitialCards(int cardAmount, List<ScriptableCard> possibleCards)
    {
        Transform canvasParent = FindObjectOfType<Canvas>().transform;

        for (int i = 0; i< cardAmount; i++)
        {
            GameObject c = Instantiate(cardPrefab, canvasParent);
            int rand = Random.Range(0, possibleCards.Count);

            c.GetComponent<CardBehaviour>().CreateCardBehaviour(possibleCards[rand]);
            c.GetComponent<Image>().sprite = possibleCards[rand].GetSprite();

            cards.Add(c);

            c.SetActive(false);
        }
    }

    public void SetTile(Tile tile)
    {
        currentTile = tile;
    }

    private IEnumerator TimerForTurnEnd()
    {
        yield return new WaitForSeconds(5);
        OnLocalEndTurn();
        GameEvents.OnTurnEnded();
    }
    #region Movement
    void Movement(int movementAmount)
    {
        //Debug.Log("Called Movement in player");

        currentTileIndex += movementAmount;
        Debug.Log(boardManagerInstance);
        if(currentTileIndex >= boardManagerInstance.tileList.Count)
        {
            currentTileIndex -= boardManagerInstance.tileList.Count;
            UseCard(cards[0]);
            Debug.Log("Passed Start");
        }
        StartCoroutine(MoveToTile());
    }

    private IEnumerator MoveToTile()
    {
        while(Vector3.Distance(transform.position, boardManagerInstance.tileList[currentTileIndex].transform.position) > .01)
        {
            Camera.main.transform.LookAt(transform.position);

            transform.position = Vector3.MoveTowards(transform.position, boardManagerInstance.tileList[currentTileIndex].transform.position, Time.deltaTime * moveSpeed);

            yield return new WaitForEndOfFrame();
        }

        OnLocalEndTurn();
        GameEvents.OnTurnEnded();
    }

    public void DisableCards()
    {
        foreach(var c  in cards)
        {
            c.SetActive(false);
        }
    }
    #endregion
}

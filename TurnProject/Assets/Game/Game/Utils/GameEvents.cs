using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static event UnityAction StartGame;
    public static void OnGameStarted() => StartGame?.Invoke();

    public static event UnityAction<int> MovePlayer;
    public static void OnMovePlayer(int movementAmount) => MovePlayer?.Invoke(movementAmount);

    public static event UnityAction TurnStart;
    public static void OnTurnStarted() => TurnStart?.Invoke();

    public static event UnityAction TurnEnd;
    public static void OnTurnEnded() => TurnEnd?.Invoke();

    public static event UnityAction CardBuy;
    public static void OnCardBought() => CardBuy?.Invoke();

    public static event UnityAction UseCard;
    public static void OnCardUsed() => UseCard?.Invoke();
}

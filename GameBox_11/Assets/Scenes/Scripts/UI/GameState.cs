using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameStates CurrentState;
    public enum GameStates
    {
        Pause,
        Countdown,
        End,
        Menu,
        Game
    }

    private void Start()
    {
        CurrentState = GameStates.Menu;
    }
}

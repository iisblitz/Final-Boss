using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChange;


    void Awake(){
        Instance = this;
    }

    void Start() { 
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState){
        State = newState;

        switch(newState){
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Intro:
                HandleIntro();
                break;
            case GameState.Level1:
                HandleLevel1();
                break;
            case GameState.Level2:
                HandleLevel2();
                break;
            case GameState.Level3:
                HandleLevel3();
                break;
            case GameState.Win:
                HandleWin();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChange?.Invoke(newState);
    }
    private void HandleMenu() { }
    private void HandleIntro() { }
    private void HandleLevel1() { }
    private void HandleLevel2() { }
    private void HandleLevel3() { }
    private void HandleWin() { }
    private void HandleLose() { }
}
public enum GameState
{
    Menu,
    Intro,
    Level1,
    Level2,
    Level3,
    Win,
    Lose
}
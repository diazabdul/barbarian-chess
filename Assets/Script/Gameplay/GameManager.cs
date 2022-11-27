using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            //case GameState.SpawnHeroes2:
            //    UnitManager.Instance.SpawnHeroes2();
            //    break;
            //case GameState.SpawnObjective:
            //    UnitManager.Instance.SpawnObjective();
            //    break;
            //case GameState.SpawnObstacle:
            //    UnitManager.Instance.SpawnObstacle();
            //    break;
            //case GameState.SpawnHole:
            //    UnitManager.Instance.SpawnHole();
            //    break;
            //case GameState.MovementHeroes:
            //    UnitManager.Instance.MoveHeroes();
            //    break;
            case GameState.HeroesTurn:
                break;
            case GameState.SpawnTurn:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnTurn = 2,
    HeroesTurn = 3,
    EnemiesTurn = 4
}
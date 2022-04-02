using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : BaseGameEntity
{
    private StateMachine<Game> stateMachine;
    private MyGrid grid;

    public void Initialize()
    {
        RegisterEntity((int)Entities.GAME_MANAGER);
        stateMachine = new StateMachine<Game>(this);
        stateMachine.currentState = GameStart.Instance;
        stateMachine.currentState.Enter(this);
    }

    public void StartGame()
    {
        grid = new MyGrid(25, 20);
        
        ContainersManager.Instance.DestroyContainers();
        ContainersManager.Instance.InstantiateContainers();

        GameInitializer.Instance.CreateSpaceCells(grid);
        GameInitializer.Instance.CreateCityCells(grid);
        GameInitializer.Instance.CreateBakcgroundCells(grid);
        GameInitializer.Instance.CreateBunkers();
        GameInitializer.Instance.CreateEnemies(grid);
        ChangeState(GameReset.Instance);
    }

    public void ResetGame()
    {
        ChangeState(GamePlay.Instance);
    }

    public void ChangeState(State<Game> newState)
    {
        stateMachine.ChangeState(newState);
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return stateMachine.HandleMessage(telegram);
    }

    public override void Update()
    {
        base.Update();
        stateMachine.Update();
    }
}

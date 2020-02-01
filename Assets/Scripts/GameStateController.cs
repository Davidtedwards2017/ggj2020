using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class GameStateController : Singleton<GameStateController>
{
    public enum GameStates
    {
        init,
        title,
        intro,
        playing,
        finished,
    }

    public StateMachine<GameStates> statectrl;

    // Start is called before the first frame update
    void Start()
    {
        statectrl = StateMachine<GameStates>.Initialize(this);
        statectrl.ChangeState(GameStates.init);
    }

    
    public void init_Enter()
    {

    }

    public void intro_Enter()
    {

    }

    public void title_Enter()
    {

    }

    public void playing_Enter()
    {

    }
    
    public void playing_Exit()
    {

    }

    public void finished_Enter()
    {

    }
}

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

    public bool CanControl = false;

    public StateMachine<GameStates> statectrl;

    // Start is called before the first frame update
    void Start()
    {
        statectrl = StateMachine<GameStates>.Initialize(this);
        statectrl.ChangeState(GameStates.init);
    }
    
    public void init_Enter()
    {
        statectrl.ChangeState(GameStates.title);
    }
    
    public IEnumerator title_Enter()
    {
        yield return new WaitUntil(() => Input.anyKeyDown);
        statectrl.ChangeState(GameStates.intro);
    }

    public IEnumerator intro_Enter()
    {
        yield return new WaitForSeconds(1.0f);
        statectrl.ChangeState(GameStates.playing);
    }

    public void playing_Enter()
    {
        CanControl = true;
    }

    public void playing_Exit()
    {
        CanControl = false;
    }
    

    public void finished_Enter()
    {

    }
}

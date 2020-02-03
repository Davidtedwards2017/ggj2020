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
        cleanup,
    }

    public SplashScreenModule StartSplashScreen;
    public SplashScreenModule EndSplashScreen;

    public StageController StageController;
    public AudioSource mySource;
    [SerializeField] AudioClip birdClip;
    [SerializeField] AudioClip trackClip;

    public bool CanControl = false;

    public StateMachine<GameStates> statectrl;

    // Start is called before the first frame update
    void Start()
    {

        mySource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        statectrl = StateMachine<GameStates>.Initialize(this);
        statectrl.ChangeState(GameStates.init);
    }
    
    public void init_Enter()
    {
        statectrl.ChangeState(GameStates.title);
    }
    
    public IEnumerator title_Enter()
    {
        StageController.SpawnStage();
        yield return (StageController.BreakingSequence());
        StartSplashScreen.Active = true;
        yield return new WaitUntil(() => Input.anyKeyDown);
        statectrl.ChangeState(GameStates.playing);
    }

    public void title_Exit()
    {
        StartSplashScreen.Active = false;
    }

    public void playing_Enter()
    {
        StageController.stageInstance.Init();
        CanControl = true;
        mySource.Stop();
        mySource.clip = trackClip;
        mySource.Play();
    }

    public void playing_Exit()
    {
        CanControl = false;
    }
    
    public void Win()
    {
        statectrl.ChangeState(GameStates.finished);
    }

    public IEnumerator finished_Enter()
    {
        EndSplashScreen.Active = true;
        yield return new WaitForSeconds(5.0f);
        statectrl.ChangeState(GameStates.cleanup);
    }

    public void finished_Exit()
    {
        EndSplashScreen.Active = false;
    }

    public void cleanup_Enter()
    {
        Application.LoadLevel(Application.loadedLevel);

        statectrl.ChangeState(GameStates.title);
    }
}

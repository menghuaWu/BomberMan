using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
  
    /// <summary>
    /// This class is Game Manager to control all the event in the Game
    /// 
    /// <Author> Wumenghua </Author>
    /// </summary>

    public Text TimeTxt;
    public int CountTimer;
    public Text OverShow;

    public static GameManager _instance;



    /// <summary>
    /// State enum with this Game State
    /// </summary>
    public enum State
    {
        DELAY,
        PLAY,
        PAUSE,
        GAMEOVER
    }
    State _state;

    private void Awake()
    {
        _state = State.DELAY;
        if (_instance == null)
        {
            _instance = this;
        }
        

    }

    private void Start()
    {
        SetGameState(_state);

        CountTimer = 3;
        TimeTxt.text = string.Empty;
    }

    /// <summary>
    /// This funtion is for other script to use for set state
    /// </summary>
    /// <param name="state">Input the state what you want to change</param>
    public void SetGameState(State state)
    {
        switch (state)
        {
            case State.DELAY:
                _DelayGame();
                break;
            case State.PLAY:
                _PlayimgTheGame();
                break;
            case State.PAUSE:
                _PauseTheGame();
                break;
            case State.GAMEOVER:
                _GameIsOver();
                break;
            
        }

    }

    /// <summary>
    /// This funtion is for other script to get current state
    /// </summary>
    /// <returns>Can return current state</returns>
    public State _GetGameState()
    {
        return _state;
    }

    /// <summary>
    /// This funtion is use to delay game when the scene active
    /// </summary>
    void _DelayGame()
    {
        OverShow.text = string.Empty;
        StartCoroutine(CountTime());
    }

    /// <summary>
    /// This funtion is use to play the game after the count down time is 0 and the text show "GO!"
    /// </summary>
    void _PlayimgTheGame()
    {
        OverShow.text = string.Empty;
        TimeTxt.text = string.Empty;

    }

    /// <summary>
    /// This funtion is use to pause the time when the player click pause buttom
    /// </summary>
    void _PauseTheGame()
    {

    }

    /// <summary>
    /// This funtion is after one of the players is die then show game over message
    /// </summary>
    void _GameIsOver()
    {
        StartCoroutine("OverShowMessage");
        
    }



    /// <summary>
    /// This IEnumerator is count down timer
    /// </summary>
    /// <returns></returns>
    IEnumerator CountTime()
    {      
        while (CountTimer>0)
        {
            TimeTxt.text = CountTimer + "";
            CountTimer--;
            if (CountTimer == 0)
            {
                yield return new WaitForSeconds(1f);
                TimeTxt.text ="GO!";
                yield return new WaitForSeconds(1f);
                _state = State.PLAY;
                SetGameState(_state);

            }
            yield return new WaitForSeconds(1f);
        }
    }


    IEnumerator OverShowMessage()
    {
        yield return new WaitForSeconds(2f);
        OverShow.text = "GameOver";
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;

public partial class GameStateFSM : MeFsm 
{
    public class MainMenuState : MeFsmState<GameStateFSM>
    {
        string scene = "MenuScreen";

        protected override void EnterState()
        {
            if(SceneManager.GetActiveScene().name != scene) 
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}


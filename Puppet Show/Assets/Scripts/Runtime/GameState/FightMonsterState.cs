using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;

public partial class GameStateFSM : MeFsm 
{
    public class FightMonsterState : MeFsmState<GameStateFSM>
    {
        string scene = "SampleScene";

        protected override void EnterState()
        {
            if(SceneManager.GetActiveScene().name != scene) 
            {
                SceneManager.LoadScene(scene);
            }
        }
        


    }
}


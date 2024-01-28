using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;

public partial class GameStateFSM : MeFsm 
{
    public class MonsterDefeatedState : MeFsmState<GameStateFSM>
    {
        protected override void EnterState()
        {
            //do stuff
            base.EnterState();
        }
        protected override void ExitState()
        {
            //cleanup
            base.ExitState();
        }
    }
}


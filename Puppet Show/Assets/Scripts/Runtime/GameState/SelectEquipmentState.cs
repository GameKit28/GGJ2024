using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;

public partial class GameStateFSM : MeFsm 
{
    public class SelectEquipmentState : MeFsmState<GameStateFSM>
    {
        protected override void EnterState()
        {
            //Load the scene
        }
    }
}


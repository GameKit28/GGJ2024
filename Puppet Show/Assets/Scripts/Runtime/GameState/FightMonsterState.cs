using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;

public partial class GameStateFSM : MeFsm 
{
    public class FightMonsterState : SceneLoadingState
    {
        protected override string sceneToLoad => "SampleScene";
    }
}


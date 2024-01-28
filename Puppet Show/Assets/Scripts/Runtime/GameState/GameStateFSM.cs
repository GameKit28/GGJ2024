using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;

public partial class GameStateFSM : MeFsm
{
    public static GameStateFSM Instance = null;

    protected override void Awake(){
        if(Instance == null){
            Instance = this;
            GameObject.DontDestroyOnLoad(this);
            base.Awake();
        }else{
            GameObject.Destroy(this);
        }
    }
}

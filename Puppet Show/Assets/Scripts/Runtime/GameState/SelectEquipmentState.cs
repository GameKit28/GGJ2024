using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GameStateFSM : MeFsm 
{
    public class SelectEquipmentState : SceneLoadingState
    {
        protected override string sceneToLoad => "Inventory";

        protected override void OnSceneLoaded()
        {
            GameObject.Find("ReadyButton").GetComponent<Button>().onClick.AddListener(OnReadyButtonClick);
        }

        private void OnReadyButtonClick(){
            SwapState<FightMonsterState>();
        }
    }
}


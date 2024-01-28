using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GameStateFSM : MeFsm 
{
    public class SelectEquipmentState : MeFsmState<GameStateFSM>
    {
        string scene = "Inventory";

        protected override void EnterState()
        {
            if(SceneManager.GetActiveScene().name != scene) 
            {
                SceneManager.LoadScene(scene);
            }
            GameObject.Find("ReadyButton").GetComponent<Button>().onClick.AddListener(OnReadyButtonClick);
        }

        private void OnReadyButtonClick(){
            SwapState<FightMonsterState>();
        }
    }
}


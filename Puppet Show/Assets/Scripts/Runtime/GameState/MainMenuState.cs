using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            Debug.Log("Load Scene Completed");
            GameObject.Find("StartGameButton").GetComponent<Button>().onClick.AddListener(OnStartGameClicked);
        }

        private void OnStartGameClicked(){
            Debug.Log("StartGameButton clicked");
            SwapState<SelectEquipmentState>();
        }
    }
}


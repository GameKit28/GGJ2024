using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GameStateFSM : MeFsm 
{
    public class MainMenuState : SceneLoadingState
    {
        protected override string sceneToLoad => "MenuScreen";

        protected override void OnSceneLoaded()
        {
            GameObject.Find("StartGameButton").GetComponent<Button>().onClick.AddListener(OnStartGameClicked);
        }

        private void OnStartGameClicked(){
            SwapState<SelectEquipmentState>();
        }
    }
}


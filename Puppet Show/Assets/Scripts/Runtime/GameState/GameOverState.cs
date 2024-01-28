using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GameStateFSM : MeFsm 
{
    public class GameOverState : SceneLoadingState
    {
        protected override string sceneToLoad => "GameOver";

        protected override void OnSceneLoaded()
        {
            GameObject.Find("Main Menu").GetComponent<Button>().onClick.AddListener(OnMainMenuClicked);
        }

        private void OnMainMenuClicked(){
            SwapState<MainMenuState>();
        }
    }
}


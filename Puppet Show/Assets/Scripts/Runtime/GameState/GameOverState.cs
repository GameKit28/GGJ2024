using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeEngine.FsmManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public partial class GameStateFSM : MeFsm 
{
    public class GameOverState : MeFsmState<GameStateFSM>
    {

        string scene = "GameOver";

        protected override void EnterState()
        {
            if (SceneManager.GetActiveScene().name != scene)
            {
                SceneManager.LoadScene(scene);
            }
            GameObject.Find("Main Menu").GetComponent<Button>().onClick.AddListener(OnReadyButtonClick);
        }

        private void OnReadyButtonClick()
        {
            SwapState<MainMenuState>();
        }
    }
}


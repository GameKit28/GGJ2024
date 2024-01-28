using UnityEngine;
using MeEngine.FsmManagement;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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

    public abstract class SceneLoadingState : MeFsmState<GameStateFSM> 
    {
        protected abstract string sceneToLoad { get;}

        protected override void EnterState()
        {
            if(SceneManager.GetActiveScene().name != sceneToLoad) 
            {
                SceneManager.sceneLoaded += OnSceneLoadedEvent;
                SceneManager.LoadScene(sceneToLoad);
            }else{
                OnSceneLoaded();
            }
        }

        private void OnSceneLoadedEvent(Scene scene, LoadSceneMode mode){
            OnSceneLoaded();
        }

        protected virtual void OnSceneLoaded(){}

        protected override void ExitState()
        {
            SceneManager.sceneLoaded -= OnSceneLoadedEvent;
        }
    }

    public void OnEnemyDeath()
    {

        EnemySpawner spawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        GameObject enemy = spawner.GetCurrentEnemy();
        enemy.GetComponent<EnemyMovement>().RunAway();
        StartCoroutine(WaitAndDestroyEnemy(enemy, spawner));
    }
    public void OnPlayerDeath()
    {
        EnemySpawner spawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        GameObject.FindWithTag("Curtains").GetComponent<MoveObject>().enabled = true;
        StartCoroutine(WaitAndDestroy<GameOverState>(GameObject.FindWithTag("Player"), spawner, 1.2f));
    }
    private IEnumerator WaitAndDestroyEnemy(GameObject enemy, EnemySpawner spawner)
    {
        while(enemy.transform.position.x < 20f)
        {
            yield return new WaitForEndOfFrame();
        }
        spawner.RemoveEnemy();
        SwapState<MonsterDefeatedState>();
    }
    private IEnumerator WaitAndDestroy<SType>(GameObject obj, EnemySpawner spawner, float time) where SType : MeEngine.FsmManagement.MeFsmStateBase
    {
        float timer = 0;

        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        spawner.RemoveEnemy();
        Destroy(obj);
        SwapState<SType>();
    }
}

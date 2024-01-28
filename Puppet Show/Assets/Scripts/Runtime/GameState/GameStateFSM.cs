using UnityEngine;
using MeEngine.FsmManagement;
using System.Collections;

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

    public void OnEnemyDeath()
    {

        EnemySpawner spawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        GameObject enemy = spawner.GetCurrentEnemy();
        enemy.GetComponent<EnemyMovement>().RunAway();
        StartCoroutine(WaitAndDestroyEnemy(enemy, spawner));
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
}

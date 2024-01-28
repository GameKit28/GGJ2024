using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float strength;
    [SerializeField] private bool spawn;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject healthBarBannersPrefab;
    [SerializeField] private EnemyBaseline enemy;
    [SerializeField] private GameObject currentEnemy;
    [SerializeField] private GameObject currentHealthBars;
    private void Update()
    {
        if(spawn)
        {
            spawn= false;
            GenerateEnemy(strength);
        }
    }
    public void GenerateEnemy(float strengthModifier)
    {
        if(currentEnemy != null)
        {
            Destroy(currentEnemy);
        }
        if(currentHealthBars != null)
        {
            Destroy(currentHealthBars);
        }
        currentEnemy = Instantiate(enemyPrefab);
        
        EnemyHealth enemyHealth = currentEnemy.GetComponent<EnemyHealth>();
        enemyHealth.SetHealth(enemy.GenerateStats(strengthModifier));
        SpriteRenderer renderer = currentEnemy.GetComponent<SpriteRenderer>();
        renderer.sprite = enemy.EnemySprite;
        currentEnemy.transform.position = enemy.startingPos;
        currentEnemy.transform.GetChild(0).transform.localPosition = enemy.damageIndicatorPosition;
        currentHealthBars = Instantiate(healthBarBannersPrefab);
        enemyHealth.SetHealthBarRender(currentHealthBars.GetComponent<HealthBarRenderer>());
        enemyHealth.StartEnemy();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HealthBarRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer intimidateBar;
    [SerializeField] private SpriteRenderer disgustBar;
    [SerializeField] private SpriteRenderer calmBar;
    [SerializeField] private SpriteRenderer dazzleBar;
    [SerializeField] private SpriteRenderer irritateBar;
    [SerializeField] private float maxBannerHeight = 6;
    [SerializeField] private float animationSpeed;
    private EnemyHealth enemyHealth;

    private float highestHealth;
    private int highestHealthIndex;
    private float[] healthBars;
    private bool rendererSetup = false;
    // Start is called before the first frame update

    private void Update()
    {
        if (rendererSetup)
        {
            float[] newHealth = enemyHealth.getHealthBars();
            healthBars[0] = Mathf.Lerp(healthBars[0], newHealth[0], animationSpeed * Time.deltaTime);
            healthBars[1] = Mathf.Lerp(healthBars[1], newHealth[1], animationSpeed * Time.deltaTime);
            healthBars[2] = Mathf.Lerp(healthBars[2], newHealth[2], animationSpeed * Time.deltaTime);
            healthBars[3] = Mathf.Lerp(healthBars[3], newHealth[3], animationSpeed * Time.deltaTime);
            healthBars[4] = Mathf.Lerp(healthBars[4], newHealth[4], animationSpeed * Time.deltaTime);
            RenderHealthBars();
        }
    }

    public void SetupRenderer(EnemyHealth enemyHealth)
    {
        this.enemyHealth =  enemyHealth;
        healthBars = enemyHealth.getHealthBars();
        highestHealth = healthBars[0];
        highestHealthIndex = 0;
        for(int i = 1; i < healthBars.Length; i++)
        {
            
            if (healthBars[i] > highestHealth)
            {
                highestHealth = healthBars[i];
                highestHealthIndex = i;
            }
        }
        RenderHealthBars();
        rendererSetup = true;
    }

    private void RenderHealthBars()
    {
        intimidateBar.size = new Vector2(2f, maxBannerHeight * (healthBars[0] / healthBars[highestHealthIndex]));
        disgustBar.size = new Vector2(2f, maxBannerHeight * (healthBars[1] / healthBars[highestHealthIndex]));
        calmBar.size = new Vector2(2f, maxBannerHeight * (healthBars[2] / healthBars[highestHealthIndex]));
        dazzleBar.size = new Vector2(2f, maxBannerHeight * (healthBars[3] / healthBars[highestHealthIndex]));
        irritateBar.size = new Vector2(2f, maxBannerHeight * (healthBars[4] / healthBars[highestHealthIndex]));
    }

}

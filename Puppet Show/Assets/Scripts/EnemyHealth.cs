using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Health Bars")]
    [SerializeField] private float intimidate;
    [SerializeField] private float disgust;
    [SerializeField] private float calm;
    [SerializeField] private float dazzle;
    [SerializeField] private float irritate;
    [SerializeField] private HealthBarRenderer healthBarRenderer;
    [SerializeField] private GameObject damageIndicatorPrefab;
    [SerializeField] private Transform damageIndicatorOrigin;

    [Header("Time Dialation")]
    [SerializeField] private float dialationTime;
    [SerializeField] private AnimationCurve dialationEffectOverTime;

    private void Start()
    {
        healthBarRenderer.SetupRenderer(this);
    }
    private void Update()
    {

    }

    public void DealDamage(float damageAmmount, IDamageable.DamageType damageType)
    {
        Color color = IDamageable.GetColor(damageType);
        Debug.Log(color);
        switch (damageType)
        {
            
            case IDamageable.DamageType.Intimidate:
                DamageEnemy(damageAmmount,ref intimidate, color);
                break;
            case IDamageable.DamageType.Disgust:
                DamageEnemy(damageAmmount, ref disgust, color);
                break;
            case IDamageable.DamageType.Calm:
                DamageEnemy(damageAmmount, ref calm, color);
                break;
            case IDamageable.DamageType.Dazzle:
                DamageEnemy(damageAmmount, ref dazzle, color);
                break;
            case IDamageable.DamageType.Irritate:
                DamageEnemy(damageAmmount, ref irritate, color);
                break;
            default:
                break;
        }
    }
    private void DamageEnemy(float ammount, ref float healthPool, Color textColor)
    {
        StartCoroutine(WarpTime());
        healthPool -= Mathf.Abs(ammount);
        GameObject newIndicator = Instantiate(damageIndicatorPrefab);
        TextMeshPro text = newIndicator.GetComponent<TextMeshPro>();
        text.text = ammount.ToString();
        text.color = textColor;
        DamageIndicatorMovement movementBehavior = newIndicator.GetComponent<DamageIndicatorMovement>();
        movementBehavior.SetupMovement(damageIndicatorOrigin);
        if(healthPool <= 0)
        {
            Debug.Log("Dead");
            //Insert Death Logic Here
        }
    }
    
    private IEnumerator WarpTime()
    {
        float timer = 0;
        float timeScale = 1;
        while(timer < dialationTime)
        {
            timer += Time.deltaTime;
            timeScale = dialationEffectOverTime.Evaluate(timer / dialationTime);
            if(timeScale < 0.1f)
            {
                timeScale = 0.1f;
            }
            Time.timeScale = timeScale;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 1.0f;
        
    }

    public float[] getHealthBars()
    {
        float[] healthBars = new float[5];
        healthBars[0] = intimidate;
        healthBars[1] = disgust;
        healthBars[2] = calm;
        healthBars[3] = dazzle;
        healthBars[4] = irritate;
        return healthBars;
    }
}

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
    [SerializeField] private Color intimidateColor;
    [SerializeField] private Color disgustColor;
    [SerializeField] private Color calmColor;
    [SerializeField] private Color dazzleColor;
    [SerializeField] private Color irritateColor;
    [SerializeField] private GameObject damageIndicatorPrefab;
    [SerializeField] private Transform damageIndicatorOrigin;

    [Header("Time Dialation")]
    [SerializeField] private float dialationTime;
    [SerializeField] private AnimationCurve dialationEffectOverTime;


    private void Update()
    {

    }

    public void DealDamage(float damageAmmount, IDamageable.DamageType damageType)
    {
        switch (damageType)
        {
            case IDamageable.DamageType.Intimidate:
                DamageEnemy(damageAmmount,ref intimidate, intimidateColor);
                break;
            case IDamageable.DamageType.Disgust:
                DamageEnemy(damageAmmount, ref disgust, disgustColor);
                break;
            case IDamageable.DamageType.Calm:
                DamageEnemy(damageAmmount, ref calm, calmColor);
                break;
            case IDamageable.DamageType.Dazzle:
                DamageEnemy(damageAmmount, ref dazzle, dazzleColor);
                break;
            case IDamageable.DamageType.Irritate:
                DamageEnemy(damageAmmount, ref irritate, irritateColor);
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
            Debug.Log(timeScale);
            Time.timeScale = timeScale;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 1.0f;
        
    }
}

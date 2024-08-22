using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    private bool hasHit = false;
    private bool isDead = false;

    [Header("Hit Animation Duration: ")]
    [SerializeField] private float hitAnimationDuration;
    [Header("Enemy's Health Bar: ")]
    [SerializeField] private Slider enemyHealthBar;
    [Header("Enemy's Max Health: ")]
    [SerializeField] private float maxHealth;
    [Header("Enemy's Data")]
    [SerializeField] private EnemyData enemyData;
    [Header("Enemy's Spawner: ")]
    [SerializeField] private EnemySpawner enemySpawner;
    [Header("Enemy's Name:")]
    [SerializeField] private TextMeshProUGUI enemyName;

    [Header("Despawn Delay: ")]
    [SerializeField] private float delay;
    private float currentHealth;
    private void OnEnable()
    {
        isDead = false;
        SetHealth();  
    }
    private void SetHealth()
    {
        maxHealth = enemyData.EnemyHealth;
        currentHealth = maxHealth;
        SetHealthBar();
    }
    private void SetHealthBar()
    {
        enemyHealthBar.maxValue = maxHealth;
        enemyHealthBar.value = currentHealth;
    }
    public void TakeDamage(float damage)
    {
        if(!isDead)
        {
            if (!hasHit)
            {
                StartCoroutine(HitAnimation());
                
            }

            if (enemyHealthBar.value > 0)
            {
                DecreaseHealth(damage);
            }
        }
    }

    private IEnumerator HitAnimation()
    {
        hasHit = true;
        yield return new WaitForSeconds(hitAnimationDuration);
        hasHit = false;
    }

    private void DecreaseHealth(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            EnemyDead();
        }
        enemyHealthBar.value = currentHealth;
    }
    private void EnemyDead()
    {
        isDead = true;
        enemyData.IncreaseHealth();
        enemySpawner.SpawnEnemy();
        StartCoroutine(Despawn());
    }
    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
    public bool HasHit()
    {
        return hasHit;
    }
    public bool IsDead()
    {
        return isDead;
    }
}

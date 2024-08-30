using System.Collections;
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

    [Header("Enemy's Health bar percentage:")]
    [SerializeField] private TextMeshProUGUI percentageText;

    [Header("Despawn Delay: ")]
    [SerializeField] private float delay;
    [SerializeField] private TextMeshProUGUI killCountText;
    private float currentHealth;

    int killCount;
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
        UpdateCurrentHealth();
    }
    private void UpdateCurrentHealth()
    {
        enemyHealthBar.value = currentHealth;
        UpdateHealthPercentage();
    }
    private void UpdateHealthPercentage()
    {
        float healthPercentage = (currentHealth / maxHealth) * 100;
        percentageText.text = healthPercentage.ToString("F1") + "%";
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
            currentHealth = 0; // to avoid negative value //
            EnemyDead();
        }
        UpdateCurrentHealth();
    }
    private void EnemyDead()
    {
        isDead = true;
        UpdateKillCount();
        enemyData.IncreaseHealth();
        enemySpawner.SpawnEnemy();
        StartCoroutine(Despawn());
    }
    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(delay); // wait for the death animation to finished before despawning or deactivating //
        gameObject.SetActive(false);
    }
    private void UpdateKillCount()
    {
        killCount++;
        killCountText.text = "X: " + killCount.ToString();
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

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeroAttack : MonoBehaviour
{
    private bool isAttacking = false;
    private int attackForm;
    private EnemyStatus enemyStatus;

    [Header("Enemy Objects: ")]
    [SerializeField] private GameObject[] Enemies;

    [Header("Hero's Attack Durations: ")]
    [SerializeField] private float attack1_Duration;
    [SerializeField] private float attack2_Duration;
    [SerializeField] private float attack3_Duration;
    [SerializeField] private float attackSP_Duration;

    [Header("Hero's Attack Damages: ")]
    [SerializeField] private float attack1_Damage;
    [SerializeField] private float attack2_Damage;
    [SerializeField] private float attack3_Damage;
    [SerializeField] private float attackSP_Damage;

    [Header("Hero's Delay per Attack: ")]
    [SerializeField] private float delay;

    [Header("Hero's Speed Action: ")]
    [SerializeField] private float actionSpeed;
    [SerializeField] private Slider actionIndicator;

    
    private void Update()
    {
        for (int i = 0; i < Enemies.Length; i++) // Check the Array //
        {
            if (Enemies[i].activeSelf) // Find if there are active Enemies //
            {
                enemyStatus = Enemies[i].GetComponent<EnemyStatus>(); // Get the Enemie's Status component //
                if (actionIndicator.value < actionIndicator.maxValue && !enemyStatus.IsDead()) // increase combat readiness when it is not equal to max and if the enemy is no dead //
                {
                    IncrementAction();
                }
                if (!enemyStatus.IsDead() && actionIndicator.value == actionIndicator.maxValue && !isAttacking) // Attack if it's not dead //
                {
                    StartCoroutine(Attack());
                }
            }
        }
    }
    private void IncrementAction()
    {
        actionIndicator.value += (actionSpeed * Time.deltaTime);
    }
    private void ResetAction()
    {
        // when the action value reached max value or when the player attacks, it will reset the indicator //
        actionIndicator.value = 0;
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        int ranInd = Random.Range(1, 5); // Generates a random number for attack forms //
        attackForm = ranInd;

        float damage = 0;
        float duration = 0;
        switch (attackForm)
        {
            case 1:
                damage = attack1_Damage; 
                duration = attack1_Duration;
                break;
            case 2:
                damage = attack2_Damage;
                duration = attack2_Duration;
                break;
            case 3:
                damage = attack3_Damage;
                duration = attack3_Duration;
                break;
            case 4:
                damage = attackSP_Damage;
                duration = attackSP_Duration;
                break;
        }
        float elapsedTime = 0f;
        while (elapsedTime < duration) // keep damaging the enemy while attacking //
        {
            enemyStatus.TakeDamage(damage * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ResetAction();
        attackForm = 0;
        yield return new WaitForSeconds(delay);
        isAttacking = false;
    }
    public int AttackForm()
    {
        return attackForm;
    }
}

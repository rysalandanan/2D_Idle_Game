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

    [Header("Hero's Attack Damages: ")]
    [SerializeField] private float attack1_Damage;
    [SerializeField] private float attack2_Damage;
    [SerializeField] private float attack3_Damage;

    [Header("Hero's Delay per Attack: ")]
    [SerializeField] private float delay;

    [Header("Hero's Speed Action: ")]
    [SerializeField] private float actionSpeed;
    [SerializeField] private Slider actionIndicator;
    
    private void Update()
    {
        actionIndicator.value += actionSpeed + Time.deltaTime;
        Debug.Log(actionSpeed);
        for (int i = 0; i < Enemies.Length; i++) // Check the Array //
        {
            if (Enemies[i].activeSelf && !isAttacking) // Find if there are active Enemies //
            {
                enemyStatus = Enemies[i].GetComponent<EnemyStatus>(); // Get the Enemie's Status component //
                
                if (!enemyStatus.IsDead()) // Attack if it's not dead //
                {
                    StartCoroutine(Attack());
                }
            }
        }
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        int ranInd = Random.Range(1, 4); // Generates a random number for attack forms //
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
        }
        float elapsedTime = 0f;
        while (elapsedTime < duration) // keep damaging the enemy while attacking //
        {
            enemyStatus.TakeDamage(damage);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        attackForm = 0;
        yield return new WaitForSeconds(delay);
        isAttacking = false;
    }
    public int AttackForm()
    {
        return attackForm;
    }
}

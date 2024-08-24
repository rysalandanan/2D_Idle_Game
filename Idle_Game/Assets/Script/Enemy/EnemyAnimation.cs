using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private static readonly int State = Animator.StringToHash("state");
    private enum CharacterState { idle, hit, death}
    private EnemyStatus enemyStatus
        ;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyStatus = GetComponent<EnemyStatus>();
    }
    private void Update()
    {
        CharacterState state;
        if (enemyStatus.HasHit())
        {
            state = CharacterState.hit;
        }
        else if(enemyStatus.IsDead())
        {
            state = CharacterState.death;
        }
        else
        {
            state = CharacterState.idle;
        }
        animator.SetInteger(State, (int)state);
    }
}

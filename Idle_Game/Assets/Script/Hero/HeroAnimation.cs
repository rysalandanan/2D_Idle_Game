using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    private Animator animator;
    private static readonly int State = Animator.StringToHash("state");
    private enum CharacterState { idle, att1, att2, att3, sp }
    private HeroAttack heroAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        heroAttack = GetComponent<HeroAttack>();
    }
    private void Update()
    {
        CharacterState state;
        int currentAttackForm = heroAttack.AttackForm();

        switch (currentAttackForm)
        {
            case 1:
                state = CharacterState.att1;
                break;
            case 2: 
                state = CharacterState.att2;
                break;
            case 3:
                state = CharacterState.att3;
                break;
            case 4:
                state = CharacterState.sp;
                break;
            default:
                state = CharacterState.idle;
                break;
        }
        animator.SetInteger(State, (int)state);
    }
}

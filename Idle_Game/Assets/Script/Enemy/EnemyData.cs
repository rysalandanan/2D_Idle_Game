using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private float enemyHealth = 10000; // ten thousand by default //
    private float increaseHealthValue = 250f;

    public void IncreaseHealth() // health increases by 250 everytime a monster died //
    {
        enemyHealth += increaseHealthValue;
        Debug.Log(enemyHealth);
    }
    public float EnemyHealth
    {
        get { return enemyHealth; }
    }

}

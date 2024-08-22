using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyName : MonoBehaviour
{
    [Header("Enemy's Name:")]
    [SerializeField] private TextMeshProUGUI enemyName;

    private void OnEnable()
    {
        SetName();
    }
    private void SetName()
    {
        enemyName.text = "";
        int randomFN = Random.Range(0, enemyNamesFirst.Count);
        int randomLN = Random.Range(0, enemyNamesLast.Count);
        int randomCN = Random.Range(1, 3);
        if(randomCN == 1)
        {
            //only Name
            enemyName.text = enemyNamesFirst[randomFN];
        }
        else
        {
            //with Last Name
            enemyName.text = enemyNamesFirst[randomFN] + enemyNamesLast[randomLN];
        }
    }
    private List<string> enemyNamesFirst = new List<string>
    {
        "Urgo",
        "Bronx",
        "Siggun",
        "Ir' Galloz",
        "Maggur",
        "Goran",
        "Brerzok",
        "Kolvuth",
        "drog'thog",
        "Kargomath",
        "Talmuth",
        "Kirraz",
        "Xerrath",
        "Ragamon",
        "Iken",
        "Xorag"
    };
    private List<string> enemyNamesLast = new List<string>
    {
        " the Defiler",
        " the Traitor",
        " the Warchief ",
        " the Warlord ",
        " the Corrupted Imperator",
        " the Pilgrim",
        " the Unheard",
        " the Sinister",
        " the Corrupt",
        " the Enshrouded",
        " of Crimson Legions",
        " of Dread Legions",
        " the Banished",
        " the Malicious",
        " the Doomed",
        " of Blood Towers",
        " the Decadent",
        " the Foul"
    };
}

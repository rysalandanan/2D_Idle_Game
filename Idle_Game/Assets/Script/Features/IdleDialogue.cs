using TMPro;
using UnityEngine;

public class IdleDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idleText;
    [SerializeField] private string[] idleLines;
    [SerializeField] private GameObject dialogueBox;

    private void Start()
    {
        dialogueBox.SetActive(false);
    }
    public void OpenCloseDialogue()
    {
        if (dialogueBox.activeSelf)
        {
            CloseDialogue();
        }
        else
        {
            OpenDialogue();
        }

    }
    private void OpenDialogue()
    {
        idleText.text = null; // reset the text
        dialogueBox.SetActive(true);
        int randomIndex = Random.Range(0, idleLines.Length);
        idleText.text = idleLines[randomIndex];
    }
    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
    }
}

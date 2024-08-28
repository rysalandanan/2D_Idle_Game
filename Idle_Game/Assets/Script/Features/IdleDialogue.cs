using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdleDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idleText;
    [SerializeField] private string[] idleLines;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Image imageHolder;
    [SerializeField] private Sprite selectedImage;

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
        SetImage();
    }
    private void SetImage()
    {
        imageHolder.sprite = selectedImage;
    }
    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
    }
}

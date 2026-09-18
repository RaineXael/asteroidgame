using UnityEngine;
using TMPro;
using System.Collections;
public class Textbox : MonoBehaviour
{
    private const float charReadTime = 0.03f;
    private const float messageFinalDisplayTime = 5f;

    public TMP_Text dialogText;
    private int charsDisplayed;
    private int messageLength;

    private bool isReading;

    public void Update()
    {
     
    }

    void Start()
    {
        //Test readout. This is how we read strings. Portrait WIP.
        StartCoroutine(ReadMessage("STOP! You've violated the law! Pay the court a fine or serve your sentence. Your stolen goods are now forfeit."));
    }

    IEnumerator ReadMessage(string message)
    {
        //We set the full message into the text to render all the text at once
        //to avoid the abrupt wraps 
        dialogText.text = message;
        dialogText.maxVisibleCharacters = 0;
        isReading = true;
        while (dialogText.maxVisibleCharacters < message.Length)
        {
            dialogText.maxVisibleCharacters++;
            yield return new WaitForSeconds(charReadTime);
        }
        isReading = false;
    }
}

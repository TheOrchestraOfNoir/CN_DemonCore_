using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterManager : MonoBehaviour
{
    public TextMeshProUGUI[] textDisplays;
    public float typingSpeed = 0.05f;
    public float pauseAfterText = 1f;

    private Queue<TextMeshProUGUI> textQueue;

    void Start()
    {
        textQueue = new Queue<TextMeshProUGUI>(textDisplays);
        foreach (var text in textDisplays)
        {
            text.text = ""; // Start blank, duh.
        }
        StartCoroutine(TypeNextText());
    }

    IEnumerator TypeNextText()
    {
        while (textQueue.Count > 0)
        {
            var currentText = textQueue.Dequeue();
            string fullText = currentText.GetComponent<TextMeshProUGUI>().text;
            currentText.text = "";

            foreach (char letter in fullText)
            {
                currentText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSeconds(pauseAfterText);
        }
    }
}

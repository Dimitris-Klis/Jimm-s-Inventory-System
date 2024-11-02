using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Prompter : MonoBehaviour
{
    public TMP_Text PromptText;
    public CanvasGroup group;
    public static Prompter instance;
    private void Awake()
    {
        instance = this;
        HidePrompt();
    }
    public void ShowPrompt(string text)
    {
        group.alpha = 1;
        PromptText.text = text;
    }
    public void HidePrompt()
    {
        group.alpha = 0;
        PromptText.text = "";
    }
}

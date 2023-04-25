using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TypingManager : MonoBehaviour
{
    public List<Word> words;
    public Text display;

    void Update()
    {
        string input = Input.inputString;
        if (input.Equals("")) //If we are not typing
            return; //Stops this function here

        char c = input[0];
        string typing = "";
        for(int i = 0; i < words.Count; i++)
        {
            Word w = words[i];
            if (w.continueText(c))
            {
                string typed = w.getTyped();
                if (typed.Equals(w.text)) //If what we typed is the word's text
                {
                    //We typed the whole word
                    Debug.Log("TYPED : " + w.text);
                    words.Remove(w);
                    break;
                }
            }
        }
    }
}
[System.Serializable]
public class Word
{
    public string text;
    public UnityEvent onTyped;
    string hasTyped = "";
    int curChar = 0;

    public Word(string t)
    {
        text = t;
        hasTyped = "";
        curChar = 0;
    }

    public bool continueText(char c)
    {
        if (c.Equals(text[curChar]))
        {
            curChar++;
            hasTyped = text.Substring(0, curChar);

            if(curChar >= text.Length) //If we typed the whole word
            {
                onTyped.Invoke();
                curChar = 0;
            }
            return true;
        }
        else
        {
            curChar = 0;
            hasTyped = "";
            return false;
        }
    }

    public string getTyped()
    {
        return hasTyped;
    }
}

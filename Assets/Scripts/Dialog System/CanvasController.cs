using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Text  myText;
    private string input;
    [SerializeField] private GameObject sound;
    [SerializeField] private float textDelay;
    [SerializeField] private float textShowTime;
    private int textIndex = 0;
    
    private string[] dialogPile = { "Eu sou o Gato Gaiato! Vou pegar moedas para ser feliz! Miau!", "Moeda! Miau!" };
    private int dialogPileIndex = 0;


    
    public void Start()
    {
        ShowText();
    }
    public void ShowText()
    {
        textIndex = 0;
        StartCoroutine("EnumShowText");
    }
    IEnumerator EnumShowText()
    {
        if (dialogPileIndex < dialogPile.Length)
        {
            if (textIndex == 0)
            {
                input = dialogPile[dialogPileIndex];
            }
            yield return new WaitForSeconds(textDelay);
            if (textIndex < input.Length)
            {
                myText.text += input[textIndex];
                Instantiate(sound);
                textIndex += 1;
                StartCoroutine("EnumShowText");
            }
            else
            {
                yield return new WaitForSeconds(textShowTime);
                //dialogPileIndex += 1;
                myText.text = "";
                //ShowText();
            }
        }
    }
}

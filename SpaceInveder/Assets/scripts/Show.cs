using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Show : MonoBehaviour
{
    public TextMeshProUGUI[] text = new TextMeshProUGUI[10];
    public GameObject game, gameover;
    
    public void points()
    {
        Scors scors = HIghScors.load();
        for (int i = 0; i < 10; i++)
        {
            text[i].text = (i + 1) + ": " + scors.hs[i];
        }
    }
    public void change()
    {
        game.SetActive(false);
        gameover.SetActive(true);
    }
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }
}

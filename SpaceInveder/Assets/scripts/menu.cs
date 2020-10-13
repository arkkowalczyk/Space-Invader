using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Show show;
    public void play()
    {
        SceneManager.LoadScene("Game");
    }
    public void showscore()
    {
        show.points();
    }
}

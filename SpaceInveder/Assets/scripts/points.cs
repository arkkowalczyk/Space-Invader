using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class points : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "Points: "+enemy.score;
    }
}

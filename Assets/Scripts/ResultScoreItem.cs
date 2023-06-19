using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResultScoreItem : MonoBehaviour
{

    public TextMeshProUGUI playerName;
    public TextMeshProUGUI scorePlayer;

    public void SetInfo(string name, string score)
    {
        playerName.text = name;
        scorePlayer.text = score;
    }
}

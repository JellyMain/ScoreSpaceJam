using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI coin;
    public TextMeshProUGUI time;
    public TextMeshProUGUI playerHP;

    private float timer;

    void Start()
    {
        EventAgregator.updatePlayerUI.AddListener(UpdateScore);
        EventAgregator.updatePlayerUI.AddListener(UpdateCoin);

        score.text = Player.Instance.score.ToString();
        coin.text = Player.Instance.countCoin.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        time.text = timer.ToString();
    }

    private void UpdateScore()
    {
        score.text = Player.Instance.score.ToString();
    }

    private void UpdateCoin()
    {
        coin.text = Player.Instance.countCoin.ToString();
    }

}

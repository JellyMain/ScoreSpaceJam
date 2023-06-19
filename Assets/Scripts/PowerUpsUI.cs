using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpsUI : MonoBehaviour
{
    public List<PowerUps> allPowerUps;
    public List<Button> powerUpCards;
    public List<TMP_Text> powerUpCardDescriptions;

    private void Start()
    {
        // Assign random power-ups to cards...
        for (int i = 0; i < powerUpCards.Count; i++)
        {
            PowerUps randomPowerUp = allPowerUps[UnityEngine.Random.Range(0, allPowerUps.Count)];
            powerUpCards[i].onClick.AddListener(() => SelectPowerUpOffCanvas(randomPowerUp));
            powerUpCardDescriptions[i].text = randomPowerUp.description;
        }
    }

    private void SelectPowerUpOffCanvas(PowerUps powerUp)
    {
        powerUp.Activate();
        SoundManager.Instance.PlayPowerUpSound();
        EventAgregator.Unpause?.Invoke();
        this.gameObject.SetActive(false);
    }
}

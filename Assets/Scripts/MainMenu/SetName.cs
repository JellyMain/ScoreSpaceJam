using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetName : MonoBehaviour
{
    public Button button;
    public TMP_InputField _InputField;
    private Leaderboard _leaderboard;
    private string _name;
    void Start()
    {
        _name = PlayerPrefs.GetString("PlayerName");
        _leaderboard = FindObjectOfType<Leaderboard>();

        _InputField.text = _name;
        button.onClick.AddListener(()=>_leaderboard.StartSettingName(_InputField.text));
    }

    // Update is called once per frame
    void Update()
    {
        if (string.IsNullOrEmpty(_InputField.text))
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}

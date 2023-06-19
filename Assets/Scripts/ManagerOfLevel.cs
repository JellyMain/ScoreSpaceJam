using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfLevel : MonoBehaviour
{
    public GameObject pauseMenuTable;
    public GameObject winTable;
    public GameObject looseTable;
    public GameObject selectPowerUpOnCanvas;

    private bool _isPause = false;

    private void Awake()
    {
        _isPause = false;
        EventAgregator.ChooseGun.AddListener(SelectPowerUpOnCanvas);
        EventAgregator.ChooseGun.AddListener(PauseInGame);

        EventAgregator.PlayerWin.AddListener(SeeWinTable);
        EventAgregator.PlayerLoose.AddListener(SeeLooseTable);
        EventAgregator.Unpause.AddListener(ReturnInGame);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _isPause = !_isPause;
        }

        if (_isPause == true)
        {
            OpenMenuInGame();
        }
        else
        {
            CloseMenuInGame();
        }
    }

    public void SelectPowerUpOnCanvas()
    {
        selectPowerUpOnCanvas.SetActive(true);
    }

    private void OpenMenuInGame()
    {
        pauseMenuTable.SetActive(true);
        PauseInGame();
    }

    private void CloseMenuInGame()
    {
        pauseMenuTable.SetActive(false);
        ReturnInGame();

    }

    public void PauseInGame()
    {
        _isPause = true;
        Time.timeScale = 0f;
    }

    public void ReturnInGame()
    {
        _isPause = false;
        Time.timeScale = 1f;
    }

    public void SeeWinTable()
    {
        PauseInGame();
        winTable.SetActive(true);
    }

    public void SeeLooseTable()
    {
        PauseInGame();
        looseTable.SetActive(true);
    }
}

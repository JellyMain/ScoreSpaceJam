using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfLevel : MonoBehaviour
{
    public GameObject pauseMenuTable;

    private bool _isPause = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _isPause = !_isPause;
        }

        if (_isPause == true)
        {
            PauseInGame();
        }
        else
        {
            ReturnInGame();
        }
    }

    public void PauseInGame()
    {
        pauseMenuTable.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnInGame()
    {
        pauseMenuTable.SetActive(false);
        Time.timeScale = 1f;
    }
}

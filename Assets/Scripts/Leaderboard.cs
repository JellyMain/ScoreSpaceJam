using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using LootLocker;

public class Leaderboard : MonoBehaviour
{
    private string leaderboardKey = "PlayerScoreLeaderboard";




    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) =>
                {
                    if (response.success)
                    {
                        Debug.Log("Succesfully uploaded score");
                        done = true;
                    }
                    else
                    {
                        Debug.LogError("3123182938123891823819023812380912839");
                        Debug.Log("Failed" + response.Error);
                        done = true;
                    }

                });
        yield return new WaitWhile(() => done == false);
    }


    private IEnumerator GetName()
    {
        LootLockerSDKManager.GetPlayerName((response) =>
        {
            string playerName = response.name;
            Debug.Log(playerName);

        });
        yield return null;
    }

    private IEnumerator SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName("mynewName", (response) =>
        {
            if (response.success)
            {
                Debug.Log("PLAYER NAME SET SUCCESFULLY");
            }
            else
            {
                Debug.Log("PLAYER NAME SET NOOOOOOOOOOOOOOOOOOT SUCCESFULLY");
            }
        });
        yield return null;
    }



    public void StartSettingName()
    {
        StartCoroutine(SetPlayerName());
    }


    public void StartGettingName()
    {
        StartCoroutine(GetName());
    }
}

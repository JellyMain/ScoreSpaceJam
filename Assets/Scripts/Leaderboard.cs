using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using LootLocker;

public class Leaderboard : MonoBehaviour
{
    private string leaderboardKey = "PlayerScoreLeaderboard";

    public ResultItemManager itemManager;

    private IEnumerator startCoroutineFetchWinScores;
    private IEnumerator startCoroutineFetchLooseScores;

    private int count = 0;
    private void Awake()
    {
        EventAgregator.PlayerWin.AddListener(StartCoroutineFetchWinScores);
        EventAgregator.PlayerWin.AddListener(StartCoroutineSubmitScoreRoutine);
        EventAgregator.PlayerLoose.AddListener(StartCoroutineFetchLooseScores);
        EventAgregator.PlayerLoose.AddListener(StartCoroutineSubmitScoreRoutine);
    }

    public void StartCoroutineSubmitScoreRoutine()
    {
        if (Player.Instance.score > 0)
        {
            StartCoroutine(SubmitScoreRoutine(Player.Instance.score));
        }
    }

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

    private IEnumerator SetPlayerName(string name)
    {
        LootLockerSDKManager.SetPlayerName(name, (response) =>
        {
            if (response.success)
            {
                Debug.Log("PLAYER NAME SET SUCCESFULLY");
                PlayerPrefs.SetString("PlayerName", name);
            }
            else
            {
                Debug.Log("PLAYER NAME SET NOOOOOOOOOOOOOOOOOOT SUCCESFULLY");
            }
        });
        yield return null;
    }

    private void StartCoroutineFetchWinScores()
    {
        startCoroutineFetchWinScores = FetchWinScoresRoutine();
        StartCoroutine(startCoroutineFetchWinScores);
        //  FetchWinScoresRoutine();
        //   StartCoroutine(FetchWinScoresRoutine());
    }

    private void StartCoroutineFetchLooseScores()
    {
        startCoroutineFetchLooseScores = FetchLooseScoresRoutine();
        StartCoroutine(startCoroutineFetchLooseScores);
        //
        //startCoroutineFetchLooseScores = StartCoroutine(FetchLooseScoresRoutine());
        //  FetchLooseScoresRoutine();
        // StartCoroutine(FetchLooseScoresRoutine());
    }

    private void StopCoroutinesFetchLooseAndWinScores()
    {
        if (startCoroutineFetchLooseScores != null)
        {
            StopCoroutine(startCoroutineFetchLooseScores);
            startCoroutineFetchLooseScores = null;
        }

        if (startCoroutineFetchWinScores != null)
        {
            StopCoroutine(startCoroutineFetchWinScores);
            startCoroutineFetchWinScores = null;
        }
    }

    public IEnumerator FetchWinScoresRoutine()
    {
        bool done = false;

        if (count < 1)
        {
            LootLockerSDKManager.GetScoreList(leaderboardKey, 20, (responce) =>
            {
                if (responce.success)
                {


                    LootLockerLeaderboardMember[] members = responce.items;
                    for (int i = 0; i < members.Length; i++)
                    {
                        string tempPlayerNames = "Names\n";
                        string tempPlayerScores = "Scores\n";
                        tempPlayerNames += members[i].rank + ". ";
                        if (members[i].player.name != "")
                        {
                            tempPlayerNames += members[i].player.name;
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.id;
                        }

                        tempPlayerScores += members[i].score + "\n";
                        tempPlayerNames += "\n";

                        if (count < 1)
                        {
                            itemManager.CreateWinResultScoreItem(tempPlayerNames, tempPlayerScores);
                        }
                    }
                }
                else
                {
                    Debug.Log("Failed" + responce.Error);
                    done = true;
                }
                count++;
            });

            yield return new WaitForSeconds(1f);

            if (count >= 1)
            {
                StopCoroutinesFetchLooseAndWinScores();
            }
        }

        yield return new WaitForSeconds(1f);


        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchLooseScoresRoutine()
    {
        bool done = false;
        if (count < 1)
        {
            LootLockerSDKManager.GetScoreList(leaderboardKey, 20, (responce) =>
            {
                if (responce.success)
                {


                    LootLockerLeaderboardMember[] members = responce.items;
                    for (int i = 0; i < members.Length; i++)
                    {
                        string tempPlayerNames = "Names\n";
                        string tempPlayerScores = "Scores\n";
                        tempPlayerNames += members[i].rank + ". ";
                        if (members[i].player.name != "")
                        {
                            tempPlayerNames += members[i].player.name;
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.id;
                        }

                        tempPlayerScores += members[i].score + "\n";
                        tempPlayerNames += "\n";

                        if (count < 1)
                        {
                            itemManager.CreateLooseResultScoreItem(tempPlayerNames, tempPlayerScores);
                        }
                    }
                }
                else
                {
                    Debug.Log("Failed" + responce.Error);
                    done = true;
                }
                count++;
            });

            yield return new WaitForSeconds(1f);

            if (count >= 1)
            {
                StopCoroutinesFetchLooseAndWinScores();
            }
        }
        yield return new WaitForSeconds(1f);

        yield return new WaitWhile(() => done == false);
    }

    public void StartSettingName(string name)
    {
        StartCoroutine(SetPlayerName(name));
    }


    public void StartGettingName()
    {
        StartCoroutine(GetName());
    }
}

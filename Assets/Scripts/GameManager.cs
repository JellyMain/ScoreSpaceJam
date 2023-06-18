using UnityEngine;
using LootLocker.Requests;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoginRoutine());
    }



    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((responce) =>
        {
            if (responce.success)
            {
                Debug.Log("player has logined");
                PlayerPrefs.SetString("PlayerID", responce.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("error while logining");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        LootLockerSDKManager.StartGuestSession((responce) =>
        {
            if (!responce.success)
            {
                Debug.LogError("error starting guest session");
                return;
            }
            Debug.Log("guest session started");
        });
    }
}

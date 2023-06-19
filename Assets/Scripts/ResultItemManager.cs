using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultItemManager : MonoBehaviour
{
    public ResultScoreItem resultScoreItemPrefab;
    public GameObject panelWin;
    public GameObject panelLose;

    public void CreateWinResultScoreItem(string name, string score)
    {
        var go = Instantiate(resultScoreItemPrefab);
        go.SetInfo(name, score);
        go.transform.SetParent(panelWin.transform);
    }
    public void CreateLooseResultScoreItem(string name, string score)
    {
        var go = Instantiate(resultScoreItemPrefab);
        go.SetInfo(name, score);
        go.transform.SetParent(panelLose.transform);
    }
}

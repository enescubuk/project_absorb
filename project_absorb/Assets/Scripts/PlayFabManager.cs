using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class PlayFabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest{CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request,OnSuccess,OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("giriş başarılı/hesap kuruldu");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("giriş yaparken/hesap oluştururken hata");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {Statistics = new List<StatisticUpdate>
        {new StatisticUpdate{StatisticName = "KillScore",Value = score}}};

        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("başarıyla skor tablosuna gönderildi");
        
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest{StatisticName = "KillScore",StartPosition = 0,MaxResultsCount = 10};
        PlayFabClientAPI.GetLeaderboard(request,OnLeaderboardGet,OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        Debug.Log("31");
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " - " + item.PlayFabId + " - " + item.StatValue);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;


public class PlayFabManager : MonoBehaviour
{
    public GameObject nameWindow;
    public GameObject leaderboardWindow;
    public GameObject nameError;
    public InputField nameInput;
    public GameObject rowPrefab;
    public Transform rowsParent;
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest{CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true, InfoRequestParameters = new GetPlayerCombinedInfoRequestParams{GetPlayerProfile = true}};
        PlayFabClientAPI.LoginWithCustomID(request,OnLoginSuccess,OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("giriş başarılı/hesap kuruldu");
        string name  = null;
        if(result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }
        if (name == null)
        {
            leaderboardWindow.SetActive(false);
        }
        else
        {
            leaderboardWindow.SetActive(true);
        }
    }
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate,OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("isim güncellendi");
        leaderboardWindow.SetActive(true);
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
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab,rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position+1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " - " + item.DisplayName + " - " + item.StatValue);
            
            Text[] PlayerRow = GameObject.Find("PlayerRow").GetComponentsInChildren<Text>();
            PlayerRow[0].text = (item.Position+1).ToString();
            PlayerRow[1].text = item.DisplayName + "(Me)";
            PlayerRow[2].text = item.StatValue.ToString();
            
        }

        
    }
}

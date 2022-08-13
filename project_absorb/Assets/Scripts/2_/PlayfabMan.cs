using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayfabMan : MonoBehaviour
{
    public GameObject nameWindow;
    public GameObject leaderboardScreen;

    public GameObject rowPrefab;
    public Transform rowsParent;
    public InputField nameInput;
    string loggedInPlayfabId;
    // Start is called before the first frame update
    void Start()
    {
        Login();
        //leaderboardScreen = GameObject.Find("leaderboard");
        //leaderboardScreen.SetActive(false);
        //rowsParent = GameObject.Find("Table").GetComponent<Transform>();
    }

    
    void Login()
    {
        var request = new LoginWithCustomIDRequest{
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams{
                GetPlayerProfile = true
            }
            
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess ,OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("başarılı giriş / hesap kuruldu");
        string name = null;
        if(result.InfoResultPayload.PlayerProfile != null)
        name = result.InfoResultPayload.PlayerProfile.DisplayName;

        if (name == null)
        {
            nameWindow.SetActive(true);
        }
        else
        {
            //leaderboardScreen.SetActive(true);
            GetLeaderboard();
        }
    }
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest{
            DisplayName = nameInput.text,
            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request,onDisplayNameUpdate,OnError);
    }
    void onDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("display name güncellendi");
        leaderboardScreen.SetActive(true);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("giriş yaparken/hesap kurarken hata!");
        Debug.Log(error.GenerateErrorReport());
    }
    public void SendLeaderboard(int score)
    {
        Debug.Log(score);
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{StatisticName = "KillScore",
                Value = score}
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("başarıyla leaderboarda gönderildi");
    }

    public void GetLeaderboard() {
        leaderboardScreen.SetActive(true);
        var request = new GetLeaderboardRequest{
            StatisticName = "KillScore",
            StartPosition = 0,
            MaxResultsCount = 10};
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
            //PlayerRow[0].text = (item.Position+1).ToString();
            //PlayerRow[1].text = item.DisplayName + "(Me)";
            //PlayerRow[2].text = item.StatValue.ToString();

            if (item.PlayFabId == loggedInPlayfabId)
            {
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;
                PlayerRow[0].text = (item.Position+1).ToString();
                PlayerRow[1].text = item.DisplayName + "(Me)";
                PlayerRow[2].text = item.StatValue.ToString();
            }
            
        }
    }
}


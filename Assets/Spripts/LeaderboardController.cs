using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using Dan.Models;

public class LeaderBoardController : MonoBehaviour
{
    public List<TextMeshProUGUI> names;
    public List<TextMeshProUGUI> scores;
    
    private void Start()
    {
        if (PlayerPrefs.GetInt("highscore") > 0)
            UploadEntry();
        else
            LoadEntries();
    }

    private void UploadEntry()
    {
        foreach (TextMeshProUGUI n in names)
        {
            n.text = "";
        }

        foreach (var score in scores)
        {
            score.text = "";
        }
        Leaderboards.TheImpossibleRunner.UploadNewEntry(PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt("highscore"), isSuccessful =>
        {
            if (isSuccessful)
            {
                Debug.Log("Entry uploaded successfully. Reloading entries.");
                LoadEntries();
            }
            else
            {
                Debug.LogError("Failed to upload entry, retrying...");
                UploadEntry();
            }
        });
    }

    private void LoadEntries()
    {
        foreach (TextMeshProUGUI n in names)
        {
            n.text = "";
        }

        foreach (var score in scores)
        {
            score.text = "";
        }
        
        names[0].text = "Loading...";
        
        Leaderboards.TheImpossibleRunner.GetEntries(LeaderboardSearchQuery.Paginated(0, 5), entries =>
        {
            float length = Mathf.Min(names.Count, entries.Length);

            for (int i = 0; i < length; i++)
            {   
                names[i].text = entries[i].Username;
                scores[i].text = entries[i].Score.ToString();
                names[i].color = entries[i].IsMine() ? Color.yellow : Color.white;
            }
            Debug.Log("Entries loaded into the leaderboard.");
        });
    }
}

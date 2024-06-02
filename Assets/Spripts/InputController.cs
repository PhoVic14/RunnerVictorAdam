using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Dan.Main;

public class InputController : MonoBehaviour
{
    public Button submitButton;
    public TMP_InputField inputField;
    public TextMeshProUGUI playerName;
    
    private string[] randomNames = 
        { "Adam", "Anton", "Alexander", "Mark", "Axel", "Jeremy", "David", "Arthur", "Abdoul" };
    
    private void Start()
    {

        if (!PlayerPrefs.HasKey("Username"))
        {
            PlayerPrefs.SetString("Username", randomNames[Random.Range(0, randomNames.Length)]);
        }
        playerName.text = PlayerPrefs.GetString("Username");   
        submitButton.onClick.AddListener(() => SaveName());
        Debug.Log($"Username set to: {playerName.text}");


    }

    private void SaveName()
    {
        if(inputField.text != "" && inputField.text.Length <= 17)
        {
            PlayerPrefs.SetString("Username", inputField.text);
            playerName.text = PlayerPrefs.GetString("Username");
            inputField.text = "";
            PlayerPrefs.SetInt("highscore", 0);
            LeaderboardCreator.ResetPlayer();



        }
        else
        {
            inputField.text = "Error";
        }

    }

}

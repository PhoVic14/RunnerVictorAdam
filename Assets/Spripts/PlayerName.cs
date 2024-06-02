using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class PlayerName : MonoBehaviour
    {
        public string nameOfPlayer;
        public string saveName;

        public Text inputText;
        public Text loadedName;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            nameOfPlayer = PlayerPrefs.GetString("name", "none");
            loadedName.text = nameOfPlayer;
        }

        public void SetName()
        {
            saveName = inputText.text;
            PlayerPrefs.SetString("name", saveName);
        }
    }


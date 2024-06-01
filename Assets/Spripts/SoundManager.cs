using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Image soundOnIcon;
    [SerializeField] private Image soundOffIcon;
    [SerializeField] private AudioSource coinCollectSource;
    [SerializeField] private AudioSource playerDeathSource;
    [SerializeField] private AudioSource backgroundMusicSource;

    private bool muted = false;
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Empêche la destruction du GameObject entre les scènes
            Load();
            UpdateSound();
            UpdateButtonIcon();
        }
        else
        {
            Destroy(gameObject); // Détruire cette instance dupliquée
        }
    }

    private void Start()
    {
        if (soundOnIcon == null || soundOffIcon == null || coinCollectSource == null || playerDeathSource == null || backgroundMusicSource == null)
        {
            Debug.LogError("Please assign all references in the inspector.");
        }
        else
        {
            Debug.Log("SoundManager: All references are correctly assigned.");
        }
    }

    public void OnButtonPress()
    {
        Debug.Log("SoundManager: OnButtonPress called.");
        muted = !muted;
        Save();
        UpdateSound();
        UpdateButtonIcon();
    }

    private void UpdateSound()
    {
        AudioListener.pause = muted;
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.mute = muted;
        }
        Debug.Log("SoundManager: UpdateSound called. Muted: " + muted);
    }

    public void UpdateButtonIcon()
    {
        if (muted)
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
        else
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        Debug.Log("SoundManager: UpdateButtonIcon called. Muted: " + muted);
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted", 0) == 1;
        UpdateButtonIcon();
        Debug.Log("SoundManager: Load called. Muted: " + muted);
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        Debug.Log("SoundManager: Save called. Muted: " + muted);
    }

    public void PlayCoinCollectSound()
    {
        if (!muted && coinCollectSource != null)
        {
            coinCollectSource.Play();
            Debug.Log("SoundManager: Coin collect sound played.");
        }
        else
        {
            Debug.LogWarning("SoundManager: Coin collect sound not played. Muted: " + muted + ", AudioSource: " + (coinCollectSource != null));
        }
    }

    public void PlayPlayerDeathSound()
    {
        if (!muted && playerDeathSource != null)
        {
            playerDeathSource.Play();
            Debug.Log("SoundManager: Player death sound played.");
        }
        else
        {
            Debug.LogWarning("SoundManager: Player death sound not played. Muted: " + muted + ", AudioSource: " + (playerDeathSource != null));
        }
    }
}

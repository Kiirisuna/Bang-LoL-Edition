using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;

    public static string displayName { get; private set; }
    private const string playerPrefsNameKey = "PlayerName";

    private void Start() => setupInputField();

    private void setupInputField() {
        if(!PlayerPrefs.HasKey(playerPrefsNameKey)) { return; }
        string defaultName = PlayerPrefs.GetString(playerPrefsNameKey);
        nameInputField.text = defaultName;
        setPlayerName(defaultName);
    }

    public void setPlayerName(string name) {
        continueButton.interactable = !string.IsNullOrEmpty(name);
    }
    
    public void savePlayerName() {
        displayName = nameInputField.text;
        PlayerPrefs.SetString(playerPrefsNameKey, displayName);
    }

}

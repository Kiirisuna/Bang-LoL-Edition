using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joinLobbyMenu : MonoBehaviour
{
    [SerializeField] private networkManagerLobby networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;
    [SerializeField] private TMP_InputField ipAddressInputField = null;
    [SerializeField] private Button joinButton = null;

    private void OnEnable() {
        networkManagerLobby.OnClientConnected += HandleClientConnected;
        networkManagerLobby.OnClientDisconnected += HandleClientDisconnected;
    }

    private void OnDisable() {
        networkManagerLobby.OnClientConnected -= HandleClientConnected;
        networkManagerLobby.OnClientDisconnected -= HandleClientDisconnected;
    }

    public void joinLobby() {
        string ipAddress = ipAddressInputField.text;
        networkManager.networkAddress = ipAddress;
        networkManager.StartClient();

        joinButton.interactable = false;
    }
    private void HandleClientConnected() {
        joinButton.interactable = true;
        gameObject.SetActive(false);
        landingPagePanel.SetActive(false);
    }

    private void HandleClientDisconnected() {
        joinButton.interactable = true;
    }
}

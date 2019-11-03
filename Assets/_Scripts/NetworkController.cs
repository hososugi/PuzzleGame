using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _joinButton;
    [SerializeField]
    private Transform _loadButton;
    [SerializeField]
    private Transform _createButton;

    public Text networkMessageText;

    // Start is called before the first frame update
    void Start()
    {
        networkMessageText      = GameObject.Find("NetworkMessageText").GetComponent<Text>();
        networkMessageText.text = "Connecting to server.";

        ConnectedToServer();
    }

    private void ConnectedToServer()
    {
        PhotonNetwork.NickName    = MasterManager.GameSettings.Nickname;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        networkMessageText.text = "Connected to server with nickname '" + PhotonNetwork.LocalPlayer.NickName + "'.";

        // Enabled the buttons to play and create.
        EnableButtonAndText(_joinButton);
        EnableButtonAndText(_loadButton);
        EnableButtonAndText(_createButton);
    }

    private void EnableButtonAndText(Transform buttonTransform)
    {
        Button button = buttonTransform.GetComponent<Button>();
        button.interactable = true;

        Text[] texts = buttonTransform.GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            var color = text.color;
            color.a = 1f;

            text.color = color;
        }

        var outlines = buttonTransform.GetComponentsInChildren<Outline>();

        foreach (Outline outline in outlines)
        {
            var color = outline.effectColor;
            color.a = 1f;

            outline.effectColor = color;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("DEBUG: disconnected from server for reason " + cause.ToString());
        networkMessageText.text = "Disconnected from server for reason " + cause.ToString();
        base.OnDisconnected(cause);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("DEBUG: Created room.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("DEBUG: failed creating room.");
    }
}

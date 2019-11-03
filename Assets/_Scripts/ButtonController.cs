using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviourPunCallbacks, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _dialog;
    [SerializeField]
    private GameObject _dialogShadow;
    [SerializeField]
    private Text _roomInput;

    void Update()
    {
        if(Input.GetKeyUp("escape"))
        {
            OnClick_DialogCancelClick();
        }
    }

    public void OnClick_CreateButtonClick()
    {
        Debug.Log("DEBUG: OnClick_CreateButtonClick " + name);
        _dialog.SetActive(true);
        _dialogShadow.SetActive(true);
    }

    public void OnClick_DialogCreateRoomClick()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 10;

        PhotonNetwork.CreateRoom(_roomInput.text, options, TypedLobby.Default);
    }

    public void OnClick_DialogCancelClick()
    {
        _dialog.SetActive(false);
        _dialogShadow.SetActive(false);
    }

    public void OnClick_ExitGameClick()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject panel = transform.Find("Panel").gameObject;
        panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject panel = transform.Find("Panel").gameObject;
        panel.SetActive(false);
    }
}

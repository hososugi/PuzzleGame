using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _roomListItem;
    [SerializeField]
    private GameObject _roomListingContent;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
    }
}

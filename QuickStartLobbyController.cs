using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject connect;
    [SerializeField] GameObject disconnect;
    // Start is called before the first frame update
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        connect.SetActive(true);
    }

    public void QuickStart()
    {

        Debug.Log("QuickStart");
        connect.SetActive(false);
        disconnect.SetActive(true );
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("failed to join room");
        CreateRoom();
    }
    void CreateRoom()
    {
        Debug.Log("creating room");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)(10) };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps );
        Debug.Log(randomRoomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        CreateRoom() ;
    }
    public void QuickCancel()
    {
        disconnect.SetActive(false);
        connect.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}

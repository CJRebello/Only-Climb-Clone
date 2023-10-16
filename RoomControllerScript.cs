using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class RoomControllerScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private int multiplayerSceneIndex;
    [SerializeField] private TextMeshProUGUI loadingProgress;
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
        loadingProgress.enabled = false;
    }
    public override void OnJoinedRoom()
    {
        StartGame();
    }
    private void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            StartCoroutine(loadLevel(multiplayerSceneIndex));
            Debug.Log("Load Level");
            
        }
    }
    IEnumerator loadLevel (int sceneIndex)
    {
        Debug.Log("Loading");
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        loadingProgress.enabled = true;
        while (PhotonNetwork.LevelLoadingProgress < 100f)
        {
            loadingProgress.text = PhotonNetwork.LevelLoadingProgress * 100 + "%";
            yield return null;
        }
    }
}

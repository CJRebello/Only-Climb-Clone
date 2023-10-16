using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        int skin = Random.Range(0, 4);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ClimbPlayer"), Vector3.zero, Quaternion.identity);
    }
}

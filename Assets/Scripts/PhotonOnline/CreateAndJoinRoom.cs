using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("Genilson");
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("Genilson");
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Simple");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
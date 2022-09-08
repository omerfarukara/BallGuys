using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class SpawnPlayers : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public GameObject playerPrefab;
    public float minX, maxX, minZ, maxZ;

    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        vcam.Follow = player.transform.GetChild(0).transform;
    }



    void Update()
    {

    }
}

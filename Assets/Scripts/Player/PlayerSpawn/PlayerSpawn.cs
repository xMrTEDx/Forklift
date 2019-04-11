using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject cameraRotate;

    public void SetPlayerPosition()
    {
        if (MainPlayer.currentPlayer)
        {
            MainPlayer.currentPlayer.gameObject.transform.position = transform.position;
            MainPlayer.currentPlayer.gameObject.transform.rotation = transform.rotation;

            MainPlayer.currentPlayer.character.transform.rotation = cameraRotate.transform.rotation;
        }


        //Camera.main.transform.localRotation = cameraRotate.transform.localRotation;
        //Camera.main.transform.rotation = cameraRotate.transform.rotation;

    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1.5f, 7f, 1.5f));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public float[] playerPositionAndRotation;


    //public string[] inventoryContent;

    public PlayerData(float[] _playerPosAndRot)
    {
        playerPositionAndRotation = _playerPosAndRot;
    }
}

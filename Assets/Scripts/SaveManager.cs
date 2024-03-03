using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public bool isSavingJson;

    #region || ------- General Section ------- ||

    public void SaveGame()
    {
        AllGameData data = new AllGameData();
        data.playerData = GetPlayerData();

        SaveAllGameData(data);
    }

    private PlayerData GetPlayerData()
    {

        float[] playerPosAndRot = new float[6];
        playerPosAndRot[0] = PlayerStatusSystem.instance.playerBody.transform.position.x;
        playerPosAndRot[1] = PlayerStatusSystem.instance.playerBody.transform.position.y;
        playerPosAndRot[2] = PlayerStatusSystem.instance.playerBody.transform.position.z;

        playerPosAndRot[3] = PlayerStatusSystem.instance.playerBody.transform.rotation.x;
        playerPosAndRot[4] = PlayerStatusSystem.instance.playerBody.transform.rotation.y;
        playerPosAndRot[5] = PlayerStatusSystem.instance.playerBody.transform.rotation.z;

        return new PlayerData(playerPosAndRot);
    }

    public void SaveAllGameData(AllGameData gameData)
    {
        if(isSavingJson)
        {

        }
        else
        {
            SaveToBinaryFile(gameData);
        }
    }

    #endregion

    #region || ------- To Binary Section ------- ||

    public void SaveToBinaryFile(AllGameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save_game.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameData);
        stream.Close();

        print("Data saved to" + Application.persistentDataPath + "/save_game.bin");
    }

    public AllGameData LoadFromBinaryFile()
    {
        string path = Application.persistentDataPath + "/save_game.bin";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            AllGameData data = formatter.Deserialize(stream) as AllGameData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }

    #endregion

    #region || ------- Settings Section ------- ||

    #region || ------- Volume Settings ------- ||

    #endregion

    #endregion

}

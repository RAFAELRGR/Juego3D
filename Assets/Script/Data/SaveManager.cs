
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager 
{
    public static void savePlayerData(Money moneys)
    {
        PlayerData playerdata = new PlayerData(moneys);
        string dataPath = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fileStream, playerdata);
        fileStream.Close();
    }
    public static void savePlayerData1(Move move)
    {
        PlayerData playerdata = new PlayerData(move);
        string dataPath = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fileStream, playerdata);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string dataPath = Application.persistentDataPath + "/player.save";
        
        if(File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            PlayerData playerdata = (PlayerData) formatter.Deserialize(fileStream);
            fileStream.Close();
            return playerdata;
        }
        else
        {
            return null;
            Debug.LogError("No  hay nada de data");
        }

    }
}

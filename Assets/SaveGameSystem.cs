using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameSystem : MonoBehaviour {

    public static bool SaveGame(SaveGame saveGame)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = File.Create(Application.persistentDataPath + "/savedGame.jaic");
            try
            {
                formatter.Serialize(stream, saveGame);
            }
            catch (Exception)
            {
                return false;
            }
        return true;
    }

    public static SaveGame LoadGame()
    {
        if (!DoesSaveGameExist(Application.persistentDataPath + "/savedGame.jaic"))
        {
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(Application.persistentDataPath + "/savedGame.jaic", FileMode.Open))
        {
            try
            {
                return formatter.Deserialize(stream) as SaveGame;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public static bool DeleteSaveGame()
    {
        try
        {
            File.Delete(Application.persistentDataPath + "/savedGame.jaic");
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public static bool DoesSaveGameExist(string name)
    {
        return File.Exists(Application.persistentDataPath + "/savedGame.jaic");
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
public static class SaveLoad
{
    public static List<Game> savedGames = new List<Game>();
    public static void Save()
    {
        SaveLoad.savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath это строка; выведите ее в логах и вы увидите расположение файла сохранений
        if (!File.Exists(Application.persistentDataPath + "/savedGames.txt"))
        {
            FileStream file = File.Create(Application.persistentDataPath + "/savedGames.txt");
            bf.Serialize(file, SaveLoad.savedGames);
            file.Close();
        }
        else
        {
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.txt", FileMode.Open);
            bf.Serialize(file, SaveLoad.savedGames);
            file.Close();
        }

    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.txt", FileMode.Open);
            SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();
        }
    }
}
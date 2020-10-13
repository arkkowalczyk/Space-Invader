﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class HIghScors 
{
    public static void SaveScore(enemy enemy)
    {
        BinaryFormatter format = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.score";
        FileStream stream = new FileStream(path,FileMode.Create);

        Scors scors = new Scors(enemy);

        format.Serialize(stream, scors);
        stream.Close();
    }

    public static Scors load()
    {
        string path = Application.persistentDataPath + "/score.score";
        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Scors scors = format.Deserialize(stream) as Scors;
            stream.Close();

            return scors;
        }
        else
        {
            return null;
        }
    }
}

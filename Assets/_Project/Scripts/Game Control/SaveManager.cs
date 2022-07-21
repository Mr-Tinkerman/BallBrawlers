using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[RequireComponent(typeof(GameManager))]
public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private Save _gameData;

    public static SaveManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Load();
    }

    public void Save()
    {
        SaveHandler.Serialize(_gameData, "savedata");
    }

    public void Load()
    {
        Debug.Log(Application.persistentDataPath);
        try
        {
            _gameData = SaveHandler.Deserialize<Save>("savedata");
        }
        catch(System.Exception)
        {
            Save();
            Load();
        }
    }

    public void AddCoins(int i)
    {
        _gameData.AddCoins(i);
    }
}

public class SaveHandler
{
    public static void Serialize(object item, string name)
    {
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        StreamWriter writer = new StreamWriter(Application.persistentDataPath +
                                                                          "/" +
                                                                         name +
                                                                         ".txt");
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();
    }

    public static T Deserialize<T>(string name)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(Application.persistentDataPath +
                                                                          "/" +
                                                                         name +
                                                                         ".txt");
        T deserialized = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return deserialized;
    }
}

[System.Serializable, XmlRoot("game_data")]
public class Save
{
    public int coins;

    // [XmlArray("level_groups"), XmlArrayItem("levels")]
    // System.Int16[] unlockedLevels;

    [XmlArray("skin_groups"), XmlArrayItem("skins")]
    public List<int> skins;

    [XmlArray("hat_groups"), XmlArrayItem("hats")]
    public List<int> hats;

    public void AddCoins(int count)
    {
        coins += count;
    }

    public void RemoveCoins(int count)
    {
        coins -= count;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SetSkin(int i, bool unlock)
    {
        int index = (int)Mathf.Floor(i / 32);

        if (!(i < skins.Count))
            skins.Capacity = index + 1;

        // Complex set bitflag based data storage
        skins[index] = (unlock) ? skins[index] | (1 << i % 32) : skins[index] & (~(1 << i % 32));
    }

    public List<int> GetSkins()
    {
        return skins;
    }

    public void SetHat(int i, bool unlock)
    {
        int index = (int)Mathf.Floor(i / 32);

        if (!(i < skins.Count))
            hats.Capacity = index + 1;

        // Complex set bitflag based data storage
        hats[index] = (unlock) ? hats[index] | (1 << i % 32) : hats[index] & (~(1 << i % 32));
    }

    public List<int> GetHats()
    {
        return hats;
    }
}
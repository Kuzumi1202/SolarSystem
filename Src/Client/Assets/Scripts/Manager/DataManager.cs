using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public string DataPath;
    public Dictionary<int, Celestial> PlanetManager = null;

    public DataManager()
    {
        this.DataPath = "Data/";
        Debug.LogFormat("DataManager > DataManager()");
    }

    public void Load()
    {
        string json = File.ReadAllText(this.DataPath + "PlanetDefine.txt");
        this.PlanetManager = JsonConvert.DeserializeObject<Dictionary<int, Celestial>>(json);

    }
    public IEnumerator LoadData()
    {
        string json = File.ReadAllText(this.DataPath + "PlanetDefine.txt");
        this.PlanetManager = JsonConvert.DeserializeObject<Dictionary<int, Celestial>>(json);

        yield return null;

    }
}

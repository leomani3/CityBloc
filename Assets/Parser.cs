using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Parser
{
    public static List<Building> GetBuildingsFromJSON(string path)
    {
        List<Building> buildings = new List<Building>();
        JObject jObject = JObject.Parse(File.ReadAllText(Application.dataPath + "/Bati_JSON_RGF93_LITE.geojson"));
        JArray features = (JArray) jObject["features"];
        foreach(JObject j in features)
        {
            Debug.Log("features : " + features.Count);
            float val = (float) j["properties"]["HAUTEUR"];
            JArray coordJSON = (JArray) j["geometry"]["coordinates"][0];
            List<Vector2> coords = new List<Vector2>();
            foreach(JArray j1 in coordJSON)
            {
                coords.Add(new Vector2((float) j1[0], (float) j1[1]));
            }
            Building b = new Building((float) j["properties"]["HAUTEUR"], coords);
            buildings.Add(b);
        }
        return buildings;
    } 
}


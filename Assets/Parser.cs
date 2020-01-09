using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Parser
{
    public static List<Building> GetBuildingsFromJSON(string path)
    {
        JObject encodedBuilding = JObject.Parse(File.ReadAllText(Application.dataPath + "/Bati_JSON_RGF93_LITE.geojson"));
        JArray features = (JArray) encodedBuilding["features"];

        List<Building> buildings = new List<Building>();
        foreach(JObject feature in features)
        {
            float val = (float) feature["properties"]["HAUTEUR"];
            JArray coordJSON = (JArray) feature["geometry"]["coordinates"][0];

            List<Vector2> coords = new List<Vector2>();
            foreach(JArray j1 in coordJSON)
            {
                coords.Add(new Vector2((float) j1[0], (float) j1[1]));
            }
            
            Building b = new Building((float) feature["properties"]["HAUTEUR"], coords);
            buildings.Add(b);
        }
        return buildings;
    } 
}


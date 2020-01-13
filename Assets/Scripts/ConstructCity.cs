using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructCity : MonoBehaviour
{
    List<Building> city;
    public ConstructeurDeJolieMaison gerard;
    void Start()
    {
        city = Parser.GetBuildingsFromJSON("./Assets/Scripts/Campus_Bron_RGF93_GeoJson.geojson");

        Vector2 cityCenter = new Vector2();
        int nb = 0;
        for (int i = 0; i < city.Count; i++)
        {
            for (int j = 0; j < city[i].points.Count; j++)
            {
                cityCenter += city[i].points[j];
                nb++;
            }
        }
        cityCenter /= nb;

        
        for (int i = 0; i < city.Count; i++)
        {
            //Debug.Log(city[i].points[0].x);
            ConstructeurDeJolieMaison gerardInstancier = Instantiate(gerard, new Vector3((city[i].points[0].x - cityCenter.x) / 10000, 0, (city[i].points[0].y - cityCenter.y) / 10000), Quaternion.identity);
            gerardInstancier.building = city[i];
            gerardInstancier.cityCenter = cityCenter;
            //Debug.Log(gerardInstancier.building.points[0].x);
            gerardInstancier.Construct();
        }
    }
}

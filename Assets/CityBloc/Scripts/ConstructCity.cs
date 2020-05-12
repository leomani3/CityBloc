using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructCity : MonoBehaviour
{
    //Building list of your city
    List<Building> city;

    //Prefab of houses 
    public HouseConstructor houseConstructorPrefab;

    //Geojson file of your city
    public TextAsset geojsonFile;

    public void BuildCity()
    {
        city = Parser.GetBuildingsFromJSON(Application.dataPath + "/CityBloc/Scripts/" + geojsonFile.name + ".json");

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
            HouseConstructor house = Instantiate(houseConstructorPrefab, new Vector3((city[i].points[0].x - cityCenter.x) / 10000, 0, (city[i].points[0].y - cityCenter.y) / 10000), Quaternion.identity);
            house.building = city[i];
            house.cityCenter = cityCenter;
            house.Construct();

        }
    }
}

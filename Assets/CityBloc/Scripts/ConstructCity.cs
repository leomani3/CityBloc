using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructCity : MonoBehaviour
{
    List<Building> city;
    public HouseConstructor houseConstructorPrefab;
    public string path;
    void Start()
    {
        city = Parser.GetBuildingsFromJSON(Application.dataPath + path);

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
            HouseConstructor house = Instantiate(houseConstructorPrefab, new Vector3((city[i].points[0].x - cityCenter.x) / 10000, 0, (city[i].points[0].y - cityCenter.y) / 10000), Quaternion.identity);
            house.building = city[i];
            house.cityCenter = cityCenter;
            //Debug.Log(gerardInstancier.building.points[0].x);
            house.Construct();
        }
    }
}

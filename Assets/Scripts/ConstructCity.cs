using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructCity : MonoBehaviour
{
    // Start is called before the first frame update
    List<Building> city;
    public ConstructeurDeJolieMaison gerard;
    void Start()
    {
        city = Parser.GetBuildingsFromJSON("./Scripts/Bati_JSON_RGF93.geojson");
        
        for (int i = 0; i < city.Count; i++)
        {
            //Debug.Log(city[i].points[0].x);
            ConstructeurDeJolieMaison gerardInstancier = Instantiate(gerard, Vector3.zero, Quaternion.identity);
            gerardInstancier.building = city[i];
            //Debug.Log(gerardInstancier.building.points[0].x);
            gerardInstancier.Construct();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

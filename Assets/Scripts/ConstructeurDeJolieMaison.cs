using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructeurDeJolieMaison : MonoBehaviour
{
    public List<Vector3> coordinates;

    public Material mat;
    public Building building;
    private MeshFilter meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        Building build = new Building();
        build.points = new List<Vector3> { new Vector3(0, 0, 0), new Vector3(2, 0, 0), new Vector3(2, 0, 2), new Vector3(1, 0, 2), new Vector3(1, 0, 1), new Vector3(0, 0, 1) };
        build.height = 5; 
        building = build;

        Construct();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construct()
    {
        Mesh msh = new Mesh();
        List<int> triangles = new List<int>();

        //calcul du centre du batiment
        Vector3 center = new Vector3();
        for (int i = 0; i < building.points.Count; i++)
        {
            center += building.points[i];
        }
        center /= building.points.Count;
        Vector3 centerfaceHaut = new Vector3(center.x, center.y + building.height, center.z);
        building.points.Insert(0, center);
        building.points.Insert(1, centerfaceHaut);

        //vertices claqués au sol
        List<Vector3> vert = new List<Vector3>();
        vert.InsertRange(0, building.points);


        //vertices en l'air
        for (int i = 0; i < building.points.Count; i++)
        {
            vert.Add(new Vector3(building.points[i].x, building.points[i].y + building.height, building.points[i].z));
        }
        msh.vertices = vert.ToArray();


        /*List<Vector3> blbl = new List<Vector3>();
        blbl.Add(new Vector3(0, 0, 0));
        blbl.Add(new Vector3(1, 0, 0));
        blbl.Add(new Vector3(0, 0, 1));
        msh.vertices = blbl.ToArray();*/

        //triangles
        /*triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);*/

        //face du bas
        for (int i = 2; i < building.points.Count-1; i++)
        {
            triangles.Add(i);
            triangles.Add(0);
            triangles.Add(i+1);
        }
        triangles.Add(building.points.Count - 1);
        triangles.Add(0);
        triangles.Add(2);

        //faces latéralles
        for (int i = 2; i < building.points.Count - 1; i++)
        {
            triangles.Add(i);
            triangles.Add(i + building.points.Count);
            triangles.Add(i + 1);

            triangles.Add(i + 1);
            triangles.Add(i + building.points.Count);
            triangles.Add(i + building.points.Count + 1);
        }
        triangles.Add(building.points.Count -1);
        triangles.Add(vert.Count - 1);
        triangles.Add(2);

        triangles.Add(2);
        triangles.Add(vert.Count - 1);
        triangles.Add(building.points.Count + 2);


        //face du haut
        for (int i = 2; i < building.points.Count - 1; i++)
        {
            triangles.Add(i + building.points.Count);
            triangles.Add(1);
            triangles.Add(i + 1 + building.points.Count);
        }
        triangles.Add(vert.Count - 1);
        triangles.Add(1);
        triangles.Add(2 + building.points.Count);

        msh.triangles = triangles.ToArray();
        GetComponent<MeshRenderer>().material = mat;
        meshFilter.mesh = msh;
    }
}

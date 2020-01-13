using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructeurDeJolieMaison : MonoBehaviour
{
    public List<Vector3> coordinates;

    public Material mat;
    public Building building;
    private MeshFilter meshFilter;
    public Vector2 cityCenter;

    public void Construct()
    {
        for(int i = 0; i < building.points.Count; i++)
        {
            building.points[i] = new Vector2((building.points[i].x -cityCenter.x) / 10000, (building.points[i].y - cityCenter.y) / 10000); 
        }
        building.height = building.height / 10000.0f;

        meshFilter = GetComponent<MeshFilter>();

        Mesh msh = new Mesh();
        List<int> triangles = new List<int>();

        //vertices claqués au sol
        List<Vector3> vert = new List<Vector3>();
        /*for (int i = 0; i < building.points.Count; i++)
        {
            if (i == 1)
            {
                vert.Add(new Vector3(centerfaceHaut.x, building.height, centerfaceHaut.z));
            }
            else
            {
                vert.Add(new Vector3(building.points[i].x, 0, building.points[i].y));
            }
        }*/


        //vertices en bas
        for (int i = 0; i < building.points.Count; i++)
        {
            vert.Add(new Vector3(building.points[i].x, 0, building.points[i].y));
        }
        //vertices en l'air
        for (int i = 0; i < building.points.Count; i++)
        {
            vert.Add(new Vector3(building.points[i].x, building.height, building.points[i].y));
        }

        msh.vertices = vert.ToArray();

        //tesselation de la face du bas
        List<double> testBas = new List<double>();
        int sizeBAs = 0;
        for (int i = 0; i < vert.Count/2; i++)
        {
            testBas.Add(vert[sizeBAs].x);
            testBas.Add(vert[sizeBAs].z);
            sizeBAs++;
        }
        List<int> tessalationBas = EarcutNet.earcut.Tessellate(testBas.ToArray(), new int[] { });
        triangles.InsertRange(0, tessalationBas);
        
        //tesselation de la face du haut
        List<double> test = new List<double>();
        int size = building.points.Count * 2;
        for (int i = 0; i < vert.Count / 2; i++)
        {
            test.Add(vert[size-1].x);
            test.Add(vert[size-1].z);
            size--;
        }
        List<int> tessalationHaut = EarcutNet.earcut.Tessellate(test.ToArray(), new int[] { });
        for (int i = 0; i < tessalationHaut.Count; i++)
        {
            tessalationHaut[i] = tessalationHaut[i] + building.points.Count;//mise a niveau pour les indices car la tesselation n'a pas tout le tab sinon il ferait une seul face 
        }                                                                   //avec la face du haut et du bas
        triangles.InsertRange(triangles.Count, tessalationHaut);

        //faces latéralles
         for (int i = 0; i < building.points.Count - 1; i++)
         {
             triangles.Add(i);
             triangles.Add(i + 1);
             triangles.Add(i + building.points.Count);

             triangles.Add(i + 1);
             triangles.Add(i + building.points.Count + 1);
            triangles.Add(i + building.points.Count);
        }
        triangles.Add(building.points.Count -1);
        triangles.Add(0);
        triangles.Add(vert.Count - 1);

        triangles.Add(0);
        triangles.Add(building.points.Count + 2);
        triangles.Add(vert.Count - 1);

        msh.triangles = triangles.ToArray();
        GetComponent<MeshRenderer>().material = mat;
        meshFilter.mesh = msh;
    }
}

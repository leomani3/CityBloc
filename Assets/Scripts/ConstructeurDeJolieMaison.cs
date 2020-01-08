using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructeurDeJolieMaison : MonoBehaviour
{
    public List<Vector3> coordinates;

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construct()
    {

    }
}

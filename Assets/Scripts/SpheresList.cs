using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpheresList", menuName = "WorldObjects/SpheresList", order = 1)]
public class SpheresList : ScriptableObject
{
    [SerializeField]
    private Vector2 sizeRange = new Vector2(0.2f, 1.5f);
    [SerializeField]
    private int numOfSpheres = 10;
    [SerializeField]
    private float areaRadiusSize = 20;

    [SerializeField]
    private List<Sphere> spheresList = new List<Sphere>();
    private Sphere tempSphere;

    public int SphereCount
    {
        get
        {
            if (spheresList.Count == 0)
                GenerateSpheres();
            return spheresList.Count;
        }
    }
    public Sphere[] Spheres
    {
        get
        {
            if (spheresList.Count == 0)
                GenerateSpheres();
            return spheresList.ToArray();
        }
    }

    public void ClearSpheres()
    {
        spheresList.Clear();
    }

    private void GenerateSpheres()
    {
        for(int i = 0; i < numOfSpheres; i++)
        {
            tempSphere = new Sphere();
            tempSphere.radius = Random.Range(sizeRange.x, sizeRange.y);
            tempSphere.position = RandomPostion(tempSphere.radius);
            Color color = Random.ColorHSV();
            bool metal = Random.value < 0.5f;
            tempSphere.albedo = metal ? Vector4.zero : new Vector4(color.r, color.g, color.b);
            tempSphere.specular = metal ? new Vector4(color.r, color.g, color.b) : new Vector4(0.4f, 0.4f, 0.4f); ;
            spheresList.Add(tempSphere);
        }
    }

    private Vector3 RandomPostion(float radius)
    {
        Vector2 position = Random.insideUnitCircle * areaRadiusSize;
        return new Vector3(position.x, tempSphere.radius, position.y);
    }

}

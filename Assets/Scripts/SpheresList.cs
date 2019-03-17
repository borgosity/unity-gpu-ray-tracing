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
    private GameObject spherePrefab;
    [SerializeField]
    private Vector3 parentInitialPosition;
    [SerializeField]
    private GameObject parentPrefab;
    [SerializeField]
    private List<GameObject> spheresList = new List<GameObject>();
    private GameObject tempSphere = null;
    private GameObject parentObject;

    public int SphereCount
    {
        get
        {
            if (spheresList.Count == 0)
                GenerateSpheres();
            return spheresList.Count;
        }
    }
    public GameObject[] Spheres
    {
        get
        {
            if (spheresList.Count == 0)
                GenerateSpheres();
            return spheresList.ToArray();
        }
    }

    private void OnDisable()
    {
        spheresList.Clear();
    }

    private void GenerateSpheres()
    {
        if (parentObject == null)
        {
            parentObject = Instantiate(parentPrefab);
            parentObject.transform.position = parentInitialPosition;
        }

        for(int i = 0; i < numOfSpheres; i++)
        {
            tempSphere = Instantiate(spherePrefab);
            tempSphere.transform.SetParent(parentObject.transform);
            tempSphere.transform.position = RandomPostion();
            spheresList.Add(tempSphere);
        }
    }

    private Vector3 RandomPostion()
    {
        Vector2 position = Random.insideUnitCircle * areaRadiusSize;
        return new Vector3(position.x, 0, position.y);
    }

}

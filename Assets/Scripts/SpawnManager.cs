using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform path1;
    public Transform path2;
    public Transform metroride;
    private List<Transform> nodes1;
    private List<Transform> nodes2;
    private List<Transform> metrorideNode;
    public GameObject[] animalPrefabs;
    public GameObject rockPrefabs;
    private float startSpawnRangeX= -54f;
    private float endSpawnRangeX = 200f;
    private float spawnRangeY= 17.28f;
    private float startSpawnRangeZ=209;
    private float endSpawnRangeZ = 698;

    // Start is called before the first frame update
    void Start()
    {
        //path1 nodes
        Transform[] path1Transforms = path1.GetComponentsInChildren<Transform>();
        nodes1 = new List<Transform>();
        for (int i = 0; i < path1Transforms.Length; i++)
        {
            if (path1Transforms[i] != path1.transform)
            {
                // Debug.Log(pathTransforms[i].name);
                nodes1.Add(path1Transforms[i]);
            }
        }
        //path2 nodes
        Transform[] path2Transforms = path2.GetComponentsInChildren<Transform>();
        nodes2 = new List<Transform>();
        for (int i = 0; i < path2Transforms.Length; i++)
        {
            if (path2Transforms[i] != path2.transform)
            {
                // Debug.Log(pathTransforms[i].name);
                nodes2.Add(path2Transforms[i]);
            }
        }
        //metroride nodes
        Transform[] metrorideTransform = metroride.GetComponentsInChildren<Transform>();
        metrorideNode = new List<Transform>();
        for(int i=0;i< metrorideTransform.Length; i++)
        {
            if (metrorideTransform[i] != metroride.transform)
            {
                metrorideNode.Add(metrorideTransform[i]);
            }
        }
        SpawnRandomAnimal();
        SpawnMetroride();
        InvokeRepeating("SpawnMetroride", 14, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnRandomAnimal()
    {
        for (int i = 0; i < 100; i++)
        {
            int animaleIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(startSpawnRangeX, endSpawnRangeX), spawnRangeY, Random.Range(startSpawnRangeZ, endSpawnRangeZ));
            Instantiate(animalPrefabs[animaleIndex], spawnPos, animalPrefabs[animaleIndex].transform.rotation);
        }
    }
    void SpawnMetroride()
    {
        for(int i = 0; i<metrorideNode.Count; i++)
        {
            Instantiate(rockPrefabs, metrorideNode[i].position + new Vector3(0, 45, 0), rockPrefabs.transform.rotation);
        }
        

    }
    
}

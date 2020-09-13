using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
    public GameObject prefab;
    public Transform point;
    public float livingTime;

    public void Instantiate()
    {
        GameObject instantiatedObject = Instantiate(prefab, point.position, Quaternion.identity) as GameObject;
        if (livingTime > 0f)
        {
            Destroy(instantiatedObject, livingTime);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

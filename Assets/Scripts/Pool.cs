using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private List<PoolObject> poolsObjects;
    private Transform objectsParentTransform;

    private void AddObjectToPool(PoolObject poolObject, Transform parentTransform)
    {
        GameObject cubeInstance = GameObject.Instantiate(poolObject.gameObject);
        cubeInstance.name = poolObject.name;
        cubeInstance.transform.SetParent(parentTransform);
        poolsObjects.Add(cubeInstance.GetComponent<PoolObject>());
        cubeInstance.SetActive(false);
    }

    public void Init(int count, PoolObject poolObject, Transform parentTransform)
    {
        poolsObjects = new List<PoolObject>();
        objectsParentTransform = parentTransform;

        for (int i = 0; i < count; i++)
        {
            AddObjectToPool(poolObject, parentTransform);
        }
    }

    public PoolObject GetPoolObject()
    {
        for (int i = 0; i < poolsObjects.Count; i++)
        {
            if (poolsObjects[i].gameObject.activeInHierarchy == false)
                return poolsObjects[i];
        }

        AddObjectToPool(poolsObjects[0], objectsParentTransform);
        return poolsObjects[poolsObjects.Count - 1];
    }
}
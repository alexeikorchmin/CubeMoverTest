using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform poolParent;
    [SerializeField] private int count;

    private Queue<GameObject> queue = new Queue<GameObject>();

    public void PutInPool(GameObject go)
    {
        go.SetActive(false);
        go.transform.parent = poolParent;
        go.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        queue.Enqueue(go);
    }

    public GameObject GetFromPool(Transform startTransform)
    {
        if (queue.Count <= 0)
            GenerateObject(cubePrefab);

        var go = queue.Dequeue();
        go.transform.parent = startTransform;
        go.transform.SetPositionAndRotation(startTransform.position, startTransform.rotation);
        go.SetActive(true);
        Debug.Log("GetFromPool");
        return go;
    }

    private void Awake()
    {
        FillPool();
    }

    private void FillPool()
    {
        for (var i = 0; i < count; i++)
        {
            GenerateObject(cubePrefab);
        }
    }

    private void GenerateObject(GameObject prefab)
    {
        var go = Instantiate(prefab, Vector3.zero, Quaternion.identity, poolParent);
        PutInPool(go);
    }
}
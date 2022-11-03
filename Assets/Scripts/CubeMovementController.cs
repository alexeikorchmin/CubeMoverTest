using UnityEngine;
using DG.Tweening;

public class CubeMovementController : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform cubeStartPosition;
    [SerializeField] private float timeToDestination;
    [SerializeField] private float spawnTime;
    [SerializeField] private float distancePositionZ;

    private float time;
    private float temp;

    private bool CanParse(string value)
    {
        if (float.TryParse(value, out temp))
            return true;
        else
            return false;
    }

    public void SetSpeedValue(string value)
    {
        if (CanParse(value))
            timeToDestination = temp;
    }

    public void SetSpawnTimeValue(string value)
    {
        if (CanParse(value))
            spawnTime = temp;
    }

    public void SetDistanceValue(string value)
    {
        if (CanParse(value))
            distancePositionZ = temp;
    }

    private void Update()
    {
        time += Time.deltaTime;
        CubeBehaviour();
    }

    private void CubeBehaviour()
    {
        if (time < spawnTime) return;

        GameObject cubeInstance = Instantiate(cubePrefab, cubeStartPosition.position, Quaternion.identity);
        MoveCube(cubeInstance);
        Destroy(cubeInstance, timeToDestination);
        time = 0f;
    }

    private void MoveCube(GameObject cube)
    {
        cube.transform.DOLocalMoveZ(distancePositionZ, timeToDestination);
    }
}
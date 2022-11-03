using UnityEngine;
using DG.Tweening;

public class CubeMovementController : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform cubeStartPosition;
    [SerializeField] private float speed;
    [SerializeField] private float spawnTime;
    [SerializeField] private float distancePositionZ;

    private float timeToDestination;
    private float gameTime;
    private float temp;

    public void SetSpeedValue(string value)
    {
        if (CanParse(value))
        {
            speed = temp;

            if (speed == 0)
                timeToDestination = 0;
            else
                timeToDestination = distancePositionZ / speed;
        }
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

    private bool CanParse(string value)
    {
        if (float.TryParse(value, out temp))
            return true;
        else
            return false;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        CubeBehaviour();
    }

    private void CubeBehaviour()
    {
        if (gameTime < spawnTime) return;

        GameObject cubeInstance = Instantiate(cubePrefab, cubeStartPosition.position, Quaternion.identity);
        MoveCube(cubeInstance);
        Destroy(cubeInstance, timeToDestination);
        gameTime = 0f;
    }

    private void MoveCube(GameObject cube)
    {
        cube.transform.DOLocalMoveZ(distancePositionZ, timeToDestination);
    }
}
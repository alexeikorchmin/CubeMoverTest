using UnityEngine;
using DG.Tweening;

public class CubeMovementController : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform cubeStartPosition;
    [SerializeField] private float speed;
    [SerializeField] private float spawnTime;
    [SerializeField] private float distance;

    private float timeToDestination;
    private float gameTime;
    private float temp;

    public void SetSpeedValue(string value)
    {
        if (CanParse(value))
        {
            speed = temp;
            timeToDestination = distance / speed;
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
            distance = temp;
    }

    private bool CanParse(string value)
    {
        if (string.IsNullOrEmpty(value)) return false;
        
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
        cube.transform.DOLocalMoveZ(distance, timeToDestination).SetEase(Ease.Linear);
    }
}
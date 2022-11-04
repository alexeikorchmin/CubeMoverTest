using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CubeMovementController : MonoBehaviour
{
    [SerializeField] private PoolController poolController;
    [SerializeField] private Transform cubeStartPosition;
    [SerializeField] private float speed;
    [SerializeField] private float spawnTime;
    [SerializeField] private float distance;

    private float timeToDestination;
    private float gameTime;
    private float temp;

    private bool isSpeedValueInput;
    private bool isSpawnTimeValueInput;
    private bool isDistanceValueInput;

    public void SetSpeedValue(string value)
    {
        if (CanParse(value, ref isSpeedValueInput))
        {
            speed = temp;
            timeToDestination = distance / speed;
        }
    }

    public void SetSpawnTimeValue(string value)
    {
        if (CanParse(value, ref isSpawnTimeValueInput))
            spawnTime = temp;
    }

    public void SetDistanceValue(string value)
    {
        if (CanParse(value, ref isDistanceValueInput))
            distance = temp;
    }

    private bool CanParse(string value, ref bool isValueInput)
    {
        if (float.TryParse(value, out temp) && temp != 0)
        {
            isValueInput = true;
            return true;
        }
        else
        {
            isValueInput = false;
            return false;
        }
    }

    private void Update()
    {
        if (!isSpeedValueInput || !isSpawnTimeValueInput || !isDistanceValueInput)
            return;

        gameTime += Time.deltaTime;
        CubeBehaviour();
    }

    private void CubeBehaviour()
    {
        if (gameTime < spawnTime) return;

        var cube = poolController.GetFromPool(cubeStartPosition);
        MoveCube(cube);
        StartCoroutine(DelayCubeDisactivation(cube, timeToDestination));
        gameTime = 0f;
    }

    private void MoveCube(GameObject cube)
    {
        cube.transform.DOLocalMoveZ(distance, timeToDestination).SetEase(Ease.Linear);
    }

    private IEnumerator DelayCubeDisactivation(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        poolController.PutInPool(go);
    }
}
using UnityEngine;
using TMPro;

public class InputFieldsHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputSpeed;
    [SerializeField] private TMP_InputField inputSpawnTime;
    [SerializeField] private TMP_InputField inputDistance;

    [SerializeField] private CubeMovementController cubeMovementController;

    private void Awake()
    {
        inputSpeed.onValueChanged.AddListener(cubeMovementController.SetSpeedValue);
        inputSpawnTime.onValueChanged.AddListener(cubeMovementController.SetSpawnTimeValue);
        inputDistance.onValueChanged.AddListener(cubeMovementController.SetDistanceValue);
    }
}
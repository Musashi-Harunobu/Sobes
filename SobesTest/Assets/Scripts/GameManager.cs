using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ghostPrefab;
    public bool isFirstRun = true;
    public static int LapCount = 1;

    private GameObject _ghost;
    

    void Start()
    {
        StartFirstRun();
    }

    public void StartFirstRun()
    {
        isFirstRun = true;
        TrajectoryRecorder.Instance.StartRecording();
    }

    public void StartSecondRun()
    {
        isFirstRun = false;

        TrajectoryRecorder.Instance.StopRecording();

        // Создание призрака
        List<Vector3> recordedPositions = TrajectoryRecorder.Instance.GetRecordedPositions();
        List<Quaternion> recordedRotations = TrajectoryRecorder.Instance.GetRecordedRotations();

        _ghost = Instantiate(ghostPrefab, recordedPositions[0], recordedRotations[0]);
        _ghost.GetComponent<GhostController>().Initialize(recordedPositions, recordedRotations);

        LapCount++;
    }

    
}
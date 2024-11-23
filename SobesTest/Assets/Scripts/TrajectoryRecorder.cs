using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRecorder : MonoBehaviour
{
    public static TrajectoryRecorder Instance;

    // Структура для хранения позиции и поворота
    private struct FrameData
    {
        public Vector3 position;
        public Quaternion rotation;

        public FrameData(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    private List<FrameData> _recordedFrames = new List<FrameData>();
    private bool _isRecording = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartRecording()
    {
        _recordedFrames.Clear();
        _isRecording = true;
    }

    public void StopRecording()
    {
        _isRecording = false;
    }

    public List<Vector3> GetRecordedPositions()
    {
        List<Vector3> positions = new List<Vector3>();
        foreach (var frame in _recordedFrames)
        {
            positions.Add(frame.position);
        }
        return positions;
    }

    public List<Quaternion> GetRecordedRotations()
    {
        List<Quaternion> rotations = new List<Quaternion>();
        foreach (var frame in _recordedFrames)
        {
            rotations.Add(frame.rotation);
        }
        return rotations;
    }

    void Update()
    {
        if (_isRecording)
        {
            _recordedFrames.Add(new FrameData(transform.position, transform.rotation));
        }
    }
}
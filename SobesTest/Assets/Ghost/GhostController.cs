using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float speed = 5f;
    
    private List<Vector3> _positions;
    private List<Quaternion> _rotations;
    private int _currentIndex = 0;
    
    public void Initialize(List<Vector3> recordedPositions, List<Quaternion> recordedRotations)
    {
        _positions = recordedPositions;
        _rotations = recordedRotations;
        _currentIndex = 0;

        // Установить стартовую позицию и поворот
        if (_positions.Count > 0)
        {
            transform.position = _positions[0];
            transform.rotation = _rotations[0];
        }
    }

    void Update()
    {
        if (_positions == null || _rotations == null || _currentIndex >= _positions.Count) return;

        // Перемещаемся к следующей позиции
        transform.position = Vector3.MoveTowards(transform.position, _positions[_currentIndex], speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotations[_currentIndex], speed * 50 * Time.deltaTime);

        // Проверка достижения точки
        if (Vector3.Distance(transform.position, _positions[_currentIndex]) < 0.1f &&
            Quaternion.Angle(transform.rotation, _rotations[_currentIndex]) < 1f)
        {
            _currentIndex++;
        }
    }
}
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _firstLap = false;

    private void Start()
    {
        // Находим GameManager на сцене
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Triggered by: {other.name}");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the finish trigger.");

            if (!_firstLap)
            {
                _gameManager.StartSecondRun();
                _firstLap = true;
            }
        }

        if (other.CompareTag("Ghost"))
        {
            Destroy(other);
        }
    }
}
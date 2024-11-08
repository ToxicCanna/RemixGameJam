using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private CameraLocationScriptableObject cameraLocation;
    private int _currentFloor = 0;
    public void ChangeFloor(float playerX, float playerY)
    {
        _currentFloor = 0;
        if (playerX < 6)
        {

        }
        else if (playerX < 19)
        {
            _currentFloor = _currentFloor + 1;
        }
        else
        {
            _currentFloor = _currentFloor + 2;
        }

        if (playerY < 5)
        {

        }else if (playerY < 18)
        {
            _currentFloor = _currentFloor + 3;
        }
        else 
        {
            _currentFloor = _currentFloor + 6;
        }
        transform.position = cameraLocation.cameraLocations[_currentFloor];
    }
}

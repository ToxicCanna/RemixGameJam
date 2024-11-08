using UnityEngine;

[CreateAssetMenu(fileName = "CameraLocationScriptableObject", menuName = "Scriptable Objects/CameraLocationScriptableObject")]
public class CameraLocationScriptableObject : ScriptableObject
{
    [SerializeField] public Vector3[] cameraLocations;
}

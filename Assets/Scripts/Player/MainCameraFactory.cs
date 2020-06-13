using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFactory : MonoBehaviour
{
    [SerializeField] private MainCameraView _mainCameraPrefab;
    [SerializeField] private Transform _mainCameraStartPosition;
    [SerializeField] private Transform _parent;


    public MainCameraView Create()
    {
        var mainCamera = Instantiate(_mainCameraPrefab, _mainCameraStartPosition.position, Quaternion.identity);
        SetParent(mainCamera);
        return mainCamera;
    }

    private void SetParent(MainCameraView child)
    {
        child.transform.SetParent(_parent.transform);
    }
}

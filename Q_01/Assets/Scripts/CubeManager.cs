using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    /*
     * Awake에서 큐브 포지션을 호출하고 있는데 큐브가 아직 Start에서 실행되기 이전 상태이므로 큐브 컨트롤러가 nullreference가 뜨는 상황
     * 즉 큐브가 생성되기 전에 포지션을 설정하려고 하기 때문에 발생하는 에러
    private void Awake()
    {
        SetCubePosition(3, 0, 3);
    }
    */

    private void Start()
    {
        CreateCube();
        SetCubePosition(3, 0, 3); // 큐브가 생성된 후 위치 설정을 하기 위해 Awake가 아닌 Start로 이동
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}

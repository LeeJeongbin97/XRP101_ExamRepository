using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    /*
     * Awake���� ť�� �������� ȣ���ϰ� �ִµ� ť�갡 ���� Start���� ����Ǳ� ���� �����̹Ƿ� ť�� ��Ʈ�ѷ��� nullreference�� �ߴ� ��Ȳ
     * �� ť�갡 �����Ǳ� ���� �������� �����Ϸ��� �ϱ� ������ �߻��ϴ� ����
    private void Awake()
    {
        SetCubePosition(3, 0, 3);
    }
    */

    private void Start()
    {
        CreateCube();
        SetCubePosition(3, 0, 3); // ť�갡 ������ �� ��ġ ������ �ϱ� ���� Awake�� �ƴ� Start�� �̵�
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

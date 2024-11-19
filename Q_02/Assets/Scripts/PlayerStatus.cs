using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float _moveSpeed; // ���� ������ ��� ����

    public float MoveSpeed
    {
        /*
         * get�����ڿ� set�����ڰ� �� �� �ڱ� �ڽ��� �����ϰ� �־� ���� ��� �߻�
         * _moveSpeed ������Ƽ�� ��� ������ �����Ͽ� �����ϵ��� ���� �ʿ�
         */
        get => _moveSpeed; // get���� ��� ���� ��ȯ
        private set => _moveSpeed = value; // ��� ������ �� ����
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float _moveSpeed; // 값을 저장할 백업 변수

    public float MoveSpeed
    {
        /*
         * get접근자와 set접근자가 둘 다 자기 자신을 참조하고 있어 무한 재귀 발생
         * _moveSpeed 프로퍼티를 백업 변수로 저장하여 참조하도록 수정 필요
         */
        get => _moveSpeed; // get에서 백업 변수 반환
        private set => _moveSpeed = value; // 백업 변수에 값 설정
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        MovePosition();
    }

    private void MovePosition()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero) return;

        direction.Normalize(); // Nomalize를 사용하여 벡터 크기를 1로 설정, 대각선으로 이동할 때 속도가 증가하지 않게 하기 위함
        
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction);
    }
}

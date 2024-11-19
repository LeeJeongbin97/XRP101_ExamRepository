using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private CustomObjectPool _bulletPool;
    [SerializeField] private float _fireCooltime;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    // Player의 범위를 벗어났을 때 트리거 중지
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StopFire();
        }
    }

    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            yield return _wait;

            // 타겟을 바라보도록 Turret의 Muzzle Point 회전값 설정
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0; // y축은 고정, 수평 회전만 조정

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = targetRotation;

            // transform.rotation = Quaternion.LookRotation(new Vector3(
            //     target.position.x,
            //     0,
            //     target.position.z)
            // );

            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            bullet.OnTaken(target);
            
        }
    }

    private void Fire(Transform target)
    {
        // 기존 코드는 무한 루프 상황 FireRoutine이 코루틴으로 실행되고 있어 Fire은 반복적으로 호출되면 안됨
        // _coroutine = StartCoroutine(FireRoutine(target));

        if (_coroutine == null)
        {
           _coroutine = StartCoroutine(FireRoutine(target));
        }
    }

    // 코루틴 중지(발사 중지)
    private void StopFire()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

}

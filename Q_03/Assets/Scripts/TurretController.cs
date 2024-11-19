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

    // Player�� ������ ����� �� Ʈ���� ����
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

            // Ÿ���� �ٶ󺸵��� Turret�� Muzzle Point ȸ���� ����
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0; // y���� ����, ���� ȸ���� ����

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
        // ���� �ڵ�� ���� ���� ��Ȳ FireRoutine�� �ڷ�ƾ���� ����ǰ� �־� Fire�� �ݺ������� ȣ��Ǹ� �ȵ�
        // _coroutine = StartCoroutine(FireRoutine(target));

        if (_coroutine == null)
        {
           _coroutine = StartCoroutine(FireRoutine(target));
        }
    }

    // �ڷ�ƾ ����(�߻� ����)
    private void StopFire()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

}

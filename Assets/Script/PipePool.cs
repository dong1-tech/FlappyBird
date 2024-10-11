using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
public class PipePool : MonoBehaviour
{
    private ObjectPool<PipeController> _pipePool;
    [SerializeField] private PipeController _pipe;
    [SerializeField] private float _timeToGet;
    [SerializeField] private int _poolCapacity;
    public static PipePool instance;
    private float _countTime;
    void Awake()
    {
        instance = this;
        _pipePool = new ObjectPool<PipeController>(CreatePool, OnTakeFromPool, OnReleaseToPool, null, true, _poolCapacity);
    }
    void Update()
    {
        if (_timeToGet <= _countTime)
        {
            _pipePool.Get();
            _countTime = 0;
        }
        else
        {
            _countTime += Time.deltaTime;
        }
    }
    private PipeController CreatePool()
    {
        PipeController instance = Instantiate(_pipe, Vector3.zero, Quaternion.identity);
        instance.gameObject.SetActive(false);
        return instance;
    }
    private void OnTakeFromPool(PipeController instance)
    {
        instance.transform.position = new Vector3(3, Random.Range(-2.5f, 0), 0);
        instance.transform.rotation = Quaternion.identity;
        instance.gameObject.SetActive(true);
    }
    private void OnReleaseToPool(PipeController instance)
    {
        instance.gameObject.SetActive(false);
    }
    public void ReleaseObj(PipeController instance)
    {
        _pipePool.Release(instance);
    }
}

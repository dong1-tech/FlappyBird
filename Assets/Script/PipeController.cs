using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToRelease;
    private float _countTime;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if(gameObject.activeInHierarchy){
            if(_timeToRelease <= _countTime){
                PipePool.instance.ReleaseObj(this);
                _countTime = 0;
            } else{
                _countTime += Time.deltaTime;
            }
        }
        else{return;}
    }
}

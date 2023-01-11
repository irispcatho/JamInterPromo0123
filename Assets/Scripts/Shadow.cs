using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smooth;
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(_target.position.x + _offset.x, transform.position.y, _target.position.z + _offset.z),
            _smooth * Time.deltaTime);
    }
}

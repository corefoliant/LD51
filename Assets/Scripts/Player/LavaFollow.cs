using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFollow : MonoBehaviour
{
    private Transform _lavaObject;
    private Transform _playerObject;
    private Material _lavaObjectMaterial;
    private Vector2 _texOffset;
    private Vector3 _startOffsetPosition;

    private void Start()
    {
        _lavaObject = gameObject.transform;
        _playerObject = GameObject.FindGameObjectWithTag("Player").transform;
        _lavaObjectMaterial = GetComponent<Renderer>().material;
        _texOffset = _lavaObjectMaterial.mainTextureScale;
        _startOffsetPosition = transform.position - _playerObject.position;
    }

    private void Update()
    {
        _lavaObject.position = _startOffsetPosition + new Vector3(_playerObject.position.x, 0f, _playerObject.position.z);
        _lavaObjectMaterial.SetTextureOffset("_MainTex", new Vector3((-_playerObject.position.x) / (100f / _texOffset.x), 
            -_playerObject.position.z / (100f / _texOffset.y), 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        TransitionManager.DoTransition("Exnone");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform _hookedTransform;

    private Camera _mainCamera;
    private Collider2D _collider;

    private int _length;
    private int _strength;
    private int _fishCount;

    private List<Fish> _hookedFishes;

    private bool _canMove;

    private Tweener _cameraTween;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _collider = GetComponent<Collider2D>();
        _hookedFishes = new List<Fish>();
    }

    private void Update()
    {
        if(_canMove && Input.GetMouseButtonDown(0))
        {
            Vector3 vector = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position.x = vector.x;
            transform.position = position;
        }
    }

    public void StartFishing()
    {
        _length = IdleManager.instance.length - 20;
        _strength = IdleManager.instance.strength;
        _fishCount = 0;
        float time = (-_length) * 0.1f;

        _cameraTween = _mainCamera.transform.DOMoveY(_length, 1 + time * 0.25f, false).OnUpdate(delegate
        {
            if (_mainCamera.transform.position.y <= -11)
                transform.SetParent(_mainCamera.transform);
        }).OnComplete(delegate
        {
            _collider.enabled = true;
            _cameraTween = _mainCamera.transform.DOMoveY(0, time * 5, false).OnUpdate(delegate
            {
                if (_mainCamera.transform.position.y >= -25f)
                    StopFishing();
            });
        });

        ScreensManager.instance.ChangeScreen(Screens.GAME);
        _collider.enabled = false;
        _canMove = true;
        _hookedFishes.Clear();
    }

    private void StopFishing()
    {
        _canMove = false;
        _cameraTween.Kill(false);
        _cameraTween = _mainCamera.transform.DOMoveY(0, 2, false).OnUpdate(delegate
        {
            if (_mainCamera.transform.position.y >= -11)
            {
                transform.SetParent(null);
                transform.position = new Vector2(transform.position.x, -6);
            }
        }).OnComplete(delegate
        {
            transform.position = Vector2.down * 6;
            _collider.enabled = true;
            int moneyPerCatch = 0;
            for(int i = 0; i < _hookedFishes.Count; i++)
            {
                _hookedFishes[i].transform.SetParent(null);
                _hookedFishes[i].ReserFish();
                moneyPerCatch += _hookedFishes[i].Type.price;
            }
            IdleManager.instance.totalGain = moneyPerCatch;
            ScreensManager.instance.ChangeScreen(Screens.END);
        });
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag("Fish") && _fishCount != _strength)
        {
            _fishCount++;
            Fish component = target.GetComponent<Fish>();
            component.Hooked();
            _hookedFishes.Add(component);
            target.transform.SetParent(transform);
            target.transform.position = _hookedTransform.position;
            target.transform.rotation = _hookedTransform.rotation;
            target.transform.localScale = Vector3.one;

            target.transform.DOShakeRotation(5, Vector3.forward * 45, 10, 90, false).SetLoops(1, LoopType.Yoyo).OnComplete(delegate
            {
                target.transform.rotation = Quaternion.identity;
            });
            if(_fishCount == _strength) 
                StopFishing();
        }     
    }
}

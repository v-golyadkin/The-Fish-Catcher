using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Fish.FishType _type;

    private CircleCollider2D _collider;

    private SpriteRenderer _spriteRenderer;

    private float _screenLeft;

    private Tweener _tweener;

    public Fish.FishType Type
    {
        get { return _type; }
        set
        {
            _type = value;
            _collider.radius = _type.colliderRadius;
            _spriteRenderer.sprite = _type.sprite;
        }
    }

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    public void ReserFish()
    {
        if(_tweener != null)
            _tweener.Kill(false);

        float num = UnityEngine.Random.Range(_type.minLength, _type.maxLength);
        _collider.enabled = true;

        Vector3 position = transform.position;
        position.x = _screenLeft;
        position.y = num;
        transform.position = position;

        float num2 = 1;
        float y = UnityEngine.Random.Range(num - num2, num + num2);
        Vector2 v = new Vector2(-position.x, y);

        float num3 = 3;
        float delay = UnityEngine.Random.Range(0, 2 * num3);
        _tweener = transform.DOMove(v, num3, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(delay).OnStepComplete(delegate
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        });
    }

    public void Hooked()
    {
        _collider.enabled = false;
        _tweener.Kill(false);
    }

    [Serializable]
    public class FishType
    {
        public int price;

        public float fishCount;

        public float minLength;

        public float maxLength;

        public float colliderRadius;

        public Sprite sprite;
    }
}

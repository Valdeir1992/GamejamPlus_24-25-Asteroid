using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour, IDamageable
{
    int CurrentLife;
    private float _speed;
    private Vector3 _direction;
    public static Action<int> OnDestroy;
    [SerializeField] private int _score;
    [SerializeField] private AsteroidSize _size;
    [SerializeField] private int _startLife;
    [SerializeField] private SpriteRenderer _spriteRender;

    private void Start()
    {
        StartCoroutine(Coroutine_CheckDirection());
        CurrentLife = _startLife;
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
        transform.GetChild(0).transform.Rotate(_direction, 3); 
    }
    private IEnumerator Coroutine_CheckDirection()
    {
        while (true)
        {
            if (!_spriteRender.isVisible)
            {
                var character = FindAnyObjectByType<CharacterMediator>();
                if(character == null)
                {
                    Destroy(gameObject);
                    yield break;
                }
                var dir = character.transform.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Setup(Quaternion.AngleAxis(angle, Vector3.forward), 8);
            }
            yield return new WaitForSeconds(10);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CharacterMediator character))
        {
            character.TakeDamage(new Damage() { Amount = 100, Source = "Asteroid" }); 
        }
    }

    public void Setup(Quaternion rotation, float speed)
    {
        transform.rotation = rotation;
        _speed = speed;
    }

    public void TakeDamage(Damage damage)
    {
        CurrentLife -= damage.Amount;
        if (CurrentLife <= 0)
        {
            OnDestroy?.Invoke(_score);
            Destroy(gameObject);

        }
    }
}
public enum AsteroidSize
{
    G,
    M,
    P
}

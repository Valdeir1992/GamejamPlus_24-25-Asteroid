using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class AsteroidBehaviour : MonoBehaviour, IDamageable
{
    private int _currentLife;
    private float _speed;
    private Vector3 _direction; 
    private float _rotateSpeed;
    private int _score;
    private int _xp;  
    private XPController _xpController; 
    private ScoreController _scoreController;
    private CancellationTokenSource _aliveCancellationToken;
    [SerializeField] private SpriteRenderer _spriteRender;

    private void Start()
    {
        StartCoroutine(Coroutine_CheckDirection()); 
        _direction = new Vector3(0, 0, Random.Range(-1, 1));
        _rotateSpeed = Random.Range(-3f, 3f);
        _xpController = FindAnyObjectByType<XPController>();
        _scoreController = FindAnyObjectByType<ScoreController>();
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
        transform.GetChild(0).transform.Rotate(_direction, _rotateSpeed); 
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
                Setup(Quaternion.AngleAxis(angle, Vector3.forward), Mathf.Clamp(Random.Range(2,10) *GameplayController.Dificulty, 2,10));
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
        _currentLife -= damage.Amount;
        if (_currentLife <= 0)
        {
            _scoreController.UpdateScore(_score);
            _xpController.AddXP(_xp,"Asteroid"); 
            Destroy(gameObject);

        }
    } 
    public async void SetupAsteroid(AsteroidSize index)
    {
        try
        {

            switch (index)
            {
                case AsteroidSize.P:
                    _currentLife = 1 * GameplayController.Dificulty;
                    _score = 2;
                    _xp = 2;
                    _spriteRender.sprite = await UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<Sprite>("Asteroid_P").Task;
                    GetComponent<CircleCollider2D>().radius = 0.83f;
                    break;
                case AsteroidSize.M:
                    _currentLife = 2 * GameplayController.Dificulty;
                    _score = 4;
                    _xp = 4;
                    _spriteRender.sprite = await UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<Sprite>("Asteroid_M").Task;
                    GetComponent<CircleCollider2D>().radius = 1.13f;
                    break;
                case AsteroidSize.G:
                    _currentLife = 3 * GameplayController.Dificulty;
                    _score = 8;
                    _xp = 8;
                    _spriteRender.sprite = await UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<Sprite>("Asteroid_G").Task;
                    GetComponent<CircleCollider2D>().radius = 1.89f;
                    break;
            }
        }
        catch
        {

        }
    } 
}
public enum AsteroidSize
{
    G = 2,
    M = 1,
    P = 0
}

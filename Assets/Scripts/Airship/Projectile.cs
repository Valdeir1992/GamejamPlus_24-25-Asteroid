using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed;
    private float _size;
    [SerializeField] private int _damage;
    [SerializeField] private SpriteRenderer _spriteRender;

    private void Start()
    { 
        StartCoroutine(Coroutine_CheckVisibility());
        GetComponent<TrailRenderer>().enabled = true;
    }

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * _speed;

        if (!_spriteRender.isVisible)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player"))
        {
            if(collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(new Damage() { Amount = _damage });
                GetComponent<TrailRenderer>().enabled = false;
            }
            gameObject.SetActive(false);
        }
    }
    public void SetupProjectile(Quaternion quaternion,int damage,int size, float speed)
    {
        _damage += damage;
        _size = +size;
        transform.localScale = Vector3.one * _size;
        _speed = +speed;
        transform.rotation = quaternion;
    }
    private IEnumerator Coroutine_CheckVisibility()
    {
        yield return new WaitUntil(()=>_spriteRender.isVisible);
        do
        {
            yield return new WaitForSeconds(2);
        }
        while (_spriteRender.isVisible);
        GetComponent<TrailRenderer>().enabled = false;
        gameObject.SetActive(false);
    }
}

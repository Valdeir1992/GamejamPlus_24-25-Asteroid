using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed;
    private float _size;
    [SerializeField] private int _damage;
    [SerializeField] private SpriteRenderer _spriteRender;

    private void OnEnable()
    {
        transform.localScale = Vector3.one * _size;
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
        if(collision.TryGetComponent(out IDamageable damageable) && !collision.CompareTag("Player"))
        {
            damageable.TakeDamage(new Damage() { Amount = _damage });
            gameObject.SetActive(false);
        }
    }
    public void SetupProjectile(Quaternion quaternion,int damage,int size, float speed)
    {
        _damage += damage;
        _size = +size;
        _speed = +speed;
        transform.rotation = quaternion;
    }
}

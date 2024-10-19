using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BlockBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterMediator characterMediator))
        {
            characterMediator.TakeDamage(new Damage() { Amount = int.MaxValue });
        }
    }
}

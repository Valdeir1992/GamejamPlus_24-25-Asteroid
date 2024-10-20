using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private bool _isVertical;
    [SerializeField] private Transform _positionRef;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterMediator characterMediator))
        {
            if (_isVertical)
            {
                characterMediator.transform.position = new Vector3(characterMediator.transform.position.x, _positionRef.position.y, 0);
            }
            else
            {
                characterMediator.transform.position = new Vector3(_positionRef.position.x, characterMediator.transform.position.y, 0);
            }
        }
    }
}

using UnityEngine;

public class DestructibleBox : MonoBehaviour
{
    [SerializeField] private float hp = 3f;

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

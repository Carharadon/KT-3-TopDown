using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 3f;

    public bool isPlayerBullet = false;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayerBullet && other.CompareTag("Player"))
        {
            return;
        }

        if (isPlayerBullet && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        if (!isPlayerBullet && other.CompareTag("Player"))
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            return;
        }

        if (!other.CompareTag("Player") && !other.CompareTag("Enemy") && !other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}

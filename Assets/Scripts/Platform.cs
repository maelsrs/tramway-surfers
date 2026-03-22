using UnityEngine;

public class Platform : MonoBehaviour
{
    private const float DestroyX = -10f;
    private const float ScoreX = -3f;

    private bool hasScored;

void Update()
    {
        float speed = GameManager.Instance.CurrentSpeed;
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (!hasScored && transform.position.x < ScoreX)
        {
            hasScored = true;
            ScoreManager.Instance.AddScore();
        }

        if (transform.position.x < DestroyX)
            Destroy(gameObject);
    }
}

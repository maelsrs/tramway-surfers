using UnityEngine;

public class Platform : MonoBehaviour
{
    private const float destroyX = -10f;
    private const float scoreX = -3f;

    private bool hasScored;

    void Update()
    {
        float speed = GameManager.Instance.CurrentSpeed;
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        if (!hasScored && transform.position.x < scoreX)
        {
            hasScored = true;
            ScoreManager.Instance.AddScore();
        }

        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }
}

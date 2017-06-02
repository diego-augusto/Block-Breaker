using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector3 paddleToBall;
    private bool hasStarted;

    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        hasStarted = false;
        paddleToBall = transform.position - paddle.transform.position;
        
    }

    void Update()
    {
        if (!hasStarted)
        {
            transform.position = paddle.transform.position + paddleToBall;

            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }; 
    }
}

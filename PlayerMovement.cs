using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveInput * speed * Time.deltaTime, 0, 0);

        // Flip sprite based on direction
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
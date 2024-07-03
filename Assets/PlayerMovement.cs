using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController
{
    [Header("Starts")]
    public float speed = 5f;

    public float dashDistance = 5f;
    public float dashDuration = 0.3f;

    private bool isDashing;

    private Vector2 dashDirection;
    private Vector2 lastDashDirection;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        this.Move();
        this.Dash();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Vector2 direction = new Vector2(x, y).normalized;
        if(direction != Vector2.zero)
        { 
            transform.parent.Translate(direction * speed * Time.deltaTime);
            PlayerController.Instance.SetAnimMove(true);
        }
        else
        {
            PlayerController.Instance.SetAnimMove(false);
        }

        
    }

    private void Dash()
    {
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dashDirection = new Vector2(xRaw, yRaw).normalized;
        if (dashDirection != Vector2.zero)
        {
            lastDashDirection = dashDirection;
        }
        if (Input.GetButtonDown("Fire2") && !isDashing)
        {
            if (dashDirection == Vector2.zero)
            {
                dashDirection = lastDashDirection;
            }

            StartCoroutine(Dash(dashDirection));
        }
    }

    IEnumerator Dash(Vector2 dashDirection)
    {
        isDashing = true;
        float elapsedTime = 0f;

        Vector2 startPosition = transform.parent.position;
        Vector2 endPosition = startPosition + dashDirection * dashDistance;

        while (elapsedTime < dashDuration)
        {
            transform.parent.position = Vector2.Lerp(startPosition, endPosition, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.parent.position = endPosition;
        isDashing = false;
    }
}

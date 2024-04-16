using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float h, v;
    public float speed;
    public float jumpPower;
    Vector3 dir;
    public bool isJumping = false;
    public Vector3 playerPos;
    public Rigidbody rb;

    public float capture;
    public float maxCapture;
    public Image captureBar;
    public float captureBarAmt;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        capture = 100;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = this.transform.position;
        
        if(capture<=0)
        {
            SceneManager.LoadScene(2);
        }
        captureBarAmt = capture / maxCapture;
        captureBar.fillAmount = captureBarAmt;
    }
    private void FixedUpdate()
    {
        //x and z movement
        Vector3 move = new Vector3(h, 0, v);
        transform.Translate(move * Time.deltaTime * speed);

    }

    public void PlayerWalk(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();
        h = dir.x;
        v = dir.y;
    }
    public void PlayerJump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            rb.AddForce(0, jumpPower, 0, ForceMode.VelocityChange);
            isJumping = true;
        }
    }
}

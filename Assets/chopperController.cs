using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class chopperController : MonoBehaviour
{
    public Myproject11 playerActionAsset;
    public GameObject bullet1;
    public float movementSpeed = 30f;
    public Rigidbody2D player1;
    public bool spawned = false;
    public Rigidbody2D shooter;
    public float bulletSpeed = 100f;
    private InputAction move;
    Vector2 movementInput;
    Vector2 lookPosition;
    public Camera mainCamera;
    public Vector2 shootAngle;
    public float angleDeg = 0f;
    public float fireRate = 0.2f;
    private float nextFire = 0f;

    private void Awake()
    {
        playerActionAsset = new Myproject11();
        
    }
    private void FixedUpdate()
    {
        playerActionAsset.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        playerActionAsset.Player.Fire.performed += DoFire;
        playerActionAsset.Player.Bomb.performed += DoBomb;
        move = playerActionAsset.Player.Move;
        playerActionAsset.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionAsset.Player.Fire.performed -= DoFire;
        playerActionAsset.Player.Bomb.performed -= DoBomb;
        playerActionAsset.Player.Disable();
    }

    public void DoFire(InputAction.CallbackContext obj)
    {
        StartCoroutine(DoDoDoFire());
    }
    public void DoDoFire()
    {
        if(Time.time > nextFire)
        {
        nextFire = Time.time + fireRate;
        GameObject clone = Instantiate(bullet1, this.transform.position + new Vector3(1, -1, 0) * 0.7f, this.transform.rotation * Quaternion.identity);
        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        shooter = clone.GetComponent<Rigidbody2D>();
        shooter.AddForce(new Vector3(1, 0, 0) * bulletSpeed, ForceMode2D.Impulse);
        
        Destroy(clone.gameObject, 1f);
        spawned = true;
        }
    }

    public void DoBomb(InputAction.CallbackContext obj)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(bullet1, this.transform.position + new Vector3(1, -1, 0) * 0.7f, this.transform.rotation * Quaternion.identity);
            Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            shooter = clone.GetComponent<Rigidbody2D>();
            shooter.AddForce(new Vector3(0, 1, 0) * -bulletSpeed, ForceMode2D.Impulse);

            Destroy(clone.gameObject, 1f);
            spawned = true;
        }
    }

    public IEnumerator DoDoDoFire()
    {
        DoDoFire();
        yield return new WaitForSeconds(0.5f);

    }

    public void Move(InputAction.CallbackContext obj)
    {
        player1 = gameObject.GetComponent<Rigidbody2D>();
        float leftNRight = movementInput.x * movementSpeed * Time.fixedDeltaTime;
        float upNDown = movementInput.y * movementSpeed * Time.fixedDeltaTime;
        player1.AddForce(new Vector2(leftNRight, upNDown), ForceMode2D.Impulse);
        
    }
}

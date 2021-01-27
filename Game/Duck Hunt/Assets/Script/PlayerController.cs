using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform PlayerCamera = null;
    public CharacterController Controller = null;
    public GameObject Hand = null;
    public float MouseSensitivity { get; set; }
    public float CameraPitch { get; set; }
    public float WalkSpeed { get; set; }
    public float Gravity { get; set; }
    public float VelocityY;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();

        MouseSensitivity = 3.5f;
        CameraPitch = 0.0f;
        WalkSpeed = 12.0f;
        Gravity = -16.0f;
        VelocityY = 0.0f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    // My functions

    void UpdateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        CameraPitch -= mouseDelta.y * MouseSensitivity;
        CameraPitch = Mathf.Clamp(CameraPitch, -80.0f, 45.0f);

        PlayerCamera.localEulerAngles = Vector3.right * CameraPitch;
        transform.Rotate(Vector3.up * mouseDelta.x * MouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDirection.Normalize();

        if (Controller.isGrounded)
        {
          VelocityY = 0.0f;
        }

        VelocityY += Gravity * Time.deltaTime;
        
        Vector3 velocity = WalkSpeed * (transform.forward * inputDirection.y + transform.right * inputDirection.x) + Vector3.up * VelocityY;
        Controller.Move(velocity * Time.deltaTime);

        if (velocity.x != 0.0f && velocity.y != 0.0f)
        {
            if (_boobingFLag)
            {
                PlayerCamera.position = new Vector3(PlayerCamera.position.x, PlayerCamera.position.y - 0.03f/2, PlayerCamera.position.z);
                Hand.transform.position = new Vector3(Hand.transform.position.x - 0.003f/2, Hand.transform.position.y - 0.002f/2, Hand.transform.position.z);
            }
            else
            {
                PlayerCamera.position = new Vector3(PlayerCamera.position.x, PlayerCamera.position.y + 0.03f/2, PlayerCamera.position.z);
                Hand.transform.position = new Vector3(Hand.transform.position.x + 0.003f/2, Hand.transform.position.y+0.002f/2, Hand.transform.position.z);
            }

            _boobingTimer += Time.deltaTime;
            if (_boobingTimer > _boobingTime)
            {
                _boobingFLag = !_boobingFLag;
                _boobingTimer = 0.0f;
                SoundManagerScript.Play("step");
            }
        }
        

        var posiotion = transform.position;
        posiotion.x = Mathf.Clamp(transform.position.x, 100, 900);
        posiotion.z = Mathf.Clamp(transform.position.z, 100, 900);
        transform.position = posiotion;
    }

    private bool _boobingFLag = false;
    private float _boobingTime = 0.5f;
    private float _boobingTimer;
}

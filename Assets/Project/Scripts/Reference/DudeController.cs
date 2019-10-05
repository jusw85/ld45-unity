using System;
using UnityEngine;

[RequireComponent(typeof(Raycaster))]
public class DudeController : MonoBehaviour {

    public float jumpHeight = 4;
    public float timeToJumpApex = 0.4f;
    public float walkVelocity = 8;

    public float jumpPressedTimeTolerance = 0.1f;
    public float notGroundedJumpTimeTolerance = 0.1f;

    public GameObject mask = null;

    [NonSerialized]
    public Vector3 respawnPoint;
    [NonSerialized]
    public bool canFreeze;
    [NonSerialized]
    public bool isFrozen;

    private Raycaster raycaster;
    private DudeAnimation dudeAnimation;

    private float gravity;
    private float jumpVelocity;
    private Vector3 velocity;

    private bool oldIsGrounded;
    private bool isGrounded;
    private float jumpPressedTime = float.MinValue;
    private float notGroundedJumpTime = float.MinValue;

    private Vector2 moveInput;
    private bool isJumping;

    private void Awake() {
        raycaster = GetComponent<Raycaster>();
        dudeAnimation = GetComponentInChildren<DudeAnimation>();

        UpdateGravity();
        velocity = Vector3.zero;
        respawnPoint = Vector3.zero;

        if (mask != null) {
            GameObject maskInstance = (GameObject)Instantiate(mask, transform.position, Quaternion.identity);
            MaskFollow maskFollow = maskInstance.GetComponent<MaskFollow>();
            maskFollow.target = gameObject;
        }
    }

    private void Start() {
//        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
//        CameraFollow cameraFollow = mainCamera.GetComponent<CameraFollow>();
//        cameraFollow.target = gameObject;
    }

    private void Update() {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Jump") || moveInput.y > 0) {
            //if (Input.GetKeyDown(KeyCode.Space)) {
            jumpPressedTime = Time.time;
        }
        if ((Time.time - jumpPressedTime) <= jumpPressedTimeTolerance) {
            if (isGrounded || (Time.time - notGroundedJumpTime) <= notGroundedJumpTimeTolerance) {
                Jump();
            }
        }

        velocity.x = walkVelocity * moveInput.x;
        velocity.y += gravity * Time.deltaTime;
        Vector3 displacement = velocity * Time.deltaTime;

        Move(displacement);


        if (Input.GetKeyDown(KeyCode.Z) && canFreeze) {
            print("isFreezingThisFrame");
            isFrozen = true;
        }
        if (Input.GetKeyUp(KeyCode.Z) && canFreeze) {
            print("isUnfreezingThisFrame");
            isFrozen = false;
        }

    }

    private void LateUpdate() {
        if (moveInput.x != 0)
            dudeAnimation.SetIsFacingRight(moveInput.x > 0);

        if (isJumping) {
            dudeAnimation.SetJumping();
        } else if (isGrounded) {
            if (velocity.x == 0) {
                dudeAnimation.SetIdle();
            } else {
                dudeAnimation.SetWalking();
            }
        }
    }

    private void OnValidate() {
        UpdateGravity();
        jumpPressedTimeTolerance = Mathf.Clamp(jumpPressedTimeTolerance, 0, float.MaxValue);
        notGroundedJumpTimeTolerance = Mathf.Clamp(notGroundedJumpTimeTolerance, 0, float.MaxValue);
    }

    public void Respawn() {
        transform.position = respawnPoint;
    }

    private void Jump() {
        velocity.y = jumpVelocity;
        isJumping = true;
        jumpPressedTime = float.MinValue;
        notGroundedJumpTime = float.MinValue;
    }

    private void Move(Vector3 displacement) {
        Raycaster.CollisionInfo collisions;

        raycaster.UpdateRaycastOrigins();
        raycaster.HandleCollisions(ref displacement, out collisions);

        transform.Translate(displacement);

        if (collisions.below || collisions.above) {
            velocity.y = 0;
        }
        oldIsGrounded = isGrounded;
        isGrounded = collisions.below;
        if (isGrounded) {
            isJumping = false;
        }
        if (oldIsGrounded && !isGrounded) {
            notGroundedJumpTime = Time.time;
        }
    }

    private void UpdateGravity() {
        gravity = (2 * -jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = -(gravity * timeToJumpApex);
    }

}

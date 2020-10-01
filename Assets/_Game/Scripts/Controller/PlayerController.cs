using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 3;
    public float runSpeed = 6;
    public float JumpStrength = 3.0F;
    public float Gravity = 9.81F;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    private Animator _animator;
    private Transform cameraT;
    public CameraCollision collision;

    private Boolean hasTouchedGroundSinceLastJump;
    private Vector3 _jumpDirection;
    private Rigidbody _rb;

    private IWeapon _equippedWeapon;  
    public SkillBase Skill1;
    public SkillBase Skill2;
    public SkillBase Skill3;

    private void Awake() {
        if (GameManager.Instance.Player == null) {
            GameManager.Instance.Player = gameObject;
            DontDestroyOnLoad(this);
            return;
        }

        GameManager.Instance.Player.transform.SetPositionAndRotation(this.transform.position,
            this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void Start() {
        cameraT = Camera.main.transform;
        _animator = this.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        hasTouchedGroundSinceLastJump = true;
        Cursor.visible = false;
        
        //TODO for testing only, equpid sword if found
        _equippedWeapon = gameObject.GetComponentInChildren<IWeapon>();
    }

    // Update is called once per frame
    public void Update() { 
        if (Time.timeScale == 0) {
            return;
        }

        if (Input.GetButtonDown("Fire1")) {
            attack();
        }

        if (Input.GetButtonUp("Fire1")) {
            _animator.SetBool("Attack", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Skill1.Cast();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Skill2.Cast();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Skill3.Cast();
        }
    }

    public void FixedUpdate() {
        float vertical = Input.GetAxis("Vertical");
        _animator.SetFloat("vertical", vertical);
        float horizontal = Input.GetAxis("Horizontal");
        _animator.SetFloat("horizontal", horizontal);

        Vector2 input = new Vector2(horizontal, vertical);
        Vector2 inputDir = input.normalized;

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        if (inputDir != Vector2.zero)
        {
            if (vertical == 0 && (horizontal > 0 || horizontal < 0))
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
                transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
                _animator.SetFloat("vertical", horizontal);
            }
            else if (vertical > 0)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
                transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                float targetRotation = (Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y) - 180;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
                transform.Translate(-transform.forward * currentSpeed * Time.deltaTime, Space.World);
            }
        }

        //Jump
        float jump = 0;
        if (Input.GetButtonDown("Jump")) {
            _animator.SetTrigger("Jump");
            jump = 15F;
        }
        
        if (jump != 0 && hasTouchedGroundSinceLastJump) {
            hasTouchedGroundSinceLastJump = false;
            _jumpDirection = ((jump * new Vector3(0, 1, 0)) * JumpStrength);
            _rb.AddForce(_jumpDirection * Gravity);
        }
    }

    public void EquipWeapon(IWeapon weapon) {
        this._equippedWeapon = weapon;
    }

    private void attack() {
        if (_equippedWeapon != null) {
            _equippedWeapon.PerformAttack();
        }
    }

    private void aoeattack() {
        if (_equippedWeapon != null) {
            _equippedWeapon.PerfomAOEAttack();
        }
    }

    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == GameLayer.Ground) {
            hasTouchedGroundSinceLastJump = true;
        }

        /*
        //TODO remove this, this is depcrecated now
        if (other.gameObject.tag == "Teleporter")
        {
            //Scene sceneToLoad = SceneManager.GetSceneByName("Arena");
            Scene sceneToLoad = SceneManager.GetSceneAt(0);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            SceneManager.MoveGameObjectToScene(this.gameObject, sceneToLoad);
            SceneManager.UnloadSceneAsync(1);
        }*/
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Animator anim;
    
    int JumpButtonPressed = Animator.StringToHash("JumpButtonPressed");
    int AttackButtonPressed = Animator.StringToHash("AttackButtonPressed");
    int CrouchButtonPressed = Animator.StringToHash("CrouchButtonPressed");

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(JumpButtonPressed);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.ResetTrigger(JumpButtonPressed);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger(AttackButtonPressed);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            anim.ResetTrigger(AttackButtonPressed);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger(CrouchButtonPressed);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.ResetTrigger(CrouchButtonPressed);
        }
    }


    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(Vector2.up * 10f * Time.deltaTime);
        }

    }
}

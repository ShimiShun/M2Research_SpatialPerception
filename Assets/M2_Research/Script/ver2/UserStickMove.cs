using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class UserStickMove : MonoBehaviour {

    public enum Mode
    {
        Normal,
        MoveTowards,
        Lerp,
        Slerp
    };

    //　キャラクターを動かすモード
    [SerializeField]
    private Mode mode;
    //キャラクターコントローラー
    private CharacterController cCon;
    //　キャラクターの速度
    private Vector3 velocity;
    //　前の速度
    private Vector3 oldVelocity;
    //　アニメーター
    private Animator animator;
    //　歩く速さ
    [SerializeField]
    private float moveSpeed = 2f;

    void Start()
    {
        cCon = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {

       
        if (cCon.isGrounded)
        { //　キャラクターコントローラのコライダが地面と接触してるかどうか
            velocity = Vector3.zero;

            velocity = new Vector3(Input.GetAxis("Horizontal2") * moveSpeed, 0f, Input.GetAxis("Vertical2") * moveSpeed);

            if (mode == Mode.MoveTowards)
            {
                velocity = Vector3.MoveTowards(oldVelocity, velocity, moveSpeed * Time.deltaTime);
            }
            else if (mode == Mode.Lerp)
            {
                velocity = Vector3.Lerp(oldVelocity, velocity, moveSpeed * Time.deltaTime);
            }
            else if (mode == Mode.Slerp)
            {
                velocity = Vector3.Slerp(oldVelocity, velocity, moveSpeed * Time.deltaTime);
            }
            oldVelocity = velocity;

            if (velocity.magnitude > 0f)
            {
               // animator.SetFloat("Speed", velocity.magnitude);
                transform.LookAt(transform.position + velocity);
            }
            else
            { //　キーを押している度合いが小さい時
               // animator.SetFloat("Speed", 0f);
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        cCon.Move(velocity * Time.deltaTime);
    }
}

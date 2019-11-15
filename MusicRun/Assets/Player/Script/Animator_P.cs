using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_P : MonoBehaviour
{

    // パラメータ **********************************************************
    Animator animator;
    Rigidbody2D rigid2d;
    // *********************************************************************

    void Start() {
        animator = GetComponent<Animator>();
    }


    //skillcountの更新
    public void SkillCount_Update(int n) {
        animator.SetInteger("SkillCount", n);
    }

    //重力移動時
    public void Animation_Gmove() {
        animator.SetBool("Flag_Gmove", true);
    }

    //ダメージを受けた時
    public void Animation_Damage() {
        animator.Play("Damage");
        animator.SetBool("Flag_Gmove", false);
    }

    //地面に立った時
    public void Animation_Land() {
        animator.SetBool("Flag_Gmove", false);
        animator.Play("Land");
    }
}

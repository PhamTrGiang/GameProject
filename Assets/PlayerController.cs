using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MyBehaviourScript
{
    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }
    public override void Awake()
    {
        base.Awake();
        if (instance != null && instance == this) return;
        instance = this;
    }
    public override void Update()
    {
        base.Update();

    }

    public void SetAnimMove(bool value)
    {
        PlayerAnimation.Instance.SetBool("Move", value);
    }
    public void SetAnimAttack()
    {
        PlayerAnimation.Instance.SetTrigger("Attack");
    }
}

using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraFollow : MyBehaviourScript
{
    public Transform Target;
    public Camera mainCamera;

    public override void LoadComponent()
    {
        base.LoadComponent();
        mainCamera = FindObjectOfType<Camera>();
    }
    public override void Update()
    {
        base.Update();
        this.FollowTarget();
    }

    private void FollowTarget()
    {
        transform.position = Vector2.Lerp(transform.position,Target.position,0.5f);
    }
}

using UnityEngine;

public class AdvanceRowCommand : ICommand
{
    public void Execute(Transform transform, float speed)
    {
        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }
}
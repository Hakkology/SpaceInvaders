using UnityEngine;

public class MoveRightCommand : ICommand
{
    public void Execute(Transform transform, float speed)
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
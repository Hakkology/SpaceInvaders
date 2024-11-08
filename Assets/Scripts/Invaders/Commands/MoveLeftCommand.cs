using UnityEngine;

public class MoveLeftCommand : ICommand
{
    public void Execute(Transform transform, float speed)
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
using UnityEngine;

public interface ICommand
{
    void Execute(Transform transform, float speed);
}

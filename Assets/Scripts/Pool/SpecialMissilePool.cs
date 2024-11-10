using UnityEngine;

public class SpecialMissilePool : ObjectPool
{
    public static SpecialMissilePool Instance { get; private set; }

    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        base.Awake();
    }
}
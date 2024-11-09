public class MissilePool : ObjectPool
{
    public static MissilePool Instance { get; private set; }

    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        base.Awake();
    }
}
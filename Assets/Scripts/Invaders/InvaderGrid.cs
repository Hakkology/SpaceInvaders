using UnityEngine;
using System.Collections.Generic;

public class InvaderGrid : MonoBehaviour 
{
    // düşman oluşturma gridi
    [Header("Enemy Spawn Grid")]
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public float rowSpan = 2.0f;
    public float columnSpan = 2.0f;
    public float gridOffset = 3.0f;


    // düşman hızları
    private Vector3 _direction = Vector3.right;
    private float speed;
    [Header("Enemy Speed")]
    public float minSpeed = .5f;
    public float maxSpeed = 2.5f;

    // düşman saldırıları
    [Header("Enemy Missiles")]
    public Projectile InvaderMissile;
    public float missileAttackRate = 1.0f;


    public int amountKilled { get; private set; }
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;

    private List<Transform> _leftMostInvaders;
    private List<Transform> _rightMostInvaders;

    void Awake() 
    {
        _leftMostInvaders = new List<Transform>();
        _rightMostInvaders = new List<Transform>();

        for (int row = 0; row < this.rows; row++)
        {
            float width = rowSpan * (this.columns - 1);
            float height = columnSpan * (this.rows - 1);

            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + gridOffset + row * columnSpan, 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * rowSpan;
                invader.transform.position = position;
                invader._killed += OnInvaderKilled;

                // Sol ve sağ invader'ları listeye ekle
                if (col == 0)
                    _leftMostInvaders.Add(invader.transform);
                else if (col == columns - 1)
                    _rightMostInvaders.Add(invader.transform);
            }
        }
    }

    void Start() 
    {
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
    }

    void Update() 
    {
        this.speed = Mathf.Lerp(minSpeed, maxSpeed, percentKilled);

        this.transform.position += _direction * this.speed * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        Transform leftMost = LeftMostInvader();
        Transform rightMost = RightMostInvader();

        if (_direction == Vector3.right && rightMost != null && rightMost.position.x >= rightEdge.x - 1.0f)
        {
            AdvanceRow();
        }
        else if (_direction == Vector3.left && leftMost != null && leftMost.position.x <= leftEdge.x + 1.0f)
        {
            AdvanceRow();
        }
    }

    private Transform LeftMostInvader()
    {
        Transform leftMost = null;
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;
            if (leftMost == null || invader.position.x < leftMost.position.x)
                leftMost = invader;
        }
        return leftMost;
    }

    private Transform RightMostInvader()
    {
        Transform rightMost = null;
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;
            if (rightMost == null || invader.position.x > rightMost.position.x)
                rightMost = invader;
        }
        return rightMost;
    }
    private void AdvanceRow()
    {
        _direction = _direction == Vector3.right ? Vector3.left : Vector3.right;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void MissileAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;
            
            if (Random.value < (1.0f / (float)this.amountAlive))
            {
                Projectile missile = Instantiate(this.InvaderMissile, invader.position, Quaternion.identity);
                break;
            }
        }
    }


    private void OnInvaderKilled()
    {
        this.amountKilled++;
    }
}

using UnityEngine;

public class InvaderGrid : MonoBehaviour 
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public float rowSpan = 2.0f;
    public float columnSpan = 2.0f;
    public float gridOffset = 3.0f;


    private Vector3 _direction = Vector3.right;
    public float speed = 2.0f;

    void Awake() {
        for (int row = 0; row < this.rows; row++)
        {
            float width = rowSpan * (this.columns -1);
            float height = columnSpan * (this.rows -1);

            Vector2 centering = new Vector2(-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + gridOffset + row * columnSpan, 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform) ;
                Vector3 position = rowPosition;
                position.x += col * rowSpan;
                invader.transform.position = position;
            }
        }
    }

    void Update() 
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
                continue;
            
            if (_direction == Vector3.right && invader.position.x >= rightEdge.x -1.0f)
                AdvanceRow();
            else if (_direction == Vector3.left && invader.position.x <= leftEdge.x +1.0f)
                AdvanceRow();
            
        }
    }

    private void AdvanceRow(){
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }
}
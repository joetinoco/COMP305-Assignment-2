using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    // private instance variables
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Vector2 _originalPosition, _velocity;

    // public instance variables
    public bool isVertical = true;
    public float Speed = 2f;
    public float MaximumSpeed = 4f;
    public float MaxDisplacement = 2.5f;

    // Use this for initialization
    void Start()
    {
        this._transform = GetComponent<Transform>();
        this._rigidbody = GetComponent<Rigidbody2D>();

        this._originalPosition = this._transform.position;

        if (this.isVertical)
        {
            this._velocity = Vector2.up * this.Speed;
        }
        else
        {
            this._velocity = Vector2.right * this.Speed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((this.isVertical &&
            (this._transform.position.y >= this._originalPosition.y + this.MaxDisplacement ||
            this._transform.position.y <= this._originalPosition.y - this.MaxDisplacement)) ||
            ((!this.isVertical) &&
            (this._transform.position.x >= this._originalPosition.x + this.MaxDisplacement ||
            this._transform.position.x <= this._originalPosition.x - this.MaxDisplacement)))
        {
            // change the direction of movement when the object moves past its max displacement
            this._velocity *= -1;
        }

        this._rigidbody.velocity = this._velocity;
    }
}

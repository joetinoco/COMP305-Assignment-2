using UnityEngine;
using System.Collections;

public class SpringboardController : MonoBehaviour {
	public int springStrength = 700;
	public AudioSource SpringSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		other.rigidbody.AddForce(
			new Vector2( other.relativeVelocity.x * -40f, springStrength ),
			ForceMode2D.Force);
		SpringSound.Play();
	}
}

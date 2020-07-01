using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initalPosition;
    private bool _birdWasLunched;
    private float _timeSitting;

    [SerializeField] private float _launchSpeed=200f;

    private void Awake()
    {
        _initalPosition = transform.position;
        _birdWasLunched = false;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        
    }

    private void OnMouseDrag()
    {
        
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
        
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initalPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition*_launchSpeed);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLunched = true;
    }

    private void Update()
    {
        if (_birdWasLunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSitting += Time.deltaTime;
        }
        if (transform.position.y > 10 || transform.position.x > 20 || _timeSitting >2 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        
    }



}

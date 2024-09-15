using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
  private Vector2 _direction = Vector2.right;

  private List<Transform> _segments = new List<Transform>();

  public Transform segmentPrefab;

  public int pocetnaVelicina = 3;

  private static Snake instance;

  public static int? score = null;

  private void Awake (){
    instance = this;
  }
  
  private void Start() 
  {
    ResetState();
  }

  private void Update()
  {
        if (Input.GetKeyDown(KeyCode.W)) {
            _direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            _direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            _direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            _direction = Vector2.right;
        }
  }

  private void FixedUpdate()
  {
    for (int i = _segments.Count - 1; i > 0; i--) {
        _segments[i].position = _segments[i-1].position;
    }
    
    this.transform.position = new Vector3(
        Mathf.Round(this.transform.position.x) + _direction.x,
        Mathf.Round(this.transform.position.y) + _direction.y,
        0.0f
        );
  }

  private void Grow()
  {
    Transform segment = Instantiate(this.segmentPrefab);
    segment.position = _segments[_segments.Count - 1].position;
    _segments.Add(segment);
    Snake.AddScore();
  }
  
  private void ResetState()
  {
        for (int i = 1; i < _segments.Count; i++){
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);
        Snake.ResetScore();

        for (int i = 1; i < this.pocetnaVelicina; i++){
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
  }


  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food"){
            Grow();
        } else if (other.tag == "Obstacle"){
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
   
  public static int? GetScore(){
    return score;
   }
  
  public static void AddScore(){
    score += 100;
  }

  public static void ResetScore() {
    score = 0;
  }
}

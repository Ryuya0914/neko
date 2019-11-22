using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleS : MonoBehaviour
{
    public string lesson_Tag = "lesson_Tag";
    public string game_Tag = "game_Tag";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, Mathf.Infinity);

            if (hit.collider)
            {
                if (hit.collider.gameObject.CompareTag(lesson_Tag))
                {
                   // SceneManager.LoadScene("YAMADA");
                }
                if (hit.collider.gameObject.CompareTag(game_Tag))
                {
                   // SceneManager.LoadScene("GAME");
                }

            }

        }
    }
}

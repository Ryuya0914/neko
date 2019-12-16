using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleS : MonoBehaviour
{
    public string rank_Tag = "rank_Tag";
    public string game_Tag = "game_Tag";
    float fadeSpeed = 0.02f;
    float red, green, blue, alfa;
    public bool isFadeOut = false;
    Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
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
                //if (hit.collider.gameObject.CompareTag(rank_Tag))
                //{
                //    SceneManager.LoadScene("YAMADA");
                //}
                if (hit.collider.gameObject.CompareTag(game_Tag))
                {
                   hit.collider.gameObject.GetComponent<Game_Start>().OnUserAction1();
                    isFadeOut = true;
                    Debug.Log("a");
                }

            }

        }
        if (isFadeOut == true)
        {
            FadeOut();
        }
    }
    void FadeOut()
    {
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1)
        {
            isFadeOut = false;
        }
    }
    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSprite : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float timeInSeconds;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(Fade(0.0f, timeInSeconds)); 
       Destroy(this.gameObject, 3); 
    }

    IEnumerator Fade(float value, float time) {
        float alpha = sprite.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
            Color color = new Color(1,1,1, Mathf.Lerp(alpha, value, t));
            sprite.color = color;
            yield return null;
        }
    }

}

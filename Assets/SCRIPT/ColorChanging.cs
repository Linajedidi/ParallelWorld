using System.Collections;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Define the colors
    public Color redColor = Color.red;
    public Color blueColor = Color.blue;
    public Color normalColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }


    IEnumerator ChangeColor()
    {
        while (true)
        {
            
            int randomIndex = Random.Range(0, 3);

            
            switch (randomIndex)
            {
                case 0:
                    spriteRenderer.color = redColor;
                    break;
                case 1:
                    spriteRenderer.color = blueColor;
                    break;
                case 2:
                    spriteRenderer.color = normalColor;
                    break;
            }

            
            yield return new WaitForSeconds(6f);
        }
    }
}

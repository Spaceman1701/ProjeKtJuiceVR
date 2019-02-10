using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    public TextBoard text;

    private GenerateRecipes r;

    private Scorer s;

    // Start is called before the first frame update
    void Start()
    {
        r = new GenerateRecipes();
        s = new Scorer();
        r.GenerateNewRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetRecipe(r.GetRecipe());
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("KAsdjhklsdajlksdjalsdkjk");
        GameObject other = collision.gameObject;

        Cup c = other.GetComponent<Cup>();
        if (c != null)
        {
            var l = c.GetLiquidStorage();

            text.score += s.Score(r.GetRecipe(), l);
        }

        Destroy(other);
    }
}

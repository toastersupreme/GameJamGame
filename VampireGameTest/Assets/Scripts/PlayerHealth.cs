using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI exposureLevel;
    public float exposureNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exposureLevel.text = exposureNum.ToString();

        if (exposureNum > 1000)
        {
            Destroy(this);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            exposureNum++;
        }
    }
}

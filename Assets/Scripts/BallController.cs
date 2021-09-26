using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{
    GameObject PanelKalah;
    GameObject PanelMenang;
    Text txPemenang;
    public Text countText;
    private int count;
    public int force;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, -2).normalized;
        rigid.AddForce(arah * force);
        count = 0;
        SetCountText();

        
        PanelMenang = GameObject.Find("PanelMenang");
        PanelKalah = GameObject.Find("PanelKalah");
        PanelMenang.SetActive(false);
        PanelKalah.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Tepi Bawah")
        {
            ResetBall();
            Vector2 arah = new Vector2(0, -2).normalized;
            rigid.AddForce(arah * force);
            PanelKalah.SetActive(true);
            Destroy(gameObject);
            return;
        }
        if (coll.gameObject.name == "Awan Kinton")
        {
            float sudut = (transform.position.x - coll.transform.position.x) * 5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 1);
        }

        
        if (coll.gameObject.CompareTag("Block"))
        {
            coll.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
            if (count == 100) 
            {
                PanelMenang.SetActive(true);
                Destroy(gameObject);
                return; 
            }
        }
            
    }
    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }
    
    void SetCountText()
    {
        countText.text = count.ToString();
    }
}


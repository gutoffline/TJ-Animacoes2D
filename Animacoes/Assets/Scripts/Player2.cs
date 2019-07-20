using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    public float velocidade;
    public float forcaPulo;
    private bool verificaChao;
    public Transform chaoVerificador;
    public Transform spritePlayer;
    private Animator animador;
    public bool estaNoChao=true;
    public float movimentacao=0f;
    void Start() {
        animador = spritePlayer.GetComponent<Animator>();
    }
    void Update(){ 
        Movimentacao();
        animador.SetBool("chao",Physics2D.Linecast(transform.position , chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao")));
        animador.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal2")));
    }
    void Movimentacao(){
        verificaChao = Physics2D.Linecast(transform.position , chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));
        if(Input.GetAxisRaw("Horizontal2") > 0){
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);
        }

        if(Input.GetAxisRaw("Horizontal2") < 0){
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);
        }

        if(Input.GetButtonDown("Jump2") && verificaChao){
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }
    }
}

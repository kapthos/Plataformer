using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    private float _yVelocity;
    [SerializeField] private bool _canDoubleJump;

    // References
    private CharacterController _controller;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");   //cria um numero de acordo com a pressão no A,D
        Vector3 direction = new Vector3(_horizontalInput,0,0);  //pega o numero criado e transforma no eixo X de um vetor
        Vector3 velocity = direction * _speed;                  //cria um novo vetor usando a direção e velocidade, chamando isso de velocity 
       
        if(_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if(_canDoubleJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);            //chama a função MOVE do controle e aplica o vetor anterior
    }
}

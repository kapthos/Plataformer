using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;

    private Player _pl;

    void Start()
    {
        _pl = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {

    }

    public void UpdateCoinAmount(int coinAmount)
    {
        _coinText.text = "Coin: " + coinAmount;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Calcu : MonoBehaviour
{
    [SerializeField] private TMP_InputField primerNumeroTxt;
    [SerializeField] private TMP_InputField segundoNumeroTxt;
    [SerializeField] private TMP_Text resultadoTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Suma()
    {
        float.TryParse(primerNumeroTxt.text, out float primerNumero);
        float.TryParse(segundoNumeroTxt.text, out float segundoNumero);
        float result = primerNumero + segundoNumero;
        resultadoTxt.text = "Es igual a = " + result;
    }
    public void Resta()
    {
        float.TryParse(primerNumeroTxt.text, out float primerNumero);
        float.TryParse(segundoNumeroTxt.text, out float segundoNumero);
        float result = primerNumero - segundoNumero;
        resultadoTxt.text = "Es igual a = " + result;
    }
    public void Multiplicacion()
    {
        float.TryParse(primerNumeroTxt.text, out float primerNumero);
        float.TryParse(segundoNumeroTxt.text, out float segundoNumero);
        float result = primerNumero * segundoNumero;
        resultadoTxt.text = "Es igual a = " + result;
    }
    public void Division()
    {
        float.TryParse(primerNumeroTxt.text, out float primerNumero);
        float.TryParse(segundoNumeroTxt.text, out float segundoNumero);
        float result = primerNumero / segundoNumero;
        resultadoTxt.text = "Es igual a = " + result;
    }
}

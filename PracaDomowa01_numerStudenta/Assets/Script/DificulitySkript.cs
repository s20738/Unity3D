using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DificulitySkript : MonoBehaviour
{
    
    public Toggle toggle;
    public InputField input;
    public Image toggleBack;
    public Image inputBack;
    public Text textName;
    public void PlayGame()
    {
        Regex rgx = new Regex(@"[a-zA-Z]");
        Match match = rgx.Match(textName.text);
        if(Regex.IsMatch(textName.text, @"[a-zA-Z]",RegexOptions.Compiled) && toggle.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(!toggle.isOn)
        {
            toggleBack.CrossFadeColor(Color.red,0,false,false);

        }
        else if (toggle.isOn)
        {
            toggleBack.CrossFadeColor(Color.white, 0, false, false);
        }
        else if(!Regex.IsMatch(textName.text, @"[a-zA-Z]", RegexOptions.Compiled))
        {
            inputBack.CrossFadeColor(Color.red, 0, false, false);
        }
        else if (Regex.IsMatch(textName.text, @"[a-zA-Z]", RegexOptions.Compiled))
        {
            inputBack.CrossFadeColor(Color.white, 0, false, false);
        }



    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void SetName()
    {
       
    }
}

using System;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Settings settings;
    private Statistic statistic;
    private int hp;
    private bool isplay = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var jstring = PlayerPrefs.GetString("stats");
        if (!jstring.Equals(string.Empty, StringComparison.Ordinal))
        {
            statistic = JsonUtility.FromJson<Statistic>(jstring);
            statistic.countSecond = 0;
            Debug.Log("cicl - " + statistic.cicl);
        }
        else
        {
            statistic = new Statistic();
        }

        hp = settings.Hp;
        Debug.Log("Hp " + hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (isplay)
        {
            statistic.countSecond += Time.deltaTime;

        }



        if (statistic.countSecond > hp)
        {
            Debug.Log(statistic.countSecond);
            statistic.cicl++;
            isplay = false;
            hp = hp * hp;
            Serializ();
        }
    }

    private void Serializ()
    {
        var jsonstring = JsonUtility.ToJson(statistic);
        Debug.Log(new string('-', 8));
        Debug.Log(jsonstring);
        PlayerPrefs.SetString("stats", jsonstring);

    }
}

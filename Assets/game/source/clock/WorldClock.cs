using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WorldClock : MonoBehaviour
{


    [SerializeField]
    private float _timeScale;

    [SerializeField]
    private Text _timeField;

    private float _hours = 0.0f;
    private float _prevHours = 0.0f;
    private float _days = 1;
    private float _month = 1;
    private float _years = 1975;

    public float Hour   { get { return _hours; }    set { _hours = value; } }
    public float Day    { get { return _days;  }    set { _days = value; } }    
    public float Month  { get { return _month; }    set { _month = value; } }
    public float Year   { get { return _years; }    set { _years = value;  } }


    public delegate void DateUpdate();
    

    public static event DateUpdate OnHourPassed     = null;
    public static event DateUpdate OnDayPassed      = null;
    public static event DateUpdate OnMonthPassed    = null;
    public static event DateUpdate OnYearPassed     = null;


    void Start()
    {
        _timeField.text = _days + " / " + _month + " / " + _years;
    }
    
    void Update ()
    {
        _prevHours = _hours;
        _hours += Time.deltaTime * _timeScale;

        if (Mathf.Abs(_prevHours - _hours) >= 1)
        {
            if(OnHourPassed != null)  OnHourPassed();
        }
        increaseTimer(ref _hours, ref _days, 24, OnDayPassed);
        increaseTimer(ref _days, ref _month, 30, OnMonthPassed);
        increaseTimer(ref _month, ref _years, 12, OnYearPassed);

    }
    /// <summary>
    /// Upticks the date values
    /// </summary>
    /// <param name="a">small value (_hours)</param>
    /// <param name="b">bigger value (_days)</param>
    /// <param name="controlValue">Value to check for incrementation</param>
    /// <param name="callback">function to call whenever we have an uptick on a field</param>
    private void increaseTimer(ref float a, ref float b, float controlValue, DateUpdate callback)
    {
        if (a > controlValue)
        {
            if (controlValue == 24)
                a = 0;
            else a = 1;

            b++;

            _timeField.text = _days + " / " + _month + " / " + _years;
            if(callback != null) callback();
        }
    }
}

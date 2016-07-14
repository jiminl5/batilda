using UnityEngine;
using System.Collections;

public class ingredientHandler : MonoBehaviour {

    private int _wheat;
    private int _carrot;
    private int _fish;
    private int _beef;
    private int _onion;
    private int _cheese;

    void Start()
    {
        Carrot = PlayerPrefs.GetInt("carrot");
        Wheat = PlayerPrefs.GetInt("wheat");
        Fish = PlayerPrefs.GetInt("fish");
        Beef = PlayerPrefs.GetInt("beef");
        Onion = PlayerPrefs.GetInt("onion");
        Cheese = PlayerPrefs.GetInt("cheese");
    }

    public int Carrot
    {
        get { return _carrot; }
        set { _carrot = value;
            storeCarrot();
        }
    }
    public int Wheat
    {
        get { return _wheat; }
        set { _wheat = value;
            storeWheat();
        }
    }
    public int Fish
    {
        get { return _fish; }
        set
        {
            _fish = value;
            storeFish();
        }
    }
    public int Beef
    {
        get { return _beef; }
        set
        {
            _beef = value;
            storeBeef();
        }
    }
    public int Onion
    {
        get { return _onion; }
        set
        {
            _onion = value;
            storeOnion();
        }
    }
    public int Cheese
    {
        get { return _cheese; }
        set
        {
            _cheese = value;
            storeCheese();
        }
    }

    private void storeCarrot()
    {
        PlayerPrefs.SetInt("carrot", _carrot);
    }
    private void storeWheat()
    {
        PlayerPrefs.SetInt("wheat", _wheat);
    }
    private void storeFish()
    {
        PlayerPrefs.SetInt("fish", _fish);
    }
    private void storeBeef()
    {
        PlayerPrefs.SetInt("beef", _beef);
    }
    private void storeOnion()
    {
        PlayerPrefs.SetInt("onion", _onion);
    }
    private void storeCheese()
    {
        PlayerPrefs.SetInt("cheese", _cheese);
    }
}

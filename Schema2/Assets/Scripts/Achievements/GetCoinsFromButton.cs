using UnityEngine;

public class GetCoinsFromButton : MonoBehaviour
{
    public int testCoin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoin()
    {
        testCoin++;
        Debug.Log(testCoin);
    }
}

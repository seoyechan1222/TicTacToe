using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Animal
{
    public string Name { get; set; }

    public void Eat()
    {
        Debug.Log(Name + " is eating.");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Debug.Log(Name + " is barking.");
    }
}





class A
{
    public A()
    {
        B b = new B(Run);
        b.Run();
    }

    public void Run()
    {
        Debug.Log("Run!!");
    }
}

class B
{
    public delegate void RunDelegate();
    public RunDelegate AfterRun;

    public B(RunDelegate afterRun)
    {
        AfterRun = afterRun;
    }
    
    public void Run()
    {
        Debug.Log("Run!!");
        AfterRun.Invoke();
    }
}







public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dog dog = new Dog();
        dog.Name = "Bark";
        dog.Eat();
        dog.Bark();

        Animal animal = new Dog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 재귀함수
    void RecursiveFunction(int count)
    {
        if (count <= 0)
        {
            Debug.Log("종료");
            return;
        }
        
        Debug.Log("Count: " + count);
        RecursiveFunction(count - 1);
    }
}

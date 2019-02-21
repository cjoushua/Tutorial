using NUnit.Framework;
using System;
using System.Reflection;

namespace TestProject
{
// An enumeration of animals. Start at 1 (0 = uninitialized).
    public enum Animal
    {
        // Pets.
        Dog = 1,
        Cat,
        Bird,
    }

    // a custom attribute 能允許目標物定義一個 pet (繼承 Attribute 類別)
    public class AnimalAttribute : Attribute
    {
        // 當這個 attribute 被設定時，這個建構子(constructor)會被呼叫
        public AnimalAttribute(Animal pet)
        {
            thePet = pet;
        }

        // 設定一個內部的變數
        protected Animal thePet;

        // 設定一個公開的屬性...
        public Animal Pet
        {
            get { return thePet; }
            set { thePet = Pet; }
        }
    }

    // 一個測試類別，在每個方法上都定義一個它屬於的 pet
    class AnimalTypeTestClass
    {
        [Animal(Animal.Dog)]
        public void DogMethod() { }

        [Animal(Animal.Cat)]
        public void CatMethod() { }

        [Animal(Animal.Bird)]
        public void BirdMethod() { }
    }

    //以下示範如何使用 attribute
    public class DemoClass
    {

        //[Test]
        //以下用 Console 模式下運作
        public void Handle()
        {
            AnimalTypeTestClass testClass = new AnimalTypeTestClass();
            Type type = testClass.GetType();

            // 將 AnimalTypeTestClass 的方法透過 foreach 全部取出
            foreach (MethodInfo mInfo in type.GetMethods())
            {
                // 將每一個 function 透過 foreach 取得 attribute 的集合
                foreach (Attribute attr in
                    Attribute.GetCustomAttributes(mInfo))
                {
                    // 檢查是否為 AnimalType 的資料型態如果是將它列印出來
                    if (attr.GetType() == typeof(AnimalAttribute))
                        Console.WriteLine(
                            "Method {0} has a pet {1} attribute.",
                            mInfo.Name, ((AnimalAttribute)attr).Pet);
                }

            }

            Console.In.ReadLine();
        }
    }
}

/*
 * output:
 * Method DogMethod has a pet Dog attribute.
 * Method CatMethod has a pet Cat attribute.
 * Method BirdMethod has a pet Bird attribute.
 */

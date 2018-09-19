using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutorial
{
    class ArrayTest
    {
        [Test]
        public void Arraytestc()
        {
            List<List<int>> listA = new List<List<int>>()
            {
                new List<int>()
                {
                    { 1 },{ 2}
                },
                new List<int>()
                {
                    { 3 },{ 4 },{ 5 },{ 6 },{ 7 }
                },
                new List<int>()
                {
                    { 8 },{ 9 },{ 0 }
                }
            };

            var resultA = listA.Aggregate((x, item) => x.Concat(item).ToList());
            resultA.ForEach(x => Console.Write(x));

            listA.SelectMany(x => x).ToList().ForEach(y => Console.WriteLine(y));

        }
    }
}

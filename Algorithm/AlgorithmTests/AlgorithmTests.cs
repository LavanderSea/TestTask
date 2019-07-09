using System;
using System.Collections.Generic;
using System.Linq;
using Algorithm;
using NUnit.Framework;

namespace AlgorithmTest
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            _random = new Random();
        }

        [Test]
        public void ListOfRandomNumbers_Sort_CorrectSortedByDescendingCollection()
        {
            var keys = new List<int>();
            for (var i = 0; i < 9; i++)
            {
                keys.Add(_random.Next(40));
            }

            var sortedList = keys.OrderByDescending(key => key).Where(key => key > Border).ToList();

            var result = keys.Quicksort(Border);

            CollectionAssert.AreEqual(sortedList, result);
        }

        [Test]
        public void ListWithRepeatingNumbers_Sort_CollectionWithoutChange()
        {
            var keys = new List<int> {15, 15, 15, 15, 15};

            var result = keys.Quicksort(Border);

            CollectionAssert.AreEqual(keys, result);
        }

        [Test]
        public void ListWithRepeatingNumbersLessThanBorder_Sort_EmptyCollection()
        {
            var keys = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                keys.Add(Border - 1);
            }

            var result = keys.Quicksort(Border);

            CollectionAssert.IsEmpty(result);
        }

        private Random _random;
        private const int Border = 14;
    }
}
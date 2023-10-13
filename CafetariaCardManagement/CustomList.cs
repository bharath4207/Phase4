
using System;
using System.Collections.Generic;
using System.Collections;
// using System.Collections.Generic;

namespace CafetariaCardManagement
{

    // class CustomList in place of generic list
    public class CustomList<T>
    {
        private int _count = 0;
        private int _capacity = 0;
        public int Count { get {return _count;} set{_count = value;} }
        public int Capacity { get; set; }

        public T this[int index] { get{return _array[index];} set{_array[index] = value;}}
        private T[] _array;


        // IEnumerator for using foreach loop

        public IEnumerator GetEnumerator() {
           for(int i = 0 ; i < _count ; i++) {
            yield return _array[i];
           }
        }

        // Custom List constructor 
       

        public CustomList() {
            _capacity = 4;
            _array = new T[_capacity];
        }


        // CustomList Parameterized Constructor
        public CustomList(int size) {
            _capacity = size;
            _array = new T[_capacity];
        }


        // Add method to add elements to the end of the array

        public void Add(T data) {
            if(_count == _capacity) {
                GrowSize();
            }
            _array[_count] = data;
            _count++;
        }

        // method to automatically increase the array size when it meets the condition
        public void GrowSize() {
            _capacity *= 2;
            T[] temp = new T[_capacity];
            for(int i = 0 ; i < _count ; i++) {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        // Method to add another custom list to the end of the array.

        public void AddRange(CustomList<T> dataList) {
            _capacity += dataList.Count + _count + 4;
            T[] temp = new T[_capacity];
            for(int i = 0 ; i < _count ; i++) {
                temp[i] = _array[i];
            }
            // System.Console.WriteLine($"between - {}");
            int k = 0;
            for(int i = _count ; i <= dataList._count + _count ; i++) {
                temp[i] = dataList[k];
                k++;
            }

            _array = temp;
            _count = _count +  dataList._count;
        }

    }
}

      
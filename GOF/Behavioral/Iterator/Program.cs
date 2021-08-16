    /*
    Iterator 
      Methoda: "object this []" allows you to treat object 
    of any class as an array. This method also specifies 
    what will be treated as an element of this array. 
    Another class: "Iterator" provides methods for accessing  
    elements of this array.
    */
    using System;
    using System.Collections;
    //
    class IteratedObject  
    {
        private ArrayList _items = new ArrayList();
        public int Count
        {
            get { return _items.Count; }
        }//
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }//
        public override string ToString()
        {
            return  " " + Count.ToString();
        }//
    }//
    class Iterator 
    {
        private IteratedObject _iteratedObject;
        private int _current = 0;

        public Iterator(IteratedObject objectIterowany)
        {
            _iteratedObject = objectIterowany;
        }
        public  object First()
        {
            return _iteratedObject[0];
        }
        public  object Next()
        {
            object ret = null;
            if (_current < _iteratedObject.Count - 1)
            {
                ret = _iteratedObject[++_current];
            }
            return ret;
        }
        public  object CurrentItem()
        {
            return _iteratedObject[_current];
        }
        public  bool IsDone()
        {
            return _current >= _iteratedObject.Count -1 ;
        }
        public void Reset()
        {
            _current = -1;
        }
    }//
    class Client
    {
        static void Main()
        {
            IteratedObject tab = new IteratedObject();
            tab[0] = "xxx";
            tab[1] = "yyy";
            tab[2] = "zzz";
            //
            IteratedObject table = new IteratedObject();
            table[0] = tab;
            table[1] = new IteratedObject();
            table[2] = "Item C";
            table[3] = tab[2];
            table[4] = 5.55;
            //
            Iterator i = new Iterator(table);
            object item = i.First();
            //
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            //
            i.Reset();
            while (!i.IsDone())
            {
                Console.WriteLine(i.Next());
            }
            //
            Console.ReadKey();
        }
    }
    /*output:
     3
     0
     Item C
     zzz
     5.55
     3
     0
     Item C
     zzz
     5.55
    */

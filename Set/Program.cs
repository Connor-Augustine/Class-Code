using System.ComponentModel;
using System.Formats.Tar;

namespace Set{
    public class Set<Element> where Element : IComparable{
        public List<Element> set;


        public Set(){
            set = new List<Element>();
        }

        public Set(List<Element> set){
            this.set = set;
        }


        //NOTE - Add functions here
        /*!SECTION
            | = Union Operator 
            This method returns a Set Object that contains a List of type <Element> which will be the Union List of the 2 Set Objects Provided.

        */
        public static Set<Element> operator |(Set<Element>set1,Set<Element>set2) {
            Set<Element> union = new Set<Element>(set1.set);
            union.set.AddRange(set2.set);
            union.set.Sort();
            union.set = union.set.Distinct().ToList();
            return union;
        }
        /*!SECTION
            &  Intersect Operator 
            This method returns a Set Object that contains a List of items that are present in both lists

        */
        public static Set<Element> operator &(Set<Element>set1,Set<Element>set2) {
            Set<Element> intersect = new Set<Element>();
            intersect.set = (List<Element>)set1.set.Intersect(set2.set).ToList();
            return intersect;
        }
        /*!SECTION
            - Difference Operator 
            This method returns a Set Object with a list that is the difference of 2 lists. 

        */
        public static Set<Element> operator -(Set<Element>set1,Set<Element>set2) {
            Set<Element> difference = new Set<Element>();
            difference.set = set1.set.Except(set2.set).ToList();
            return difference;
        }
        /*!SECTION
            + Add Operator 
            This method returns a Set Object with the added element to the List. Then sorts the list afterwards

        */
        public static Set<Element> operator +(Set<Element>set1,Element e) {
            if(set1.set.Contains(e)) {
                return set1;
            } else {
                set1.set.Add(e);
                set1.set.Sort();
                return set1;
            }
        }
        /*!SECTION
            == Operator
            This method returns true if the 2 Set objct's Lists are equal
        */
        public static bool operator ==(Set<Element>set1,Set<Element>set2) {
            if(set1.set.Count == set2.set.Count) {
                for(int i = 0; i < set1.set.Count; i++) {
                    if(!set1.set[i].Equals(set2.set[i])) {
                        return false;
                    }
                }
                return true;
            } else {
                return false;
            }
        }
        /*!SECTION
            != Operator 
            This method returns a boolean value, if the sets are equal it returns false, true if they are not equal

        */
        public static bool operator !=(Set<Element>set1,Set<Element>set2) {
            if(set1.set.Count == set2.set.Count) {
                for(int i = 0; i < set1.set.Count; i++) {
                    if(!set1.set[i].Equals(set2.set[i])) {
                        return true;
                    }
                }
                return false;
            } else {
                return true;
            }
        }
        /*!SECTION
            true - returns false if the list in the object is empty, true otherwise

        */
        public static bool operator true(Set<Element> set1) {
            return set1.set.Count > 0;
        }
        /*!SECTION
            false - returns true if the list in the object is empty, false otherwise

        */
        public static bool operator false(Set<Element> set1) {
            return set1.set.Count <= 0;
        }
        /*!SECTION
            Indexer for so the list so an array will work fine

        */
        public Element this[int index] {
            get {
                return set[index];
            }
            set {
                set.Insert(index, value);
            }
        }
        /*!SECTION
            Equals override - overriding the Equals method to compare the lists properly

        */
        public override bool Equals(object? obj)
        {
            if(obj == null) {
                return false;
            }
            if(set.SequenceEqual((List<Element>)obj)) {
                return true;
            } else {
                return false;
            }
        }
        /*!SECTION
            GetHashCode - No clue what it does but it was yelling at me to add it. :)

        */
        public override int GetHashCode()
        {
            return set.GetHashCode();
        }
    }
}


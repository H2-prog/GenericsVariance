# Generics Variance

## Beskrivelse
The project contains a simple class system for animals: 
An Animal base class, and two derived classes Bird and Cat. 
Furthermore, the project contains interfaces and classes for 
collections and collection processing.


## Steps
1. Examine the two 
interfaces ICollectionGet<T> and ICollectionSet<T>. Pay particular 
attention to how the type parameter T is used in each interface.
2. Examine the class Collection<T>. It is a very simple collection class, 
that implements the two interfaces mentioned above.
3. Examine the AnimalProcessor class, which contains four methods. 
Pay particular attention to the type of the parameter to each method, 
and to the operations performed inside the methods.
4. Now open Program.cs, and examine the code. Notice the 
commented-out code, which contains 8 method calls (Case A to H). 
Before un-commenting the code, see if you can work out which 
method calls are valid, and which are not (Hint: Pay close attention to 
the specific type of the parameter in each call).
5. Un-comment the code. How many cases did you get right?
6. Now open the ICollectionGet<T> interface. Declare the type 
parameter T to be co-variant, by adding the keyword out just before 
the T, like this: ICollectionGet<out T>.
7. Go back to Program.cs. Which case(s) that were previously invalid 
are now valid? See if you understand why…
8. Now open the ICollectionSet<T> interface. Declare the type 
parameter T to be contra-variant, by adding the keyword in just 
before the T, like this: ICollectionSet<in T>.
9. Go back to Program.cs. Which case(s) that were previously invalid 
are now valid? See if you understand why…

## Bonus steps
10. Two cases remain invalid. Do you think we in any way could fix this 
by further adjustments of the interfaces?
11. Since the Collection class implements 
both ICollectionGet<T> and ICollectionSet<T>, wouldn’t it be easier 
just to have a single interface ICollection<T>, containing all methods 
from the two interfaces? What would the consequences be?
using System;

// for the times when you want to feel like a functional programmer
public static class CurryExtensions  { 
  
	// Accepts 2, curry 1
	public static Func<B,O> Curry<A,B,O>(this Func<A,B,O> func, A a)
		=> (b) => func(a, b);

	// Accepts 3, curry 1
	public static Func<B,C,O> Curry<A,B,C,O>(this Func<A,B,C,O> func, A a)
		=> (b, c) => func(a, b, c);

	// Accepts 3, curry 2
	public static Func<C,O> Curry<A,B,C,O>(this Func<A,B,C,O> func, A a, B b)
		=> (c) => func(a, b, c);

	// Accepts 4, curry 1
	public static Func<B,C,D,O> Curry<A,B,C,D,O>(this Func<A,B,C,D,O> func, A a)
		=> (b, c, d) => func(a, b, c, d);

	// Accepts 4, curry 2
	public static Func<C,D,O> Curry<A,B,C,D,O>(this Func<A,B,C,D,O> func, A a, B b)
		=> (c, d) => func(a, b, c, d);

	// Accepts 4, curry 3
	public static Func<D,O> Curry<A,B,C,D,O>(this Func<A,B,C,D,O> func, A a, B b, C c)
		=> (d) => func(a, b, c, d);
    
}

# Observable
A lightweight generic Observer Pattern solution. 

## What
This is a simple implementation of [Observer Pattern](https://en.wikipedia.org/wiki/Observer_pattern) in the form of a generic wrapper class. Observer Pattern essentially means that instead of continually polling another object for changes you are setting a callback that is invoked whenever the observed object changes.

## Why
To be honest I found the Microsoft IObserver and IObservable approach a bit too complicated. I've tried various ways of doing Observer Pattern and this is the one that involves the least amount of code smell.

## How
First, wrap the value you want observed, so instead of

```
public class Thing
{
  public string message;
}
```
you would have

```
public class Thing
{
  public Observable<string> message = new Observable<string>();
}
```

and then you can have other objects bind to receive calls when the value changes:
```
public OtherClass()
{
  // Bind to the observable
  thing.message.Bind(UpdateOutput);
}

private void UpdateOutput(string newMessageValue)
{
   // called whenever message changes value
}
```

## Limitations
There's no fancy threading or error handling; this is basically just a wrapper around System.Action<T> with no checking that observers still exist.

# Observable
A lightweight generic Observer Pattern solution. 

## What
This is a simple implementation of [Observer Pattern](https://en.wikipedia.org/wiki/Observer_pattern) in the form of a generic wrapper class. Observer Pattern essentially means that instead of continually polling another object for changes you are setting a callback that is invoked whenever the observed object changes.

## Why
To be honest I found the Microsoft IObserver and IObservable approach a bit too complicated. I've tried various ways of doing Observer Pattern and this is the one that involves the least amount of code smell.

## How
First, wrap the value you want observed, so instead of

## Example
Suppose we have a typical situation where client class needs to update when a global static value changes. The normal way would be to regularly update the client, which polls the value and compares it to the previous value.

Like this:
```
public class ApplicationState
{
  public static string message;
  
  private void SomeFunction()
  {
    message = "Something";
  }
}

public class Client
{
  private string oldMessage;
  
  public void Update()
  {
    // poll ApplicationState.message and see if it has changed
    if(oldMessage != ApplicationState.message)
    {
      OnMessageChanged(ApplicationState.message);
      oldMessage = ApplicationState.message;
    }
  }
  
  private void OnMessageChange(string newMessageValue)
  {
    // do the necessary
  }
}
```
With Observable, we would wrap the global static value and then bind a callback to it, like this:
```
public class ApplicationState
{
  public static Observable<string> message = new Observable<string>();
  
  private void SomeFunction()
  {
    message.value = "Something";
  }
}

public class Client
{
  public Client() // constructor
  {
    ApplicationState.message.Bind(OnMessageChange);
  }

  private void OnMessageChange(string newMessageValue)
  {
    // do the necessary
  }
}
```
The Observable version is easier to read, and doesn't require continually updating the client object. Yay!

## Limitations
There's no fancy threading or error handling; this is basically just a wrapper around System.Action<T> with no checking that observers still exist.

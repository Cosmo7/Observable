using System;



public class Observable<T>
{
	private T _value;
	private Action<T> callbacks;

	public Observable()
	{

	}

	public Observable(T initialValue)
	{
		_value = initialValue;
	}

	public void Set(T value)
	{
		if (!object.Equals(_value, value))
		{
			_value = value;
			callbacks.Invoke(value);
		}
	}

	public T Get()
	{
		return _value;
	}

	public T value
	{
		get
		{
			return _value;
		}

		set
		{
			Set(value);
		}
	}

	public void Bind(Action<T> call)
	{
		callbacks += call;
	}

	public void Unbind(Action<T> call)
	{
		callbacks -= call;
	}
}


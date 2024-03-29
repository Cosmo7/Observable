// The MIT License (MIT)
// Copyright © 2022 Cosmo7/Eddie Bowen

// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy,
// modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the
// Software.

// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

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

	public bool Set(T value)
	{
		// returns true if value changed
		var change = !object.Equals(_value, value);

		if (change)
		{
			ForceSet(value);
		}

		return change;
	}

	public void ForceSet(T value)
	{
		_value = value;

		if (callbacks != null)
		{
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


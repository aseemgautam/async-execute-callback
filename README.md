# async-execute-callback
C# 2.0 library to execute functions asynchronously with callback mechanism. Exceptions, Result & State, if any, 
are available in the callback.

The library supports upto three parameters, but can be extended to support any number.

## Syntax

`Async.Execute(functionName, param1, param2 .. , state, Callback)`

`Callback(returnValue, state, exception)`

##### Example 

To execute a method `void Sum(int a, int b, int c) { return a + b + c; }` -

`Async.Execute(Sum, 5, 6, 7, int[] {12, 14}, SumCallback)`

```
void SumCallback(returnValue, state, exception) {
      //returnValue should be 17
      //state should be int[] {12, 14}
      //exception if there is any
}
```


using System;

namespace AsyncDemo
{
    public class Async
    {
        //Action = for void methods.        
        public delegate void Action();
        public delegate void Action<T>(T t);
        public delegate void Action<T, U>(T t, U u);
        public delegate void Action<T, U, V>(T t, U u, V v);

        //Func = for methods with some return type.
        public delegate TResult Func<TResult>();
        public delegate TResult Func<T, TResult>(T t);
        public delegate TResult Func<T, U, TResult>(T t, U u);
        public delegate TResult Func<T, U, V, TResult>(T t, U u, V v);
        public delegate TResult Func<T, U, V, W, TResult>(T t, U u, V v, W w);

        private delegate T EndInvokeDelegate<T>(IAsyncResult ar);
        private delegate void EndInvokeDelegate(IAsyncResult ar);

        /// <summary>
        /// Executes a method that takes no parameter. Return type void.
        /// </summary>        
        /// <param name="action">Method to be executed asynchronously</param>
        /// <param name="state">Any other info to be passed to callback</param>
        /// <param name="callback">Method that will be executed when the async operation is complete</param>
        public static void Execute(Action action, object state, Action<object, Exception> callback)
        {
            action.BeginInvoke(Callback,
                               new object[] { callback, new EndInvokeDelegate(action.EndInvoke), state });
        }

        /// <summary>
        /// Executes a method that takes one parameter of Type T1. Return type void.
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <param name="action">Method to be executed asynchronously</param>
        /// <param name="param">Parameter</param>
        /// <param name="state">Any other info to be passed to callback</param>
        /// <param name="callback">Method that will be executed when the async operation is complete</param>
        public static void Execute<T>(Action<T> action, T param, object state, Action<object, Exception> callback)
        {
            action.BeginInvoke(param, Callback,
                               new object[] { callback, new EndInvokeDelegate(action.EndInvoke), state });
        }

        /// <summary>
        ///Executes a method that takes two parameters of Type T and U. Return type void.
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <typeparam name="U">Parameter type</typeparam>
        ///<param name="action">Method to be executed asynchronously</param>
        ///<param name="tParam">Second Parameter</param>
        ///<param name="uParam">First Parameter</param>
        ///<param name="state">Any other info to be passed to callback</param>
        ///<param name="callback">Method that will be executed when the async operation is complete</param>
        public static void Execute<T, U>(Action<T, U> action, T tParam, U uParam, object state, Action<object, Exception> callback)
        {
            action.BeginInvoke(tParam, uParam, Callback,
                               new object[] { callback, new EndInvokeDelegate(action.EndInvoke), state });
        }

        /// <summary>
        ///Executes a method that takes two parameters of Type T and U. Return type void.
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <typeparam name="U">Parameter type</typeparam>
        ///<param name="action">Method to be executed asynchronously</param>
        ///<param name="tParam">Second Parameter</param>
        ///<param name="uParam">First Parameter</param>
        ///<param name="vParam">Third Parameter</param>
        ///<param name="state">Any other info to be passed to callback</param>
        ///<param name="callback">Method that will be executed when the async operation is complete</param>
        public static void Execute<T, U, V>(Action<T, U, V> action, T tParam, U uParam, V vParam, object state, Action<object, Exception> callback)
        {
            action.BeginInvoke(tParam, uParam, vParam, Callback,
                               new object[] { callback, new EndInvokeDelegate(action.EndInvoke), state });
        }

        /// <summary>
        /// Executes a method that takes no parameters. Return type TResult
        /// </summary>
        ///<param name="func">Method to be executed asynchronously</param>
        ///<param name="state">Any other info to be passed to callback</param>
        ///<param name="callback">Method that will be executed when the async operation is complete</param>
        public static void Execute<TResult>(Func<TResult> func, object state, Action<TResult, object, Exception> callback)
        {
            func.BeginInvoke(Callback<TResult>, new object[] { callback, new EndInvokeDelegate<TResult>(func.EndInvoke), state });
        }

        /// <summary>
        ///Executes a method that takes three parameters of Type T, U and V. Return type TResult.
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <typeparam name="U">Parameter type</typeparam>
        /// <typeparam name="V">Parameter type</typeparam>
        /// <typeparam name="TResult">Return type</typeparam>
        ///<param name="func">Method to be executed asynchronously</param>
        ///<param name="tParam">Second Parameter</param>
        ///<param name="uParam">First Parameter</param>
        ///<param name="vParam">Third Parameter </param>
        ///<param name="state">Any other info to be passed to callback</param>
        ///<param name="callback">method that will be executed when the async operation is complete</param>
        public static void Execute<T, U, V, TResult>(Func<T, U, V, TResult> func, T tParam, U uParam, V vParam, object state, Action<TResult, object, Exception> callback)
        {
            func.BeginInvoke(tParam, uParam, vParam, Callback<TResult>,
                               new object[] { callback, new EndInvokeDelegate<TResult>(func.EndInvoke), state });
        }

        /// <summary>
        ///Executes a method that takes three parameters of Type T, U and V. Return type TResult.
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <typeparam name="U">Parameter type</typeparam>
        /// <typeparam name="V">Parameter type</typeparam>
        /// <typeparam name="TResult">Return type</typeparam>
        ///<param name="func">Method to be executed asynchronously</param>
        ///<param name="tParam">First Parameter</param>
        ///<param name="uParam">Second Parameter</param>
        ///<param name="vParam">Third Parameter</param>
        ///<param name="wParam">Fourth parameter</param>
        ///<param name="state">Any other info to be passed to callback</param>
        ///<param name="callback">method that will be executed when the async operation is complete</param>
        public static void Execute<T, U, V, W, TResult>(Func<T, U, V, W, TResult> func, T tParam, U uParam, V vParam, W wParam, object state, Action<TResult, object, Exception> callback)
        {
            func.BeginInvoke(tParam, uParam, vParam, wParam, Callback<TResult>,
                               new object[] { callback, new EndInvokeDelegate<TResult>(func.EndInvoke), state });
        }

        /// <summary>
        ///Executes a method that takes two parameters of Type T and U. Return type TResult.
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <typeparam name="U">Parameter type</typeparam>
        /// <typeparam name="TResult">Return type</typeparam>
        ///<param name="func">Method to be executed asynchronously</param>
        ///<param name="tParam">Second Parameter</param>
        ///<param name="uParam">First Parameter</param>
        ///<param name="state">Any other info to be passed to callback</param>
        ///<param name="callback">method that will be executed when the async operation is complete</param>
        public static void Execute<T, U, TResult>(Func<T, U, TResult> func, T tParam, U uParam, object state, Action<TResult, object, Exception> callback)
        {
            func.BeginInvoke(tParam, uParam, Callback<TResult>,
                               new object[] { callback, new EndInvokeDelegate<TResult>(func.EndInvoke), state });
        }

        /// <summary>
        ///Executes a method that takes one parameter of Type T. Return type TResult.
        /// </summary>
        /// <typeparam name="T">Parameter type</typeparam>
        /// <typeparam name="TResult">Return Type</typeparam>
        ///<param name="action">Method to be executed asynchronously</param>
        ///<param name="param">First Parameter</param>
        ///<param name="state">Any other info to be passed to callback</param>
        ///<param name="callback">method that will be executed when the async operation is complete</param>
        public static void Execute<T, TResult>(Func<T, TResult> action, T param, object state, Action<TResult, object, Exception> callback)
        {
            action.BeginInvoke(param, Callback<TResult>,
                               new object[] { callback, new EndInvokeDelegate<TResult>(action.EndInvoke), state });
        }

        //Inisde the callback for any BeginInvoke, AsyncResult.AsyncDelegate needs to be cast to proper return type, only then EndInvoke is accessible.
        //So we need to define N callbacks for N generalized methods. But there is a trick - 
        //There is a @object parameter in Delegate.BeginInvoke, the state object. 
        //Which can be used to pass any info which can be retrieved back in the callback.
        //We pass the corresponding EndInvoke method as state in the BeginInvoke call - new objec[] { other parameters, Our EndInvoke delegate object }

        /// <summary>
        /// Callback to be used for methods with void return types.
        /// </summary>
        /// <param name="ar"></param>
        private static void Callback(IAsyncResult ar)
        {
            object[] stateArr = (object[])ar.AsyncState;
            Action<object, Exception> callback = (Action<object, Exception>)stateArr[0];
            EndInvokeDelegate action = (EndInvokeDelegate)stateArr[1];
            object state = stateArr[2];
            //Call EndInvoke. If there was an exception, it will be caught here.
            //If there is an exception, it gets tracked inside the EndInvoke. If we do not call EndInvoke, there is a memory leak
            //and we cannot find whether the method executed without any error. 
            //Always call EndInvoke!!
            try
            {
                action(ar);
            }
            catch (Exception ex)
            {
                //pass the exception to the callback
                callback(state, ex);
                return;
            }

            callback(state, null);
        }

        /// <summary>
        /// Callback to be used for methods with some return type."/>
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="ar"></param>
        private static void Callback<TR>(IAsyncResult ar)
        {
            object[] stateArr = (object[])ar.AsyncState;
            Action<TR, object, Exception> callback = (Action<TR, object, Exception>)stateArr[0];
            EndInvokeDelegate<TR> action = (EndInvokeDelegate<TR>)stateArr[1];
            object state = stateArr[2];

            TR returnValue = default(TR);

            //Call EndInvoke. If there was an exception, it will be caught here.
            //If there is an exception, it gets tracked inside the EndInvoke. If we do not call EndInvoke, there is a memory leak
            //and we cannot find whether the method executed without any error. Plus EndInvoke returns the result.
            //Always call EndInvoke!!
            try
            {
                returnValue = action(ar);
            }
            catch (Exception ex)
            {
                //pass the exception to the callback
                callback(returnValue, state, ex);
                return;
            }
            callback(returnValue, state, null);
        }        
    }
}

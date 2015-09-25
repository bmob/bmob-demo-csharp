using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Linq;
using cn.bmob.io;
using cn.bmob.http;
using cn.bmob.config;
using cn.bmob.exception;
using cn.bmob.response;
using cn.bmob.api;

using UnityEngine;
using System.Collections.ObjectModel;
using cn.bmob.tools;

namespace System
{
	//public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
	
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
	
	public class AggregateException : Exception
	{
		//
		// Properties
		//
		public ReadOnlyCollection<Exception> InnerExceptions
		{
			get;
			private set;
		}
		
		//
		// Constructors
		//
		public AggregateException(IEnumerable<Exception> innerExceptions)
		{
			this.InnerExceptions = new ReadOnlyCollection<Exception>(innerExceptions.ToList<Exception>());
		}
		
		//
		// Methods
		//
		public AggregateException Flatten()
		{
			List<Exception> list = new List<Exception>();
			foreach (Exception current in this.InnerExceptions)
			{
				AggregateException ex = current as AggregateException;
				if (ex != null)
				{
					list.AddRange(ex.Flatten().InnerExceptions);
				}
				else
				{
					list.Add(current);
				}
			}
			return new AggregateException(list);
		}
		
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			foreach (Exception current in this.InnerExceptions)
			{
				stringBuilder.AppendLine("\n-----------------");
				stringBuilder.AppendLine(current.ToString());
			}
			return stringBuilder.ToString();
		}
	}
}

namespace cn.bmob
{
	
	/// <summary>
	/// Bmob SDK入口类，开发者直接调用该类即可获取Bmob提供的各种服务。
	/// </summary>
	public class BmobUnity : cn.bmob.api.BmobUnity
	{

		/// <summary>
		/// Unity Behavior 
		/// </summary>
		public void Update() { }

		
		protected override IEnumerator Request(String url, String method, String contentType, byte[] postData, IDictionary<String, String> headers, Action<String, Status, BmobException> callback)
		{
			headers.Add("Content-Type", contentType);
			headers.Add("X-HTTP-Method-Override", method);
			
			return RequestInternal(url, method, postData, headers, callback);
		}
		
		private IEnumerator RequestInternal(String url, String method, byte[] postData, IDictionary<String, String> headers, Action<String, Status, BmobException> callback)
		{
			// FIXME v4.3.4f1坑，wp8 Engine没有Hashtable
			// WWW www = new WWW(url, postData, headers);
			var type = typeof(WWW);
			
			var dcons = type.GetConstructor(new Type[] { typeof(string), typeof(byte[]), typeof(Dictionary<String, String>) });
			var hcons = type.GetConstructor(new Type[] { typeof(string), typeof(byte[]), typeof(Hashtable) });
			
			WWW www = null;
			if (dcons != null)
			{
				var table = new Dictionary<String, String>();
				foreach (var header in headers)
				{
					table.Add(header.Key, header.Value);
				}
				www = dcons.Invoke(new object[] { url, postData, table }) as WWW;
			}
			else if (hcons != null)
			{
				var table = new Hashtable();
				foreach (var header in headers)
				{
					table.Add(header.Key, header.Value);
				}
				www = hcons.Invoke(new object[] { url, postData, table }) as WWW;
			}
			else
			{
				BmobDebug.D("代码没有处理这种情况!!!");
				throw new BmobException("unreached code. ");
			}
			
			yield return www;
			
			var error = www.error;
			var text = www.text;
			
			BmobDebug.T("after fetch www message, response: '" + text + "', error: ' " + error + "'");
			
			// TODO status www.responseHeaders["Status"]
			var status = new Status(200, "");
			if (error != null && error != "")
			{
				callback("", status, new BmobException(error));
			}
			else
			{
				callback(text, status, null);
			}
		}
		
	}
	
}
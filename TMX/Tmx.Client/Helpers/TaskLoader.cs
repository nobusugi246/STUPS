﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/23/2014
 * Time: 5:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
	using System;
	using System.Net;
	using RestSharp;
	using Tmx;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	
	/// <summary>
	/// Description of TaskLoader.
	/// </summary>
	public class TaskLoader
	{
	    readonly RestRequestCreator _restRequestCreator = new RestRequestCreator();
	    
		public ITestTask GetCurrentTask()
		{
			var request = _restRequestCreator.GetRestRequest(UrnList.TestTasks_Root + "/" + ClientSettings.ClientId, Method.GET);
			var gettingTaskResponse = _restRequestCreator.RestClient.Execute<TestTask>(request);
			// 20140731
			// if (HttpStatusCode.OK != gettingTaskResponse.StatusCode)
			// 	throw new LoadTaskException("Failed to load task");
			// return acceptCurrentTask(gettingTaskResponse.Data);
			if (HttpStatusCode.OK == gettingTaskResponse.StatusCode) return acceptCurrentTask(gettingTaskResponse.Data);
			if (HttpStatusCode.NotFound == gettingTaskResponse.StatusCode) return null; // a waiting task?
			throw new LoadTaskException("Failed to load task");
		}

		ITestTask acceptCurrentTask(ITestTask task)
		{
			task.Status = TestTaskStatuses.Accepted;
			task.StartTimer();
			var request = new RestRequest(UrnList.TestTasks_Root + "/" + task.Id, Method.PUT);
			request.AddObject(task);
			var acceptingTaskResponse = _restRequestCreator.RestClient.Execute(request);
			if (HttpStatusCode.OK == acceptingTaskResponse.StatusCode)
				return task;
			throw new AcceptTaskException("Failed to accept task " + task.Name);
		}
	}
}

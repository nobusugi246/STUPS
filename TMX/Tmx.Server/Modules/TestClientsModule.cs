﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
	using System;
	using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces;
	
	/// <summary>
	/// Description of TestClientsModule.
	/// </summary>
	public class TestClientsModule : NancyModule
	{
		public TestClientsModule() : base(UrnList.TestClients_Root)
		{
			Post[UrnList.TestClients_Clients] = parameters => {
                var testClient = this.Bind<TestClientInformation>();
                
                int maxId = 0;
                if (0 < ClientsCollection.Clients.Count)
                	maxId = ClientsCollection.Clients.Max(client => client.Id);
                
                var clientInformation = new TestClientInformation {
            		Id = ++maxId,
					Hostname = testClient.Hostname,
					Fqdn = testClient.Fqdn,
					IpAddresses = testClient.IpAddresses,
					MacAddresses = testClient.MacAddresses,
					UserDomainName = testClient.UserDomainName,
					Username = testClient.Username,
					IsInteractive = testClient.IsInteractive,
					IsAdmin = testClient.IsAdmin,
					OsVersion = testClient.OsVersion,
					EnvironmentVersion = testClient.EnvironmentVersion,
					UptimeSeconds = testClient.UptimeSeconds,
					CustomString = testClient.CustomString
                };
                
				ClientsCollection.Clients.Add(clientInformation);
				
//				testClient.Id = ++maxId;
//				ClientsCollection.Clients.Add(testClient);
				
				// TODO: DI
				var taskSorter = new TaskSorter();
				TaskPool.Tasks.AddRange(taskSorter.SelectTasksForClient(clientInformation.Id));
				// TaskPool.Tasks.AddRange(taskSorter.GetTasksForClient(testClient.Id));
				
                return Response.AsJson(clientInformation).WithStatusCode(HttpStatusCode.Created);
//				return Response.AsJson(testClient).WithStatusCode(HttpStatusCode.Created);
			};
			
			Delete[UrnList.TestClients_Client] = parameters => {
				try {
					var clientsToDelete = ClientsCollection.Clients.RemoveAll(client => client.Id == parameters.id);
					// TODO: clean up the list of tasks for the client if ever existed
					return HttpStatusCode.OK;
				}
				catch {
					return HttpStatusCode.InternalServerError;
				}
			};
		}
	}
}

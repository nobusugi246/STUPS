﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/13/2014
 * Time: 2:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using Nancy;
    using Nancy.ModelBinding;
	using TMX;
	using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsModule.
    /// </summary>
    public class TestResultsModule : NancyModule
    {
        public TestResultsModule() : base("/Results")
        {
            Post["/suites/"] = parameters => {
                //
                // var testSuite = this.Bind<TestSuite>();
                // return Response.AsJson<ITestSuite>(testSuite, HttpStatusCode.OK);
                //
                return HttpStatusCode.OK;
            };
        }
    }
}
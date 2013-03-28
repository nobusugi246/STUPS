﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestResults
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SearchTMXTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Search-TMXTestSuite test")]
    public class SearchTMXTestSuiteCommandTestFixture
    {
        public SearchTMXTestSuiteCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Search_TMXTestSuite")]
        public void TestPrm_Name_Simple_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite1"));
            coll.Add(new System.Management.Automation.PSObject("suite2"));
            coll.Add(new System.Management.Automation.PSObject("suite3"));
            coll.Add(new System.Management.Automation.PSObject("suite4"));
            coll.Add(new System.Management.Automation.PSObject("suite5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"Search-TMXTestSuite -OrderById | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_Name_Complex_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite%%`1  1"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`2  2"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`3  3"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`4  4"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`5  5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`5  5'; " + 
                @"Search-TMXTestSuite -OrderById | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_Id_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"Search-TMXTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_Id_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject(@"a\ 1"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 2"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 3"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 4"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 'a\ 3'; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 'a\ 5'; " + 
                @"Search-TMXTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderById_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " +
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"Search-TMXTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderById_Descending_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " +
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"Search-TMXTestSuite -OrderById -Descending | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderById_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("i1"));
            coll.Add(new System.Management.Automation.PSObject("i2"));
            coll.Add(new System.Management.Automation.PSObject("i3"));
            coll.Add(new System.Management.Automation.PSObject("i4"));
            coll.Add(new System.Management.Automation.PSObject("i5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc4 -Id i4; " + 
                @"$null = New-TMXTestSuite -Name abc1 -Id i1; " +
                @"$null = New-TMXTestSuite -Name abc3 -Id i3; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id i5; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id i2; " + 
                @"Search-TMXTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByName_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 4; " + 
                @"$null = New-TMXTestSuite -Name 1; " +
                @"$null = New-TMXTestSuite -Name 3; " + 
                @"$null = New-TMXTestSuite -Name 5; " + 
                @"$null = New-TMXTestSuite -Name 2; " + 
                @"Search-TMXTestSuite -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByName_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("abc1"));
            coll.Add(new System.Management.Automation.PSObject("abc2"));
            coll.Add(new System.Management.Automation.PSObject("abc3"));
            coll.Add(new System.Management.Automation.PSObject("abc4"));
            coll.Add(new System.Management.Automation.PSObject("abc5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc4; " + 
                @"$null = New-TMXTestSuite -Name abc1; " +
                @"$null = New-TMXTestSuite -Name abc3; " + 
                @"$null = New-TMXTestSuite -Name abc5; " + 
                @"$null = New-TMXTestSuite -Name abc2; " + 
                @"Search-TMXTestSuite -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByName_Descending_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("abc5"));
            coll.Add(new System.Management.Automation.PSObject("abc4"));
            coll.Add(new System.Management.Automation.PSObject("abc3"));
            coll.Add(new System.Management.Automation.PSObject("abc2"));
            coll.Add(new System.Management.Automation.PSObject("abc1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc4; " + 
                @"$null = New-TMXTestSuite -Name abc1; " +
                @"$null = New-TMXTestSuite -Name abc3; " + 
                @"$null = New-TMXTestSuite -Name abc5; " + 
                @"$null = New-TMXTestSuite -Name abc2; " + 
                @"Search-TMXTestSuite -OrderByName -Descending | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByTimeSpent()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 4; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t2; " +
                @"$null = New-TMXTestSuite -Name 1; " +
                @"sleep -Milliseconds 10; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"$null = New-TMXTestSuite -Name 3; " + 
                @"sleep -Milliseconds 2000; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"$null = New-TMXTestSuite -Name 5; " + 
                @"sleep -Milliseconds 1500; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"$null = New-TMXTestSuite -Name 2; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"Search-TMXTestSuite -OrderByTimeSpent | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByTimeSpent_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 4; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t2; " +
                @"$null = New-TMXTestSuite -Name 1; " +
                @"sleep -Milliseconds 10; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"$null = New-TMXTestSuite -Name 3; " + 
                @"sleep -Milliseconds 2000; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"$null = New-TMXTestSuite -Name 5; " + 
                @"sleep -Milliseconds 1500; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"$null = New-TMXTestSuite -Name 2; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"Search-TMXTestSuite -OrderByTimeSpent -Descending | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderByPassRate parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByPassRate()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 4; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t01; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t03; " +
                @"$null = New-TMXTestSuite -Name 1; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t04; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t06; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TMXTestSuite -Name 3; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t08; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t09; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t10; " +
                @"$null = New-TMXTestSuite -Name 5; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TMXTestSuite -Name 2; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t12; " +
                @"Search-TMXTestSuite -OrderByPassRate | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByPassRate and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByPassRate_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 4; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t01; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t03; " +
                @"$null = New-TMXTestSuite -Name 1; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t04; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t06; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TMXTestSuite -Name 3; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t08; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t09; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t10; " +
                @"$null = New-TMXTestSuite -Name 5; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TMXTestSuite -Name 2; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t12; " +
                @"Search-TMXTestSuite -OrderByPassRate -Descending | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderByFailRate parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByFailRate()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 4; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t01; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t03; " +
                @"$null = New-TMXTestSuite -Name 1; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t04; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t06; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TMXTestSuite -Name 3; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t08; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t09; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t10; " +
                @"$null = New-TMXTestSuite -Name 5; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TMXTestSuite -Name 2; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t12; " +
                @"Search-TMXTestSuite -OrderByFailRate | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByFailRate and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_OrderByFailRate_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 4; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t01; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t03; " +
                @"$null = New-TMXTestSuite -Name 1; " +
                @"$null = Add-TMXTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t04; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t06; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TMXTestSuite -Name 3; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t08; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t09; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t10; " +
                @"$null = New-TMXTestSuite -Name 5; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TMXTestSuite -Name 2; " + 
                @"$null = Add-TMXTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TMXTestResult -TestPassed -Name t12; " +
                @"Search-TMXTestSuite -OrderByFailRate -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterNameContains parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_FilterNameContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite02"));
            coll.Add(new System.Management.Automation.PSObject("suite04"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = New-TMXTestSuite -Name suite02; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = New-TMXTestSuite -Name suite04; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"Search-TMXTestSuite -FilterNameContains '0' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterNameContains and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_FilterNameContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite04"));
            coll.Add(new System.Management.Automation.PSObject("suite02"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = New-TMXTestSuite -Name suite02; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = New-TMXTestSuite -Name suite04; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"Search-TMXTestSuite -FilterNameContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -FilterIdContains parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_FilterIdContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("122"));
            coll.Add(new System.Management.Automation.PSObject("125"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 111; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 122; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 133; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 114; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 125; " + 
                @"Search-TMXTestSuite -FilterIdContains '12' | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterIdContains and - parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_FilterIdContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("125"));
            coll.Add(new System.Management.Automation.PSObject("122"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 111; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 122; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 133; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 114; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 125; " + 
                @"Search-TMXTestSuite -FilterIdContains '12' -Descending | %{$_.Id;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_FilterDescriptionContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite1"));
            coll.Add(new System.Management.Automation.PSObject("suite4"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1 -Description 'abc'; " + 
                @"$null = New-TMXTestSuite -Name suite2 -Description 'bac'; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = New-TMXTestSuite -Name suite4 -Description 'cab'; " + 
                @"$null = New-TMXTestSuite -Name suite5 -Description 'bac'; " + 
                @"Search-TMXTestSuite -FilterDescriptionContains 'ab' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TMXTestSuite")]
        public void TestPrm_FilterDescriptionContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite4"));
            coll.Add(new System.Management.Automation.PSObject("suite1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1 -Description 'abc'; " + 
                @"$null = New-TMXTestSuite -Name suite2 -Description 'bac'; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = New-TMXTestSuite -Name suite4 -Description 'cab'; " + 
                @"$null = New-TMXTestSuite -Name suite5 -Description 'bac'; " + 
                @"Search-TMXTestSuite -FilterDescriptionContains 'ab' -Descending | %{$_.Name;}",
                coll);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
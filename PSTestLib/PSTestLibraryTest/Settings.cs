﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/29/2012
 * Time: 9:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLibraryTest
{
    //using System;
    
    /// <summary>
    /// Description of Settings.
    /// </summary>
    public static class Settings
    {
        static Settings()
        {
        }


        public const string RunspaceCommand = 
            @"Import-Module '.\UIAutomation.dll' -Force;" + @"Import-Module '.\Tmx.dll' -Force;";

        /*
        public static string RunspaceCommand = 
//#if DEBUG
//                        @"Import-Module '..\..\..\TMX\bin\Debug\Tmx.dll' -Force;" + //);
//#else
//                        @"Import-Module '..\..\..\TMX\bin\Release35\Tmx.dll' -Force;" + //);
//#endif
//                        @"";
        
                        // 20120706
                        @"Import-Module '.\UIAutomation.dll' -Force;" + 
                        @"Import-Module '.\Tmx.dll' -Force;";
        
                        //@"[Tmx.TestData]::TestSuites.Clear();";
//                        @"[UIAutomation.Preferences]::OnSuccessDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnErrorDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnClickDelay = 0;" +
//                        @"[UIAutomation.Preferences]::OnSleepDelay = 0;" +
//                        @"[UIAutomation.Preferences]::Timeout = 3000;" + 
//                        @"[UIAutomation.Preferences]::OnErrorScreenShot = $false;" + 
//                        @"[UIAutomation.Preferences]::Log = $false;";
        */
    }
}

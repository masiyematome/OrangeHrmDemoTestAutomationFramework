﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace OrangeHrmDemo.Web.Utilities
{
    public class ExtentReportsHelper
    {
        public static ExtentReports IntializeExtentReports(string destinationPath,string reporterTitle)
        {

            ExtentReports? extent = null;

            try
            {

                extent = new ExtentReports();
                ExtentHtmlReporter reporter = new ExtentHtmlReporter(destinationPath);

                extent.AttachReporter(reporter);

                reporter.Config.DocumentTitle = reporterTitle;
                reporter.Config.Theme = Theme.Dark;

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            return extent;

        }

    }

}
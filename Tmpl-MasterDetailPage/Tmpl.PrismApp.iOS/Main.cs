/* Copyright Omnicell, Inc. 2017-2019
 * Author:  Damian Suess
 * Date:    2019-1-8
 * File:    Main.cs
 * Description:
 *
 */


using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Tmpl.PrismApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}

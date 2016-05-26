// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

module Main

open fsharpbasic
open System
open System.Windows
open System.Windows.Threading

// Create an instance of the new control.
let br = new BallRender()
// Create a window to hold the control.
let win = new Window(Title = "Bouncing Ball",Content = br,Width = br.Width + 20.,Height = br.Height + 40.)
// Start the event loop and show the control.
let app = new Application()
[<STAThread>]
do app.Run win |> ignore




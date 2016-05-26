namespace fsharpbasic

open System
open System.Drawing
open System.Windows
open System.Windows.Media
open System.Windows.Threading
open fsharpbasic

type BallRender() as br =
    inherit FrameworkElement()
    let size = 5.0 
    let xMax = 100.00
    let yMax = 100.00

    let offset = 10.0

    let brush = new SolidColorBrush(Colors.Black)
    let pen = new Pen(brush,1.0)

    let ball = ref (Ball.New(50., 80., 0.75, 1.25))
    let timer = new DispatcherTimer(Interval = new TimeSpan(0,0,0,0,10))

    // Helper function to do some initialization.
    let init() =
        // Set the control's width and height.
        br.Width <- (xMax * size) + (offset * 2.0)
        br.Height <- (yMax * size) + (offset * 2.0)
        // Set up the timer.
        timer.Tick.Add(fun _ ->
            // Move the current ball to its next position.
            ball := ball.Value.Move(0.,0., xMax,yMax)
            // Invalidate the control to force a redraw.
            br.InvalidateVisual())
        timer.Start()

    do init()

    /// The function that takes care of actually drawing the ball.
    override x.OnRender(dc: DrawingContext) =
        // Calculate the ball's position on the canvas.
        let x = (ball.Value.X * size) + offset
        let y = (ball.Value.Y * size) + offset
        // Draw the ball and an outline rectangle.
        dc.DrawEllipse(brush, pen, new Point(x, y), size, size)
        dc.DrawRectangle(null, pen, new Rect(offset, offset, size * xMax, size * xMax))

    
Imports System.Net

Public Class Client

    Public Shared Sub Main(args() As String)
        Dim customerKey As String = "PUT_YOUR_CUSTOMER_KEY_HERE"
        Dim secretPhrase As String = "" REM leave secret phrase empty, If Not needed

        Dim options As New Dictionary(Of String, String)
        REM mandatory parameter
        options.Add("url", "https://www.google.com")
        REM  all next parameters are optional, see our API guide for more details
        options.Add("dimension", "1366x768") REM Or "1366xfull" For full length screenshot
        options.Add("device", "desktop")
        options.Add("format", "png")
        options.Add("cacheLimit", "0")
        options.Add("delay", "200")
        options.Add("zoom", "100")

        Dim sm As ScreenshotMachine = New ScreenshotMachine(customerKey, secretPhrase)
        Dim apiUrl As String = sm.GenerateApiUrl(options)

        REM use final apiUrl where needed
        Console.WriteLine(apiUrl)

        Dim client As New WebClient()
        Dim output As String = "output.png"
        client.DownloadFile(apiUrl, output)
        Console.WriteLine("Screenshot saved as " + output)
    End Sub

End Class
